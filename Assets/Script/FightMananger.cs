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

    public void FirstTurn(int playerspd, int sub1, int sub2)//�� ���� ���� ��� �߰��ؾ��ϳ�
    {
        int [] enemyspd = new int[enemySpawn.enemy_count.Count]; //�� ���ǵ带 ������� �� ����ŭ �迭�� ����
        for(int i = 0; i < enemySpawn.enemy_count.Count; i++)
        {
            enemyspd[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemyspd; //�� ���ǵ带 ����
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
