using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dochi : EnemyInfo
{
    public int dochimaxhp = 16;
    public int dochihp = 16;
    public int dochistr = 5;
    public int dochispd = 4;
    public int dochidef = 3;

    public Slider dochi_slider;
    public TextMeshProUGUI dochi_hp_text;

    public override void MonsterAtk(int monsterstr, int playerdef, int playerhp)
    {
        base.MonsterAtk(monsterstr, playerdef, playerhp);
    }

    public override void MonsterDef(int playerstr, int monsterdef, int monsterhp)
    {
        base.MonsterDef(playerstr, monsterdef, monsterhp);
    }

    private void Start()
    {
        dochi_slider.maxValue = dochimaxhp;
    }

    private void Update()
    {
        dochi_slider.value = dochihp;
        dochi_hp_text.text = dochihp + " / " + dochimaxhp;

        if (dochihp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
