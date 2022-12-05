using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightMananger : MonoBehaviour
{
    EnemySpawn enemySpawn;

    public Slider player_TurnSlider;
    public Slider azar_TurnSlider;
    public Slider joey_TurnSlider;

    public PlayerStat playerStat;
    public AzarStat azarStat;
    public JoeyStat joeyStat;

    public bool turn_start = false;

    private void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    private void Update()
    {
        SliderCount();
    }

    public void FirstTurn(int playerspd, int sub1, int sub2)//적 수에 따라 어떻게 추가해야하나
    {
        int [] enemyspd = new int[enemySpawn.enemy_count.Count]; //적 스피드를 담기위해 적 수만큼 배열을 생성
        for(int i = 0; i < enemySpawn.enemy_count.Count; i++)
        {
            enemyspd[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemyspd; //적 스피드를 담음
        }
    }

    void SliderCount()
    {
        if (!turn_start)
        {
            player_TurnSlider.value -= Time.deltaTime * 10 * playerStat.speed;
            azar_TurnSlider.value -= Time.deltaTime * 10 * azarStat.speed;
            joey_TurnSlider.value -= Time.deltaTime * 10 * joeyStat.speed;
        }
        else
        {

        }

        if(player_TurnSlider.value <= 0 || azar_TurnSlider.value <= 0 || joey_TurnSlider.value <=0)
        {
            turn_start = true;
        }
        else
        {
            turn_start = false;
        }

    }
}
