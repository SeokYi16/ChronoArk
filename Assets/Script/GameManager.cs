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

    public int indexNum;

    private FightMananger FM;
    //������ �߰� ��ư
    public GameObject[] lv_Up_Btn;
    int lv_Up;

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

    private void Update()
    {
        if(lv_Up > 0) //���� ���� ��ư �۵�
        {
            lv_Up_Btn[0].SetActive(true);
            lv_Up_Btn[1].SetActive(true);
            lv_Up_Btn[2].SetActive(true);
            lv_Up_Btn[3].SetActive(true);
        }
        else
        {
            lv_Up_Btn[0].SetActive(false);
            lv_Up_Btn[1].SetActive(false);
            lv_Up_Btn[2].SetActive(false);
            lv_Up_Btn[3].SetActive(false);
        }
    }
    //���� ��ư ����
    public void Lucy_info_Click()
    {
        player_info_img.sprite = info_chr_img[0];
        info_Name_text.text = "�� ��";
        info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : " 
            + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        indexNum = 0;
    }

    public void Azar_info_Click()
    {
        player_info_img.sprite = info_chr_img[1];
        info_Name_text.text = "���ڸ�";
        info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : " 
            + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        indexNum = 1;
    }

    public void Joey_info_Click()
    {
        player_info_img.sprite = info_chr_img[2];
        info_Name_text.text = "�� ��";
        info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : " 
            + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        indexNum = 2;
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
        lv_Up += 6; //���� ���� 6�߰�
        //FM = FindObjectOfType<FightMananger>();
        //FM.FirstTurn(playerstat.speed, azarstat.speed, joeystat.speed); //�ӵ� �� �������?
    }

    public void Enemy_Panel_Close()
    {
        enemy_panel.SetActive(false);
        isEnemy_Fight = false;
        FindObjectOfType<PlayerController>().isEnemy = false;
    }

    public void Hp_Lv_Up_Btn() //HP���� ���� Ŭ����
    {
        if(indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.max_hp += 3;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.max_hp += 3;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
    + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.max_hp += 3;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed;
        }
    }

    public void Str_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.str += 1;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.str += 1;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
    + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.str += 1;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed;
        }
    }

    public void Def_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.def += 1;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.def += 1;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
    + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.def += 1;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed;
        }
    }

    public void Spd_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.speed += 1;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.speed += 1;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
+ azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.speed += 1;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed;
        }
    }
}
