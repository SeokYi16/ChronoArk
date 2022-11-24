using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dochi : EnemyInfo
{
    int enemyhp = 16;
    int enemystr = 5;
    int enemyspd = 4;
    int enemydef = 3;

    public override void MonsterAtk(int monsterstr, int playerdef, int playerhp)
    {
        base.MonsterAtk(monsterstr, playerdef, playerhp);
    }

    public override void MonsterDef(int playerstr, int monsterdef, int monsterhp)
    {
        base.MonsterDef(playerstr, monsterdef, monsterhp);
    }
}
