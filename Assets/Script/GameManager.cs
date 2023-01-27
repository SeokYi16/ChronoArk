using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    //캐릭터 스텟 정보
    public AzarStat azarstat;
    public JoeyStat joeystat;
    public PlayerStat playerstat;

    public Sprite[] info_chr_img;

    //캐릭터 정보표시
    [SerializeField]
    private TextMeshProUGUI info_Name_text;
    [SerializeField]
    private TextMeshProUGUI info_Chr_text;
    [SerializeField]
    private Image player_info_img;
    [SerializeField]
    private GameObject player_Info;

    public int indexNum;
    //레벨업 추가 버튼
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

    Vector3 mousepos; //마우스 포지션

    public Inventory inventory;

    //랜덤 메시지 출력
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
    {//싱글톤
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
        if(lv_Up > 0) //레벨 스텟 버튼 작동
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
        use_lv_up.text = "사용가능 스텟 : " + lv_Up;

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
                    Debug.Log("아이템획득");
                }
                else if(hit.collider.tag == "Rest")
                {
                    Debug.Log("휴식");
                    Destroy(hit.collider);
                    rest_cvs.SetActive(true);
                }
            }
        }
    }
    //정보 버튼 구현
    public void Lucy_info_Click()
    {
        player_info_img.sprite = info_chr_img[0];
        if (playerstat.hp >= playerstat.max_hp) //체력이 최대면 플레이어 스텟은 최대체력으로
        {
            playerstat.hp = playerstat.max_hp;
        }
        info_Name_text.text = "루 시";
        info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : " 
            + playerstat.def + "\n\n" + "속도 : " + playerstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
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
        info_Name_text.text = "아자르";
        info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : " 
            + azarstat.def + "\n\n" + "속도 : " + azarstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
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
        info_Name_text.text = "조 이";
        info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : " 
            + joeystat.def + "\n\n" + "속도 : " + joeystat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        indexNum = 2;
        lucy_eq1.SetActive(false);
        lucy_eq2.SetActive(false);
        azar_eq1.SetActive(false);
        azar_eq2.SetActive(false);
        joey_eq1.SetActive(true);
        joey_eq2.SetActive(true);
    }
    // 정보창 클릭 시
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
        lv_Up += 6; //스텟 증가 6추가
        //FM = FindObjectOfType<FightMananger>();
        //FM.FirstTurn(playerstat.speed, azarstat.speed, joeystat.speed); //속도 후 계산방법은?
    }

    public void Enemy_Panel_Close()
    {
        enemy_panel.SetActive(false);
        isEnemy_Fight = false;
        FindObjectOfType<PlayerController>().isEnemy = false;
    }

    public void Hp_Lv_Up_Btn() //HP레벨 증가 클릭시
    {
        if(indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.max_hp += 3;
            playerstat.hp += 3;
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.max_hp += 3;
            azarstat.hp += 3;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
    + azarstat.def + "\n\n" + "속도 : " + azarstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.max_hp += 3;
            joeystat.hp += 3;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }
    }

    public void Str_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.str += 1;
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.str += 1;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
    + azarstat.def + "\n\n" + "속도 : " + azarstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.str += 1;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }
    }

    public void Def_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.def += 1;
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.def += 1;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
    + azarstat.def + "\n\n" + "속도 : " + azarstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.def += 1;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }
    }

    public void Spd_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.speed += 1;
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.speed += 1;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
+ azarstat.def + "\n\n" + "속도 : " + azarstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.speed += 1;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        }
    }

    public void Azar_Rnd_Text()
    {
        int x;
        x = Random.Range(0, 3);
        if(x == 0)
        {
            azar_RT_text.text = "서둘러 어서 가자";
        }
        else if(x == 1)
        {
            azar_RT_text.text = "여기는 조금 위험할지도 모르겠군..";
        }
        else
        {
            azar_RT_text.text = "어쩐지 위험한 느낌이 들어..";
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
            joey_RT_text.text = "뭘 멍때리고 있는거야?";
        }
        else if (x == 1)
        {
            joey_RT_text.text = "뒤는 나에게 맡기라구";
        }
        else
        {
            joey_RT_text.text = "좋지않은 느낌인걸..";
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
            azar_RET_text.text = "좋아 이대로 가자";
        }
        else if (x == 1)
        {
            azar_RET_text.text = "이길 수 있겠어..!";
        }
        else
        {
            azar_RET_text.text = "좋았어!";
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
            joey_RT_text.text = "별거 없구만?";
        }
        else if (x == 1)
        {
            joey_RT_text.text = "좋았어!";
        }
        else
        {
            joey_RT_text.text = "이봐 이게 다야?";
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
