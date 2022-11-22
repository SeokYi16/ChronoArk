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
        info_Name_text.text = "루 시";
        //info_Chr_text.text = "남은 체력 : " + playerstat.hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : " + playerstat.def + "\n\n" + "속도 : " + playerstat.speed;
    }

    public void Azar_info_Click()
    {
        player_info_img.sprite = info_chr_img[1];
        info_Name_text.text = "아자르";
        //info_Chr_text.text = "남은 체력 : " + azarstat.hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : " + azarstat.def + "\n\n" + "속도 : " + azarstat.speed;
    }

    public void Joey_info_Click()
    {
        player_info_img.sprite = info_chr_img[2];
        info_Name_text.text = "조 이";
        //info_Chr_text.text = "남은 체력 : " + joeystat.hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : " + joeystat.def + "\n\n" + "속도 : " + joeystat.speed;
    }
}
