using UnityEngine;

public class BGMController : DontDestroySingleton<BGMController>
{
    void Start()
    {
        AkSoundEngine.SetState("LevelState", "Title");
    }

    public void ChangeBGMState(string state)
    {
        AkSoundEngine.SetState("LevelState", state);
    }

    public void SetAudioPause()
    {
        AkSoundEngine.SetState("GameState", "Pause");
    }
    public void SetAudioContinue()
    {
        AkSoundEngine.SetState("GameState", "Normal");
    }
}
