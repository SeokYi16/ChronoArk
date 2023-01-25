using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private Image stageimg;
    [SerializeField]
    private Sprite stagechange;

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
        fadePanel.SetActive(true);
        playerChr.transform.position = stage2Trs.transform.position;
        playerCam.SetActive(false);
        playerCam2.SetActive(true); //ī�޶� ������������ ������ ���� �ΰ� ��ġ�� ������ �ٲ�

        stageimg.sprite = stagechange;
    }
}
