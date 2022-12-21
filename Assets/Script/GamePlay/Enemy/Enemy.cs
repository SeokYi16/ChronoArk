using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] enemyprefabs;

    public void All_Dead_Enemy() //몬스터가 전부 죽었을 떄 오브젝트 파괴(맵에 있는 적을 파괴함)
    {
        Destroy(gameObject);
    }
}
