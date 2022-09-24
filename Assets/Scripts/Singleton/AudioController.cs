using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    public AudioTable m_AudioTable;

    private AudioSource m_AudioSource_BGM;
    private AudioSource m_AudioSource_Eff;

    public string curBGMName { get; private set; }
    public string curEffectName { get; private set; }
    public override void OnAwake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        m_AudioSource_BGM = audioSources[0];
        m_AudioSource_Eff = audioSources[1];
        curEffectName = "";
        curBGMName = "";
    }

    public void PlayOneShot(string name, AudioSource audioSource = null)
    {
        if (audioSource == null)
        {
            if (!m_AudioTable.audioDic.ContainsKey(name))
                return;
            AudioClip audioClip = m_AudioTable.audioDic[name].audioClip;
            float volume = m_AudioTable.audioDic[name].volume;
            //m_AudioSource_Eff.PlayOneShot(audioClip, volume);
            curEffectName = name;
        }
        else
        {
            if (!m_AudioTable.audioDic.ContainsKey(name))
                return;
            AudioClip audioClip = m_AudioTable.audioDic[name].audioClip;
            float volume = m_AudioTable.audioDic[name].volume;
            //audioSource.PlayOneShot(audioClip, volume);
        }
    }

    public void PlayBGM(string name)
    {
        if (!m_AudioTable.audioDic.ContainsKey(name))
            return;
        AudioClip audioClip = m_AudioTable.audioDic[name].audioClip;
        float volume = m_AudioTable.audioDic[name].volume;
        m_AudioSource_BGM.clip = audioClip;
        m_AudioSource_BGM.volume = volume;
        //m_AudioSource_BGM.Play();
        curBGMName = name;

    }

    public void StopBGM()
    {
        m_AudioSource_BGM.Stop();
    }

    public bool IsPlaying()
    {
        return m_AudioSource_Eff.isPlaying;
    }
}
