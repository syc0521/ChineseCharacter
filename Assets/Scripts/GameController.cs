using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public OnValueChangedEventListener<int> missionTaskCount;
    public bool isPaused = false;
    public bool isTutorial = false;
    public delegate void OnMissionSuccessDelegate();
    public event OnMissionSuccessDelegate OnMissionSuccessEvent;
    public override void OnAwake()
    {
        Debug.Log("GameController OnAwake");
        if (missionTaskCount == null)
            missionTaskCount = new OnValueChangedEventListener<int>();
        missionTaskCount.Value = 3;        
    }

    private void Start()
    {
        var curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (curSceneIndex)
        {
            case 1:
                isTutorial = false;
                BGMController.Instance?.ChangeBGMState("Title");
                break;
            case 2:
                isTutorial = true;
                break;
            case 4:
                isTutorial = false;
                BGMController.Instance?.ChangeBGMState("Level1");
                break;
            case 3:
                isTutorial = false;
                BGMController.Instance?.ChangeBGMState("Level2");
                break;
        }
        Debug.Log("GameController Start");
        missionTaskCount.OnValueChangedEvent += newValue =>
        {
            if (newValue <= 0)
            {
                AkSoundEngine.PostEvent("Play_Success_Effect", gameObject);
                DOVirtual.DelayedCall(4f, () =>
                {
                    GameObject.FindWithTag("SceneNode").GetComponent<SceneNode>().Disappear();
                    OnMissionSuccessEvent?.Invoke();
                });

            }
        };
    }

    private void Update()
    {
        //Debug.Log("MissionTaskCount: " + missionTaskCount.Value);
    }

    public void TaskSuccess(int UITipID)
    {
        AkSoundEngine.PostEvent("Play_TaskSuccess_Effect", gameObject);
        GamePlayUIController.Instance.TipSuccess(UITipID);
        missionTaskCount.Value--;
        Debug.Log("TaskSuccess" + missionTaskCount.Value);
    }

    private void OnEnable()
    {
        Debug.Log("GameController OnEnable");
    }

}
