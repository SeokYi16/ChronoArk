using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    /*
    int[] enemyhp = { 30, 16, 20, 27, 34, 50 };
    int[] enemystr = { 10, 5, 8, 9, 13, 17 };
    int[] enemyspd = { 7, 4, 5, 11, 10, 13 };
    int[] enemydef = { 5, 3, 4, 6, 7, 9 };
    */

    public virtual void MonsterAtk(int monsterstr, int playerdef, int playerhp)
    {
        if(playerdef >= monsterstr)
        {
            playerhp += 0;
        }
        else
        {
            playerhp += playerdef - monsterstr;
        }
    }

    public virtual void MonsterDef(int playerstr, int monsterdef, int monsterhp)
    {
        if(monsterdef >= playerstr)
        {
            monsterhp += 0;
        }
        else
        {
            monsterhp += monsterdef - playerstr;
        }
    }
}
