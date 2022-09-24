using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AudioTable", menuName = "ScriptableObjs/AudioTable")]
public class AudioTable : ScriptableObject
{
    public Dictionary<string, M_AudioClip> audioDic = new Dictionary<string, M_AudioClip>();

    [System.Serializable]
    public struct AudioStruct
    {
        [Header("音频文件名字")]
        public string key;
        [Header("音频文件资源")]
        public AudioClip audioClip; 
        [Header("音量")]
        [Range(0,1)]
        public float volume;

    }

    public struct M_AudioClip
    {
        public AudioClip audioClip;
        public float volume;
    }

    public AudioStruct[] audioDatas;

    private void OnEnable()
    {
        for (int i = 0; i < audioDatas.Length; i++)
        {
            if (!audioDic.ContainsKey(audioDatas[i].key))
            {
                M_AudioClip temp = new M_AudioClip();
                temp.audioClip=audioDatas[i].audioClip;
                temp.volume=audioDatas[i].volume;
                audioDic.Add(audioDatas[i].key,temp);
            }
        }
    }
}
