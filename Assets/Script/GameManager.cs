using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    //ĳ���� ���� ����
    [SerializeField]
    private AzarStat azarstat;
    [SerializeField]
    private JoeyStat joeystat;
    [SerializeField]
    private PlayerStat playerstat;

    public Sprite[] info_chr_img;

    //ĳ���� ����ǥ��
    [SerializeField]
    private TextMeshProUGUI info_Name_text;
    [SerializeField]
    private TextMeshProUGUI info_Chr_text;
    [SerializeField]
    private Image player_info_img;
    [SerializeField]
    private GameObject player_Info;

    private FightMananger FM;

    private void Awake()
    {//�̱���
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {//�̱���
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    //���� ��ư ����
    public void Lucy_info_Click()
    {
        player_info_img.sprite = info_chr_img[0];
        info_Name_text.text = "�� ��";
        info_Chr_text.text = "���� ü�� : " + playerstat.hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : " + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed;
    }

    public void Azar_info_Click()
    {
        player_info_img.sprite = info_chr_img[1];
        info_Name_text.text = "���ڸ�";
        info_Chr_text.text = "���� ü�� : " + azarstat.hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : " + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed;
    }

    public void Joey_info_Click()
    {
        player_info_img.sprite = info_chr_img[2];
        info_Name_text.text = "�� ��";
        info_Chr_text.text = "���� ü�� : " + joeystat.hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : " + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed;
    }
    // ����â Ŭ�� ��
    public void Player_Info_OnClick()
    {
        player_Info.SetActive(true);
        Lucy_info_Click();
    }

    public void Player_Info_Close()
    {
        player_Info.SetActive(false);
    }

    [SerializeField]
    private GameObject enemy_panel;
    public bool isEnemy_Fight;
    public void Enemy_Panel()
    {
        enemy_panel.SetActive(true);
        isEnemy_Fight = true;
        FM = FindObjectOfType<FightMananger>();
        FM.FirstTurn(playerstat.speed, azarstat.speed, joeystat.speed); //�ӵ� �� �������?
    }

    public void Enemy_Panel_Close()
    {
        enemy_panel.SetActive(false);
        isEnemy_Fight = false;
    }
}
