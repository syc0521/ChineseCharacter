using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class SelectUIController : Singleton<SelectUIController>
{
    public SelectModels levelModels;
    public Transform[] placeholders;
    private VisualElement root;
    private Button backButton, leftButton, rightButton, enterButton;
    private GameObject[] currentModels;
    public int CurrentID
    {
        get
        {
            return currentID;
        }
        private set
        {
            if (value < 0) return;
            if (value >= levelModels.models.Length) return;
            currentID = value;
            CheckButtons();
        }
    }
    private int currentID = 0;
    public override void OnAwake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }
    void Start()
    {
        currentModels = new GameObject[3];
        (backButton = root?.Q<Button>("BackButton"))?.RegisterCallback<ClickEvent>(ev => OnBackButtonPressed());
        (leftButton = root?.Q<Button>("LeftButton"))?.RegisterCallback<ClickEvent>(ev => OnLeftButtonPressed());
        (rightButton = root?.Q<Button>("RightButton"))?.RegisterCallback<ClickEvent>(ev => OnRightButtonPressed());
        (enterButton = root?.Q<Button>("EnterButton"))?.RegisterCallback<ClickEvent>(ev => OnEnterButtonPressed());
        for (int i = 1; i < 3; i++)
        {
            GenerateNotExistModel(i);
        }
        CurrentID = 0;
    }

    private void OnBackButtonPressed()
    {
        Loading.Instance.LoadScene("StartScene");
    }

    private void OnLeftButtonPressed()
    {
        CurrentID--;
        if (currentID == levelModels.models.Length - 2)
        {
            GenerateNotExistModel(2);
        }
    }

    private void OnRightButtonPressed()
    {
        CurrentID++;
        GenerateNotExistModel(0);
    }

    private void OnEnterButtonPressed()
    {

    }

    private void CheckButtons()
    {
        if (CurrentID == 0) leftButton.SetEnabled(false);
        else if (CurrentID == levelModels.models.Length - 1) rightButton.SetEnabled(false);
        else
        {
            leftButton.SetEnabled(true);
            rightButton.SetEnabled(true);
        }
    }

    private void GenerateNotExistModel(int id)
    {
        if (currentModels[id] == null)
        {
            currentModels[id] = Instantiate(levelModels.models[CurrentID + id - 1]);
            currentModels[id].transform.SetPositionAndRotation(placeholders[id].position, placeholders[id].rotation);
            currentModels[id].transform.localScale = placeholders[id].localScale;
        }
    }
}
