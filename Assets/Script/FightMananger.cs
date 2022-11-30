using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightMananger : MonoBehaviour
{
    EnemySpawn enemySpawn;

    private void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    private void Update()
    {
        
    }

    public void FirstTurn(int playerspd, int sub1, int sub2)//�� ���� ���� ��� �߰��ؾ��ϳ�
    {
        int [] enemyspd = new int[enemySpawn.enemy_count.Count]; //�� ���ǵ带 ������� �� ����ŭ �迭�� ����
        for(int i = 0; i < enemySpawn.enemy_count.Count; i++)
        {
            enemyspd[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemyspd; //�� ���ǵ带 ����
        }
    }
}
