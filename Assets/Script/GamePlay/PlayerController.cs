using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    Rigidbody2D myrigid;
    Animator myani;
    public bool isEnemy;
    Enemy em;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
        myani = GetComponent<Animator>();
        isEnemy = false;
    }

    private void FixedUpdate()
    {
        if (!isEnemy)
        {
            if (!TalkManager.Instance.isTalking)
            {
                Move();
            }
        }
    }

    private void Update()
    {
        if (em != null)
        {
            Debug.Log("실행");
            em.All_Dead_Enemy();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myrigid.transform.Translate(new Vector2(-4 * Time.deltaTime, 0));
            gameObject.transform.localScale = new Vector2(-0.5f, 0.5f);
            myani.SetBool("isMove",true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myrigid.transform.Translate(new Vector2(4 * Time.deltaTime, 0));
            gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
            myani.SetBool("isMove", true);
        }
        else
        {
            myani.SetBool("isMove", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            myrigid.transform.Translate(new Vector2(0, 4 * Time.deltaTime));
            myani.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myrigid.transform.Translate(new Vector2(0, -4 * Time.deltaTime));
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//Npc와 대화를 할 경우 움직임 제어
        if (collision.gameObject.tag == "NPC")
        {
            TalkManager.Instance.Npc_Rian_Talk();//대화창 열림
            TalkManager.Instance.isTalking = true;
            TalkManager.Instance.talk_obj = collision.gameObject;
        }
    }

    public void Random_Text_Talk()
    {
        int x;
        x = Random.Range(0, 2);
        if(x == 0)
        {
            GameManager.Instance.Azar_Rnd_Text();
        }
        else
        {
            GameManager.Instance.Joey_Rnd_Text();
        }
    }
}