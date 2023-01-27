using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D polygonCollider2D;
    [SerializeField]
    private GameObject itembox_f;
    [SerializeField]
    private SpriteRenderer itembox_e;
    private void Update()
    {
        if (polygonCollider2D == null)
        {
            itembox_f.SetActive(false);
            itembox_e.color = Color.gray;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(polygonCollider2D != null)
            {
                polygonCollider2D.enabled = true;
                itembox_f.SetActive(true);
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
                itembox_f.SetActive(false);
            }
            else
            {
                polygonCollider2D = null;
            }
        }
    }
}
