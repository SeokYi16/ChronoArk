using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarStat : MonoBehaviour
{
    public int speed =6;
    public int str =7;
    public int def =8;
    public int hp =9;

    public int max_hp = 9;

    private void Update()
    {
        if (hp >= max_hp)
        {
            hp = max_hp;
        }
    }
}
