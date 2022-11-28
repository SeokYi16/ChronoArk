using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dochi2 : EnemyInfo
{
    public int dochi2maxhp = 20;
    public int dochi2hp = 20;
    public int dochi2str = 8;
    public int dochi2spd = 5;
    public int dochi2def = 4;

    public Slider dochi2_slider;
    public TextMeshProUGUI dochi2_hp_text;

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
        dochi2_slider.maxValue = dochi2maxhp;
    }

    private void Update()
    {
        dochi2_slider.value = dochi2hp;
        dochi2_hp_text.text = dochi2hp + " / " + dochi2maxhp;

        if (dochi2hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
