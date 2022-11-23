using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeyStat : MonoBehaviour
{
    public float speed =5;
    public float str=6;
    public float def=7;
    public float hp=8;

    public float max_hp = 8;

    private void Update()
    {
        if (hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
