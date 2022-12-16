using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyInfo : MonoBehaviour
{
    /*
    int[] enemyhp = { 30, 16, 20, 27, 34, 50 };
    int[] enemystr = { 10, 5, 8, 9, 13, 17 };
    int[] enemyspd = { 7, 4, 5, 11, 10, 13 };
    int[] enemydef = { 5, 3, 4, 6, 7, 9 };
    */

    //각 적 정보를 입력
    public int enemyhp;
    public int enemystr;
    public int enemyspd;
    public int enemydef;
    public int enemymaxhp;
    public bool isAtk;

    public Slider enemy_slider;
    public TextMeshProUGUI enemy_hp_text;

    public Sprite enemy_slier_icon;


    private void Start()
    {   //적 hp = 최대 hp 와 슬라이더 max값을 적 maxhp로 바꿈
        enemyhp = enemymaxhp;
        enemy_slider.maxValue = enemymaxhp;
    }

    private void Update()
    {   //실시간 적 체력 표기
        enemy_slider.value = enemyhp;
        enemy_hp_text.text = enemyhp + " / " + enemymaxhp;
        //체력이 0이면 오브젝트 파괴
        if (enemyhp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Debuff_P()
    {

    }

    public void Monster_Atk()
    {

    }

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
