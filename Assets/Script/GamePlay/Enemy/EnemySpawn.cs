using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    Enemy enemy;
    public List<GameObject> enemy_count = new();
    //적 소환 위치
    [SerializeField]
    private Transform[] enemy_trans_pos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemy = collision.GetComponent<Enemy>();
            for (int i = 0; i < enemy.enemyprefabs.Length; i++)
            {
                //Enemy 배열 오브젝트를 가져와서 enemy_trans_pos에 생성
                Instantiate(enemy.enemyprefabs[i], enemy_trans_pos[i]);
                enemy_count.Add(enemy.enemyprefabs[i]);// 리스트에 적 오브젝트 담기
                //스크립트를 가져와야함
            }
        }
    }
}
