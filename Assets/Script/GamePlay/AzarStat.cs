using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarStat : MonoBehaviour
{
    public float speed=6;
    public float str=7;
    public float def=8;
    public float hp=9;

    public float max_hp = 9;

    private void Update()
    {
        if (hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
