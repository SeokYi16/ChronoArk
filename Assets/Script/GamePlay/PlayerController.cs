using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    Rigidbody2D myrigid;
    Animator myani;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
        myani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
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
    {//Àû°ú ¸¸³µÀ» ¶§ Enemy Äµ¹ö½º ¶ç¿ì±â
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.Enemy_Panel();
        }
    }
}