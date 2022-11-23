using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float speed = 4;
    public float str = 5;
    public float def = 6;
    public float hp = 7;

    public float max_hp = 7;

    private void Update()
    {
        if(hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
