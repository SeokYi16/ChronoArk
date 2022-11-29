using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int speed = 4;
    public int str = 5;
    public int def = 6;
    public int hp = 24;

    public int max_hp = 24;

    public bool isTurn;

    private void Update()
    {
        if(hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
