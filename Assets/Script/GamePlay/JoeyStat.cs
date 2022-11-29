using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeyStat : MonoBehaviour
{
    public int speed =5;
    public int str =6;
    public int def =7;
    public int hp =21;

    public int max_hp = 21;

    public bool isTurn;

    private void Update()
    {
        if (hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
