using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int speed = 4;
    public int str = 5;
    public int def = 6;
    public int hp = 7;

    public int max_hp = 7;

    private void Update()
    {
        if(hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
