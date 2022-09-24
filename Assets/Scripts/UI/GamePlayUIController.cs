using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GamePlayUIController : Singleton<GamePlayUIController>
{
    public TipUISprite tipSprite;
    public UIDocument mainui, pauseui;
    private VisualElement mainRoot, pauseRoot;
    private VisualElement[] hints;
    private VisualElement[] slots;
    private Button pauseBtn;
    private GameControls gameControls;

    public override void OnAwake()
    {
        gameControls = new GameControls();
        hints = new VisualElement[3];
        slots = new VisualElement[3];
        mainRoot = mainui.rootVisualElement;
        mainRoot?.Q<Button>("PauseButton")?.RegisterCallback<ClickEvent>(ev => OnPausePressed());
        pauseBtn = mainRoot?.Q<Button>("PauseButton");
    }

    void Start()
    {
        gameControls.GamePlay.Exit.performed += ctx => OnPausePressed();
        for (int i = 0; i < 3; i++)
        {
            var hintNode = mainRoot?.Q<VisualElement>("Hint" + i.ToString());
            if (hintNode != null)
            {
                hints[i] = hintNode;
                hintNode.style.backgroundImage = new(tipSprite.white[i]);
            }
            var slotNode = mainRoot?.Q<VisualElement>("Slot" + i.ToString());
            if (slotNode != null)
            {
                slots[i] = slotNode;
                slotNode.style.backgroundImage = new(tipSprite.black[i]);
            }
        }
    }
    private void OnRetryPressed()
    {
        OnContinuePressed();
        Loading.Instance.LoadCurrentScene();
    }

    private void OnContinuePressed()
    {
        GameController.Instance.isPaused = false;
        AkSoundEngine.PostEvent("Play_Button_Effect", gameObject);
        Debug.Log("Continue");
        pauseui.gameObject.SetActive(false);
        Time.timeScale = 1;
        SetMainUIVisibility(true);
        BGMController.Instance?.SetAudioContinue();
        CameraBlur.Instance.StopCameraBlur();
    }

    private void OnBackPressed()
    {
        OnContinuePressed();
        Loading.Instance.LoadScene("StartScene");
    }

    private void OnPausePressed()
    {
        if (!GameController.Instance.isPaused)
        {
            AkSoundEngine.PostEvent("Play_Button_Effect", gameObject);
            GameController.Instance.isPaused = true;
            Debug.Log("Pause");
            SetMainUIVisibility(false);
            pauseui.gameObject.SetActive(true);
            BindPauseData();
            Time.timeScale = 0;
            BGMController.Instance?.SetAudioPause();
            CameraBlur.Instance.StartCameraBlur();
        }
    }

    private void SetMainUIVisibility(bool b)
    {
        pauseBtn.visible = b;
        foreach (var item in hints)
        {
            item.visible = b;
        }
        foreach (var item in slots)
        {
            item.visible = b;
        }
    }

    private void BindPauseData()
    {
        pauseRoot = pauseui.rootVisualElement;
        pauseRoot?.Q<Button>("RetryButton")?.RegisterCallback<ClickEvent>(ev => OnRetryPressed());
        pauseRoot?.Q<Button>("ContinueButton")?.RegisterCallback<ClickEvent>(ev => OnContinuePressed());
        pauseRoot?.Q<Button>("BackButton")?.RegisterCallback<ClickEvent>(ev => OnBackPressed());
    }

    public void TipSuccess(int ID)
    {
        if (ID == -1) return;
        SlotAnimation(slots[ID]);
        SlotAnimation(hints[ID]);
        DOTween.To(() => 0f, x => hints[ID].style.opacity = x, 1.0f, 0.8333f).SetEase(Ease.OutQuad);
    }

    private void SlotAnimation(VisualElement node)
    {
        DOTween.Sequence()
            .Append(DOTween.To(() => 0f, x => node.style.rotate = new(new Rotate(new Angle(x))), -20f, 0.16f).SetEase(Ease.InQuad))
            .Append(DOTween.To(() => -20f, x => node.style.rotate = new(new Rotate(new Angle(x))), 20f, 0.1f).SetEase(Ease.InQuad))
            .Append(DOTween.To(() => -20f, x => node.style.rotate = new(new Rotate(new Angle(x))), 0f, 0.05f).SetEase(Ease.OutQuad));
        DOTween.Sequence()
            .Append(DOTween.To(() => 1f, x => node.style.scale = new(new Scale(new Vector2(x, x))), 1.1f, 0.05f).SetEase(Ease.OutQuint))
            .AppendInterval(0.16f)
            .Append(DOTween.To(() => 1.1f, x => node.style.scale = new(new Scale(new Vector2(x, x))), 1f, 0.05f).SetEase(Ease.OutQuad));
    }

    private void OnEnable()
    {
        if (gameControls == null) return;
        gameControls.Enable();
    }

    private void OnDisable()
    {
        if (gameControls == null) return;
        gameControls.Disable();
    }

}
