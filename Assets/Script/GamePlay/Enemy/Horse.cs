using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Horse : EnemyInfo
{
    public int horse_maxhp = 25;
    public int horse_hp = 25;
    public int horse_str = 9;
    public int horse_spd = 11;
    public int horse_def = 6;

    public Slider horse_slider;
    public TextMeshProUGUI horse_hp_text;

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
        horse_slider.maxValue = horse_maxhp;
    }

    private void Update()
    {
        horse_slider.value = horse_hp;
        horse_hp_text.text = horse_hp + " / " + horse_maxhp;

        if (horse_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
