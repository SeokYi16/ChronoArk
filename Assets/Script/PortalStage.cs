using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalStage : MonoBehaviour
{
    [SerializeField]
    private GameObject ifmove;
    [SerializeField]
    private GameObject playerChr;
    [SerializeField]
    private GameObject playerCam;
    [SerializeField]
    private GameObject playerCam2;
    [SerializeField]
    private GameObject stage2Trs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ifmove.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ifmove.SetActive(false);
        }
    }

    public void StageMoveOnClick()
    {
        playerChr.transform.position = stage2Trs.transform.position;
        playerCam.SetActive(false);
        playerCam2.SetActive(true);
    }
}
