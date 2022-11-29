using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMananger : MonoBehaviour
{
    EnemySpawn enemySpawn;

    private void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    public void FirstTurn(int playerspd, int sub1, int sub2)//적 수에 따라 어떻게 추가해야하나
    {

    }
}
