using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }
    public static SoundManager Instance
    {//ΩÃ±€≈Ê
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
}
