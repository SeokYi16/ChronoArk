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

    private FightMananger FM;

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
    //정보 버튼 구현
    public void Lucy_info_Click()
    {
        player_info_img.sprite = info_chr_img[0];
        info_Name_text.text = "루 시";
        info_Chr_text.text = "남은 체력 : " + playerstat.hp + "\n\n" + "공격력 : " + playerstat.str + "\n\n" + "방어력 : " + playerstat.def + "\n\n" + "속도 : " + playerstat.speed;
    }

    public void Azar_info_Click()
    {
        player_info_img.sprite = info_chr_img[1];
        info_Name_text.text = "아자르";
        info_Chr_text.text = "남은 체력 : " + azarstat.hp + "\n\n" + "공격력 : " + azarstat.str + "\n\n" + "방어력 : " + azarstat.def + "\n\n" + "속도 : " + azarstat.speed;
    }

    public void Joey_info_Click()
    {
        player_info_img.sprite = info_chr_img[2];
        info_Name_text.text = "조 이";
        info_Chr_text.text = "남은 체력 : " + joeystat.hp + "\n\n" + "공격력 : " + joeystat.str + "\n\n" + "방어력 : " + joeystat.def + "\n\n" + "속도 : " + joeystat.speed;
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
        FM = FindObjectOfType<FightMananger>();
        FM.FirstTurn(playerstat.speed, azarstat.speed, joeystat.speed); //속도 후 계산방법은?
    }

    public void Enemy_Panel_Close()
    {
        enemy_panel.SetActive(false);
        isEnemy_Fight = false;
    }
}
