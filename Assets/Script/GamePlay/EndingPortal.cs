using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPortal : MonoBehaviour
{
    public GameObject end_portal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            end_portal.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            end_portal.SetActive(false);
        }
    }
    public void Ending_Click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
