using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightMananger : MonoBehaviour
{
    private static FightMananger instance = null;

    EnemySpawn enemySpawn;

    public Slider player_TurnSlider;
    public Slider azar_TurnSlider;
    public Slider joey_TurnSlider;

    public TextMeshProUGUI player_turncount_text;
    public TextMeshProUGUI azar_turncount_text;
    public TextMeshProUGUI joey_turncount_text;

    public int player_turncount;
    public int azar_turncount;
    public int joey_turncount;

    public PlayerStat playerStat;
    public AzarStat azarStat;
    public JoeyStat joeyStat;

    public Slider[] enemys_TurnSlider;
    public Image[] enemy_Slider_icon;

    public GameObject[] turn_arrow;

    public bool turn_start = false;

    //public GameObject[] gameObjects;

    private void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
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

    public static FightMananger Instance
    {//싱글톤
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.isEnemy_Fight)
        {
            SliderCount();
        }
        //플레이어 스킬 턴 관리
        if(player_turncount <= 0)
        {
            player_turncount = 0;
            player_turncount_text.text = null;
        }
        else
        {
            player_turncount_text.text = player_turncount.ToString();
        }

        if (azar_turncount <= 0)
        {
            azar_turncount = 0;
            azar_turncount_text.text = null;
        }
        else
        {
            azar_turncount_text.text = azar_turncount.ToString();
        }

        if (joey_turncount <= 0)
        {
            joey_turncount = 0;
            joey_turncount_text.text = null;
        }
        else
        {
            joey_turncount_text.text = joey_turncount.ToString();
        }
    }

    void SliderCount()
    {
        int[] enemycount = new int[enemySpawn.enemy_count.Count];
        int[] enemystr = new int[enemySpawn.enemy_count.Count];
        
        for (int i = 0; i < enemySpawn.enemy_count.Count; i++)
        {
            enemycount[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemyspd; //적 스피드를 담음
            enemystr[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemystr;
            enemy_Slider_icon[i].sprite = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemy_slier_icon; // 아이콘 핸들 변경
            enemys_TurnSlider[i].gameObject.SetActive(true); // 적의 수만큼 슬라이더 오브젝트 실행
        }

        if (!turn_start)
        {
            player_TurnSlider.value -= Time.deltaTime * 10 * playerStat.speed;
            azar_TurnSlider.value -= Time.deltaTime * 10 * azarStat.speed;
            joey_TurnSlider.value -= Time.deltaTime * 10 * joeyStat.speed;
            for (int i = 0; i < enemySpawn.enemy_count.Count; i++)
            {
                enemys_TurnSlider[i].value -= Time.deltaTime * 10 * enemycount[i];

                if(enemys_TurnSlider[i].value <= 0) //적이 속도가 다 되면 공격
                {
                    int x = Random.Range(0, 2);
                    switch (x)
                    {
                        case 0:
                            if (playerStat.hp <= 0)
                            {
                                azarStat.hp += -enemystr[i] + azarStat.def;
                            }
                            else
                            {
                                playerStat.hp += -enemystr[i] + playerStat.def;
                            }
                            enemys_TurnSlider[i].value = 100;
                            break;
                        case 1:
                            if(azarStat.hp <= 0)
                            {
                                joeyStat.hp += -enemystr[i] + joeyStat.def;
                            }
                            else
                            {
                                azarStat.hp += -enemystr[i] + azarStat.def;
                            }
                            enemys_TurnSlider[i].value = 100;
                            break;
                        case 2:
                            if(joeyStat.hp <= 0)
                            {
                                playerStat.hp += -enemystr[i] + playerStat.def;
                            }
                            else
                            {
                                joeyStat.hp += -enemystr[i] + joeyStat.def;
                            }
                            enemys_TurnSlider[i].value = 100;
                            //gameObjects[i].GetComponent<EnemyInfo>().Monster_Atk(); 플레이어를 공격하는 적(다른방법)
                            break;
                    }
                }
            }
        }
        else
        {

        }

        if(player_TurnSlider.value <= 0 || azar_TurnSlider.value <= 0 || joey_TurnSlider.value <=0) //아군 캐릭터가 속도가 다 차면 잠깐 멈추고 공격가능하게 만들기
        {
            turn_start = true;
            if(player_TurnSlider.value <= 0)
            {
                turn_arrow[0].SetActive(true);
            }
            if (azar_TurnSlider.value <= 0)
            {
                turn_arrow[1].SetActive(true);
            }
            if (joey_TurnSlider.value <= 0)
            {
                turn_arrow[2].SetActive(true);
            }
        }
        else
        {
            turn_start = false;
        }

    }

    public void Azar_Skill_1()
    {
        if(azar_TurnSlider.value <= 0 && azar_turncount == 0)
        {
            turn_start = false;
            azar_TurnSlider.value = 99.99f;
            azar_turncount = 2;
            turn_arrow[1].SetActive(false);
        }
    }

    public void Azar_Skill_2()
    {
        if (azar_TurnSlider.value <= 0)
        {
            turn_start = false;
            azar_TurnSlider.value = 99.99f;
            azar_turncount--;
            turn_arrow[1].SetActive(false);
        }
    }

    public void Joey_Skill_1()
    {
        if (joey_TurnSlider.value <= 0 && joey_turncount == 0)
        {
            turn_start = false;
            joey_TurnSlider.value = 99.98f;
            playerStat.hp += 5;
            azarStat.hp += 5;
            joeyStat.hp += 5;
            joey_turncount = 3;
            turn_arrow[2].SetActive(false);
        }
    }

    public void Joey_Skill_2()
    {
        if (joey_TurnSlider.value <= 0)
        {
            turn_start = false;
            joey_TurnSlider.value = 99.98f;
            joey_turncount--;
            turn_arrow[2].SetActive(false);
        }
    }

    public void Player_Skill_1()
    {
        if (player_TurnSlider.value <= 0 && player_turncount == 0)
        {
            turn_start = false;
            player_TurnSlider.value = 99.97f;
            player_turncount = 2;
            turn_arrow[0].SetActive(false);
        }
    }

    public void Player_Skill_2()
    {
        if (player_TurnSlider.value <= 0)
        {
            turn_start = false;
            player_TurnSlider.value = 99.97f;
            player_turncount--;
            turn_arrow[0].SetActive(false);
        }
    }
}
