using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public EnemySprite enemysprite;

    //적 소환 위치와 스프라이트 배열
    [SerializeField]
    private Image[] get_enemy_img;
    [SerializeField]
    private Transform[] enemy_trans_pos;
    

    private void Awake()
    {
        enemysprite = FindObjectOfType<EnemySprite>();
        Debug.Log(enemysprite.enemy_imges.Length);
    }

    public void Enemy_Spawn()
    {
        for (int i = 0; i < enemysprite.enemy_imges.Length; i++)
        {
            get_enemy_img[i].sprite = enemysprite.enemy_imges[i].sprite;
            get_enemy_img[i].SetNativeSize();
        }
        if (enemysprite.enemy_imges.Length < get_enemy_img.Length)
        {
            get_enemy_img[2].enabled = false;
        }
    }

    public void Enemy_All_Dead()
    {
        get_enemy_img = null;
    }
}
