using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Witch : EnemyInfo
{
    public int witch_maxhp = 34;
    public int witch_hp = 34;
    public int witch_str = 13;
    public int witch_spd = 10;
    public int witch_def = 7;

    public Slider witch_slider;
    public TextMeshProUGUI witch_hp_text;

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
        witch_slider.maxValue = witch_maxhp;
    }

    private void Update()
    {
        witch_slider.value = witch_hp;
        witch_hp_text.text = witch_hp + " / " + witch_maxhp;

        if (witch_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
