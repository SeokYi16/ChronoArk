using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    AzarStat azarstat;
    JoeyStat joeystat;
    PlayerStat playerstat;

    public Sprite[] info_chr_img;

    [SerializeField]
    private TextMeshProUGUI info_Name_text;
    [SerializeField]
    private TextMeshProUGUI info_Chr_text;
    [SerializeField]
    private Image player_info_img;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        azarstat = GetComponent<AzarStat>();
        joeystat = GetComponent<JoeyStat>();
        playerstat = GetComponent<PlayerStat>();
    }

    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void Lucy_info_Click()
    {
        player_info_img.sprite = info_chr_img[0];
        info_Name_text.text = "�� ��";
        //info_Chr_text.text = "���� ü�� : " + playerstat.hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : " + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed;
    }

    public void Azar_info_Click()
    {
        player_info_img.sprite = info_chr_img[1];
        info_Name_text.text = "���ڸ�";
        //info_Chr_text.text = "���� ü�� : " + azarstat.hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : " + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed;
    }

    public void Joey_info_Click()
    {
        player_info_img.sprite = info_chr_img[2];
        info_Name_text.text = "�� ��";
        //info_Chr_text.text = "���� ü�� : " + joeystat.hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : " + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed;
    }
}
