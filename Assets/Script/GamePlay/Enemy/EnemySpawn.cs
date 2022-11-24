using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    Enemy enemy;
    //�� ��ȯ ��ġ
    [SerializeField]
    private Transform[] enemy_trans_pos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemy = collision.GetComponent<Enemy>();
            for (int i = 0; i < enemy.enemyprefabs.Length; i++)
            {
                //Enemy �迭 ������Ʈ�� �����ͼ� enemy_trans_pos�� ����
                Instantiate(enemy.enemyprefabs[i], enemy_trans_pos[i]);
            }
        }
    }
}
