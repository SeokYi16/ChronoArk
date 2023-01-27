using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    //ĳ���� ���� ����
    public AzarStat azarstat;
    public JoeyStat joeystat;
    public PlayerStat playerstat;

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
    //������ �߰� ��ư
    public GameObject[] lv_Up_Btn;
    int lv_Up;
    [SerializeField]
    private TextMeshProUGUI use_lv_up;

    public GameObject lucy_eq1;
    public GameObject lucy_eq2;
    public GameObject azar_eq1;
    public GameObject azar_eq2;
    public GameObject joey_eq1;
    public GameObject joey_eq2;

    [SerializeField]
    private GameObject rest_cvs;

    Vector3 mousepos; //���콺 ������

    public Inventory inventory;

    //���� �޽��� ���
    public GameObject azar_RT_obj;
    public GameObject joey_RT_obj;
    public GameObject azar_RET_obj;
    public GameObject joey_RET_obj;

    public TextMeshProUGUI azar_RT_text;
    public TextMeshProUGUI joey_RT_text;
    public TextMeshProUGUI azar_RET_text;
    public TextMeshProUGUI joey_RET_text;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
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
        use_lv_up.text = "��밡�� ���� : " + lv_Up;

        mousepos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(mousepos);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if(hit.collider != null)
            {
                int rndx = Random.Range(0, 5);
                if(hit.collider.tag == "ItemBox")
                {
                    inventory.AddItem(ItemDataManager.Instance.items[rndx]);
                    Destroy(hit.collider);
                    Debug.Log("������ȹ��");
                }
                else if(hit.collider.tag == "Rest")
                {
                    Debug.Log("�޽�");
                    Destroy(hit.collider);
                    rest_cvs.SetActive(true);
                }
            }
        }
    }
    //���� ��ư ����
    public void Lucy_info_Click()
    {
        player_info_img.sprite = info_chr_img[0];
        if (playerstat.hp >= playerstat.max_hp) //ü���� �ִ�� �÷��̾� ������ �ִ�ü������
        {
            playerstat.hp = playerstat.max_hp;
        }
        info_Name_text.text = "�� ��";
        info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : " 
            + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        indexNum = 0;
        lucy_eq1.SetActive(true);
        lucy_eq2.SetActive(true);
        azar_eq1.SetActive(false);
        azar_eq2.SetActive(false);
        joey_eq1.SetActive(false);
        joey_eq2.SetActive(false);
    }

    public void Azar_info_Click()
    {
        player_info_img.sprite = info_chr_img[1];
        if (azarstat.hp >= azarstat.max_hp)
        {
            azarstat.hp = azarstat.max_hp;
        }
        info_Name_text.text = "���ڸ�";
        info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : " 
            + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        indexNum = 1;
        lucy_eq1.SetActive(false);
        lucy_eq2.SetActive(false);
        azar_eq1.SetActive(true);
        azar_eq2.SetActive(true);
        joey_eq1.SetActive(false);
        joey_eq2.SetActive(false);
    }

    public void Joey_info_Click()
    {
        player_info_img.sprite = info_chr_img[2];
        if (joeystat.hp >= joeystat.max_hp)
        {
            joeystat.hp = joeystat.max_hp;
        }
        info_Name_text.text = "�� ��";
        info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : " 
            + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        indexNum = 2;
        lucy_eq1.SetActive(false);
        lucy_eq2.SetActive(false);
        azar_eq1.SetActive(false);
        azar_eq2.SetActive(false);
        joey_eq1.SetActive(true);
        joey_eq2.SetActive(true);
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
            playerstat.hp += 3;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.max_hp += 3;
            azarstat.hp += 3;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
    + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.max_hp += 3;
            joeystat.hp += 3;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }
    }

    public void Str_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.str += 1;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.str += 1;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
    + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.str += 1;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }
    }

    public void Def_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.def += 1;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.def += 1;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
    + azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.def += 1;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }
    }

    public void Spd_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.speed += 1;
            info_Chr_text.text = "���� ü�� : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "���ݷ� : " + playerstat.str + "\n\n" + "���� : "
    + playerstat.def + "\n\n" + "�ӵ� : " + playerstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.speed += 1;
            info_Chr_text.text = "���� ü�� : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "���ݷ� : " + azarstat.str + "\n\n" + "���� : "
+ azarstat.def + "\n\n" + "�ӵ� : " + azarstat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.speed += 1;
            info_Chr_text.text = "���� ü�� : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "���ݷ� : " + joeystat.str + "\n\n" + "���� : "
    + joeystat.def + "\n\n" + "�ӵ� : " + joeystat.speed + "\n\n\n" + "��� ������ �߰� ���� : " + lv_Up;
        }
    }

    public void Azar_Rnd_Text()
    {
        int x;
        x = Random.Range(0, 3);
        if(x == 0)
        {
            azar_RT_text.text = "���ѷ� � ����";
        }
        else if(x == 1)
        {
            azar_RT_text.text = "����� ���� ���������� �𸣰ڱ�..";
        }
        else
        {
            azar_RT_text.text = "��¾�� ������ ������ ���..";
        }
        azar_RT_obj.SetActive(true);
        Invoke("Reset_Rnd_Obj", 2f);
    }
    public void Joey_Rnd_Text()
    {
        int x;
        x = Random.Range(0, 3);
        if (x == 0)
        {
            joey_RT_text.text = "�� �۶����� �ִ°ž�?";
        }
        else if (x == 1)
        {
            joey_RT_text.text = "�ڴ� ������ �ñ��";
        }
        else
        {
            joey_RT_text.text = "�������� �����ΰ�..";
        }
        joey_RT_obj.SetActive(true);
        Invoke("Reset_Rnd_Obj", 2f);
    }
    public void Azar_Rnd_Enemy_Text()
    {
        int x;
        x = Random.Range(0, 3);
        if (x == 0)
        {
            azar_RET_text.text = "���� �̴�� ����";
        }
        else if (x == 1)
        {
            azar_RET_text.text = "�̱� �� �ְھ�..!";
        }
        else
        {
            azar_RET_text.text = "���Ҿ�!";
        }
        azar_RET_obj.SetActive(true);
        Invoke("Reset_Rnd_Obj", 2f);
    }
    public void Joey_Rnd_Enemy_Text()
    {
        int x;
        x = Random.Range(0, 3);
        if (x == 0)
        {
            joey_RT_text.text = "���� ������?";
        }
        else if (x == 1)
        {
            joey_RT_text.text = "���Ҿ�!";
        }
        else
        {
            joey_RT_text.text = "�̺� �̰� �پ�?";
        }
        joey_RET_obj.SetActive(true);
        Invoke("Reset_Rnd_Obj", 2f);
    }

    public void Reset_Rnd_Obj()
    {
        azar_RT_obj.SetActive(false);
        joey_RT_obj.SetActive(false);
        azar_RET_obj.SetActive(false);
        joey_RET_obj.SetActive(false);
    }
}
