using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    Rigidbody2D myrigid;
    Animator myani;
    bool isEnemy;
    Enemy em;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
        myani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!isEnemy)
        {
            Move();
        }
    }

    private void Update()
    {
        if (GameManager.Instance.isEnemy_Fight == false)
        {
            isEnemy = false;
            if (em != null)
            {
                Debug.Log("실행");
                em.All_Dead_Enemy();
            }
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myrigid.transform.Translate(new Vector2(-6 * Time.deltaTime, 0));
            gameObject.transform.localScale = new Vector2(-0.5f, 0.5f);
            myani.SetBool("isMove",true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myrigid.transform.Translate(new Vector2(6 * Time.deltaTime, 0));
            gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
            myani.SetBool("isMove", true);
        }
        else
        {
            myani.SetBool("isMove", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            myrigid.transform.Translate(new Vector2(0, 6 * Time.deltaTime));
            myani.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myrigid.transform.Translate(new Vector2(0, -6 * Time.deltaTime));
            myani.SetBool("isMove", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {//적과 만났을 때 Enemy 캔버스 띄우기 움직임 제어
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.Enemy_Panel();
            isEnemy = true;
            em = collision.gameObject.GetComponent<Enemy>();
        }

        if (collision.gameObject.tag == "NPC")
        {
            TalkManager.Instance.Npc_Rian_Talk();
            isEnemy = true;
        }
    }
}