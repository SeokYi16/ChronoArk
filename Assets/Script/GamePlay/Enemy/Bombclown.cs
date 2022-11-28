using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bombclown : EnemyInfo
{
    public int Bombclown_maxhp = 30;
    public int Bombclown_hp = 30;
    public int Bombclown_str = 10;
    public int Bombclown_spd = 7;
    public int Bombclown_def = 5;

    public Slider Bombclown_slider;
    public TextMeshProUGUI Bombclown_hp_text;

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
        Bombclown_slider.maxValue = Bombclown_maxhp;
    }

    private void Update()
    {
        Bombclown_slider.value = Bombclown_hp;
        Bombclown_hp_text.text = Bombclown_hp + " / " + Bombclown_maxhp;

        if (Bombclown_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
