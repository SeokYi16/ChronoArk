using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeyStat : MonoBehaviour
{
    public int speed =5;
    public int str =6;
    public int def =7;
    public int hp =8;

    public int max_hp = 8;

    private void Update()
    {
        if (hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
