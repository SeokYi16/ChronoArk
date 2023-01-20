using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestObj : MonoBehaviour
{
    public PolygonCollider2D polygonCollider2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (polygonCollider2D != null)
            {
                polygonCollider2D.enabled = true;
            }
            else
            {
                polygonCollider2D = null;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (polygonCollider2D != null)
            {
                polygonCollider2D.enabled = false;
            }
            else
            {
                polygonCollider2D = null;
            }
        }
    }
}
