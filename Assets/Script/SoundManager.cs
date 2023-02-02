using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public AudioSource audioSource;
    public AudioSource backgroundaudio;
    public AudioClip[] audioClip;
    //0,1 백그라운드 사운드
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }
    public static SoundManager Instance
    {//싱글톤
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public void NO_Fight()
    {
        backgroundaudio.Play();
        audioSource.Stop();
    }

    public void Is_Fight()
    {
        backgroundaudio.Stop();
        audioSource.Play();
    }
}
