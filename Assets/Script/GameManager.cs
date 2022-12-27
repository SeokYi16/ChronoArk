using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    //캐릭터 스텟 정보
    [SerializeField]
    private AzarStat azarstat;
    [SerializeField]
    private JoeyStat joeystat;
    [SerializeField]
    private PlayerStat playerstat;

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

    private FightMananger FM;
    //레벨업 추가 버튼
    public GameObject[] lv_Up_Btn;
    int lv_Up;

    private void Awake()
    {//싱글톤
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
    }
    //정보 버튼 구현
    public void Lucy_info_Click()
    {
        player_info_img.sprite = info_chr_img[0];
        info_Name_text.text = "루 시";
        info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : " 
            + playerstat.def + "\n\n" + "속도 : " + playerstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        indexNum = 0;
    }

    public void Azar_info_Click()
    {
        player_info_img.sprite = info_chr_img[1];
        info_Name_text.text = "아자르";
        info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : " 
            + azarstat.def + "\n\n" + "속도 : " + azarstat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        indexNum = 1;
    }

    public void Joey_info_Click()
    {
        player_info_img.sprite = info_chr_img[2];
        info_Name_text.text = "조 이";
        info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : " 
            + joeystat.def + "\n\n" + "속도 : " + joeystat.speed + "\n\n\n" + "사용 가능한 추가 스텟 : " + lv_Up;
        indexNum = 2;
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
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.max_hp += 3;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
    + azarstat.def + "\n\n" + "속도 : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.max_hp += 3;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed;
        }
    }

    public void Str_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.str += 1;
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.str += 1;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
    + azarstat.def + "\n\n" + "속도 : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.str += 1;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed;
        }
    }

    public void Def_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.def += 1;
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.def += 1;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
    + azarstat.def + "\n\n" + "속도 : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.def += 1;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed;
        }
    }

    public void Spd_Lv_Up_Btn()
    {
        if (indexNum == 0 && lv_Up > 0)
        {
            lv_Up--;
            playerstat.speed += 1;
            info_Chr_text.text = "남은 체력 : " + playerstat.hp + "/" + playerstat.max_hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : "
    + playerstat.def + "\n\n" + "속도 : " + playerstat.speed;
        }

        if (indexNum == 1 && lv_Up > 0)
        {
            lv_Up--;
            azarstat.speed += 1;
            info_Chr_text.text = "남은 체력 : " + azarstat.hp + "/" + azarstat.max_hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : "
+ azarstat.def + "\n\n" + "속도 : " + azarstat.speed;
        }

        if (indexNum == 2 && lv_Up > 0)
        {
            lv_Up--;
            joeystat.speed += 1;
            info_Chr_text.text = "남은 체력 : " + joeystat.hp + "/" + joeystat.max_hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : "
    + joeystat.def + "\n\n" + "속도 : " + joeystat.speed;
        }
    }
}
