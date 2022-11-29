using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class W_Armor : EnemyInfo
{
    public int armor_maxhp = 50;
    public int armor_hp = 50;
    public int armor_str = 17;
    public int armor_spd = 13;
    public int armor_def = 9;

    public Slider armor_slider;
    public TextMeshProUGUI armor_hp_text;

    FightMananger FM;

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
        armor_slider.maxValue = armor_maxhp;
        FM = FindObjectOfType<FightMananger>();
    }

    private void Update()
    {
        armor_slider.value = armor_hp;
        armor_hp_text.text = armor_hp + " / " + armor_maxhp;

        if (armor_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
