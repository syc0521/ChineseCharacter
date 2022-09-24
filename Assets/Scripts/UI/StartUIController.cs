using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartUIController : MonoBehaviour
{
    public GameObject UIPanel;
    public Button startBtn;
    public Button selectBtn;
    public Button exitBtn;

    public Cinemachine.CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            AkSoundEngine.PostEvent("Play_Button_Effect", gameObject);
            Debug.Log("开始游戏");
            virtualCamera.Priority = 9;
            UIPanel.SetActive(false);
            DOVirtual.DelayedCall(2f, () =>
            {
                BGMController.Instance.ChangeBGMState("Level0");
                Loading.Instance.LoadScene(2);
            });
        });

        selectBtn.onClick.AddListener(() =>
        {
            AkSoundEngine.PostEvent("Play_Button_Effect", gameObject);
            Debug.Log("选关界面");
        });

        exitBtn.onClick.AddListener(() =>
        {
            AkSoundEngine.PostEvent("Play_Button_Effect", gameObject);
            Debug.Log("退出游戏");
            Application.Quit();
        });
    }

    public void OnPointEnter(RectTransform transform)
    {
        transform.DOScale(1.3f, 0.4f);
    }

    public void OnPointExit(RectTransform transform)
    {
        transform.DOScale(1, 0.4f);
    }

}
