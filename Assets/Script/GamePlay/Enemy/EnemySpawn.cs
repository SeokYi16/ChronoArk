using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    Enemy enemy;
    public List<GameObject> enemy_count = new();
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
                GameObject a = Instantiate(enemy.enemyprefabs[i], enemy_trans_pos[i]);
                enemy_count.Add(enemy.enemyprefabs[i]);// ����Ʈ�� �� ������Ʈ ���
                FightMananger.Instance.enemy_gameObjects.Add(a);
                //FightMananger.Instance.gameObjects[i] = enemy.enemyprefabs[i].gameObject;
                //��ũ��Ʈ�� �����;���
            }
        }
    }
}
