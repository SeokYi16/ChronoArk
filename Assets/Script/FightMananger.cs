using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class FightMananger : MonoBehaviour
{
    private static FightMananger instance = null;

    static EnemySpawn enemySpawn;
    Enemy em;

    //턴 슬라이드 바
    public Slider player_TurnSlider;
    public Slider azar_TurnSlider;
    public Slider joey_TurnSlider;
    // 스킬 턴 텍스트
    public TextMeshProUGUI player_turncount_text;
    public TextMeshProUGUI azar_turncount_text;
    public TextMeshProUGUI joey_turncount_text;
    // 스킬 턴 카운트
    public int player_turncount;
    public int azar_turncount;
    public int joey_turncount;
    // 스텟
    public PlayerStat playerStat;
    public AzarStat azarStat;
    public JoeyStat joeyStat;
    // 적들의 턴 슬라이드와 아이콘 이미지
    public Slider[] enemys_TurnSlider;
    public Image[] enemy_Slider_icon;
    // 턴 표기 화살표
    public GameObject[] turn_arrow;
    //턴이 시작됨을 알림
    public bool turn_start = false;
    //적 오브젝트 받는 그릇
    public List<GameObject> enemy_gameObjects;

    public List<EnemyInfo> enemy_info;
    //정보를 받았는지 확인
    bool info_on = false;
    //공격 클릭 확인
    bool player_atk_click = false;
    bool azar_atk_click = false;
    bool joey_atk_click = false;
    //캔버스 레이캐스트 (캔버스에서는 GraphicRaycaster를 사용해야함/ 그 외는 Raycast로 가능)
    [SerializeField] private GameObject canvas;
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;
    public GameObject atk_panel;

    //게임 결과 캔버스
    [SerializeField]
    private GameObject win_cvs;
    [SerializeField]
    private GameObject over_cvs;

    public bool use_win_cvs = false;

    public GameObject test;

    public Sprite[] hits_ani;

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

        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
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
            if (!info_on)
            {
                Enemy_Info_obj();
            }
            SliderCount();
        }

        if (enemy_gameObjects == null) //적 오브젝트 배열이 없으면 싸움상태 초기화
        {
            GameManager.Instance.isEnemy_Fight = false;
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

        Joey_Skill_2_Use();
        Azar_Skill_2_Use();
        Player_Skill_2_Use();

        if(enemy_gameObjects.Count == 0) //몬스터 오브젝트 배열이 0개면 실행
        {
            GameManager.Instance.Enemy_Panel_Close(); //몬스터 패널 닫기
            info_on = false; //몬스터 정보 담아오기 초기화
            azar_TurnSlider.value = 99.99f; //턴슬라이드 초기화
            joey_TurnSlider.value = 99.98f;
            player_TurnSlider.value = 99.97f;
            if (use_win_cvs)
            {
                win_cvs.SetActive(true); //승리 시
                use_win_cvs = false;
            }
        }

        if (playerStat.hp <= 0 && azarStat.hp <= 0 && joeyStat.hp <= 0)
        {
            over_cvs.SetActive(true); //패배 시
        }
    }

    public void WinCvsClose()
    {
        win_cvs.SetActive(false);
    }

    public void OverCvsClose()
    {
        over_cvs.SetActive(false);
    }

    void Enemy_Info_obj() //적 정보 추가
    {
        info_on = true;
        for (int i = 0; i < enemySpawn.enemy_count.Count; i++)
        {
            enemy_info.Add(enemy_gameObjects[i].GetComponent<EnemyInfo>());
        }
    }

    void SliderCount() //턴제 적용
    {
        int[] enemycount = new int[enemySpawn.enemy_count.Count];
        int[] enemystr = new int[enemySpawn.enemy_count.Count];

        for (int i = 0; i < enemy_info.Count; i++) //적이 죽을 시 슬라이드 오브젝트 삭제 및 리스트 제거
        {
            if(enemy_info[i].enemyhp <= 0)
            {
                enemys_TurnSlider[i +1].gameObject.SetActive(false);
                enemy_gameObjects.Remove(enemy_gameObjects[i]);
                enemy_info.Remove(enemy_info[i]);
                enemySpawn.enemy_count.Remove(enemySpawn.enemy_count[i]);
            }
            else
            {

            }
        }

        for (int i = 0; i < enemy_info.Count; i++)
        {
            enemycount[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemyspd; //적 스피드를 담음
            enemystr[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemystr; // 적 공격력을 담음
            enemy_Slider_icon[i].sprite = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemy_slier_icon; // 아이콘 핸들 변경
            enemys_TurnSlider[i].gameObject.SetActive(true); // 적의 수만큼 슬라이더 오브젝트 실행
        }

        if (!turn_start)
        {
            if(playerStat.hp > 0)
            {
                player_TurnSlider.value -= Time.deltaTime * 10 * playerStat.speed;
                player_TurnSlider.gameObject.SetActive(true);
            }
            else
            {
                player_TurnSlider.gameObject.SetActive(false);
            }
            if(azarStat.hp > 0)
            {
                azar_TurnSlider.value -= Time.deltaTime * 10 * azarStat.speed;
            }
            else
            {
                azar_TurnSlider.gameObject.SetActive(false);
            }
            if (joeyStat.hp > 0)
            {
                joey_TurnSlider.value -= Time.deltaTime * 10 * joeyStat.speed;
            }
            else
            {
                joey_TurnSlider.gameObject.SetActive(false);
            }

            for (int i = 0; i < enemySpawn.enemy_count.Count; i++)
            {
                enemys_TurnSlider[i].value -= Time.deltaTime * 10 * enemycount[i];

                if(enemys_TurnSlider[i].value <= 0) //적이 속도가 다 되면 공격
                {
                    int x = Random.Range(0, 3); //처음 공격대상 지정
                    switch (x)
                    {
                        case 0:
                            if (playerStat.hp <= 0) //공격 대상의 체력이 0이면 다음 대상을 찾음
                            {
                                player_TurnSlider.gameObject.SetActive(false);
                                if(azarStat.hp >= 0)
                                {
                                    azarStat.hp += -enemystr[i] + azarStat.def;
                                }
                                else
                                {
                                    joeyStat.hp += -enemystr[i] + joeyStat.def;
                                }
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
                                azar_TurnSlider.gameObject.SetActive(false);
                                if (playerStat.hp >= 0)
                                {
                                    playerStat.hp += -enemystr[i] + playerStat.def;
                                }
                                else
                                {
                                    joeyStat.hp += -enemystr[i] + joeyStat.def;
                                }
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
                                joey_TurnSlider.gameObject.SetActive(false);
                                if (playerStat.hp >= 0)
                                {
                                    playerStat.hp += -enemystr[i] + playerStat.def;
                                }
                                else
                                {
                                    azarStat.hp += -enemystr[i] + azarStat.def;
                                }
                            }
                            else
                            {
                                joeyStat.hp += -enemystr[i] + joeyStat.def;
                            }
                            enemys_TurnSlider[i].value = 100;

                            //enemy_gameObjects[i].GetComponent<EnemyInfo>().Monster_Atk(); //플레이어를 공격하는 적(다른방법)
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
            if(player_TurnSlider.value <= 0) //그 캐릭터의 턴이면 화살표 표기
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

    public void Azar_Skill_1() // 특별스킬
    {
        if(azar_TurnSlider.value <= 0 && azar_turncount == 0) //턴슬라이드와 스킬 쿨타임이 0일시 공격가능
        {
            for(int i = 0; i < enemy_info.Count; i++)
            {
                enemy_info[i].enemyhp += -azarStat.str * 2 + enemy_info[i].enemydef;
            }
            turn_start = false;
            azar_TurnSlider.value = 99.99f;
            azar_turncount = 0;
            turn_arrow[1].SetActive(false);
        }
    }

    public void Azar_Skill_2() //일반 스킬
    {
        if (azar_TurnSlider.value <= 0)
        {
            azar_atk_click = true;
            atk_panel.SetActive(true);
        }
    }

    public void Azar_Skill_2_Use() // 클릭 후 상대 클릭 시
    {
        if (azar_atk_click) //한번 클릭 후 대상 클릭 시
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem); //  이벤트 시스템을 담을 변수 선언

                m_PointerEventData.position = Input.mousePosition; // 이벤트 시스템의 좌표는 마우스 좌표

                List<RaycastResult> results = new List<RaycastResult>(); //List에 RaycastRsult를 선언

                m_Raycaster.Raycast(m_PointerEventData, results); //담기는 좌표와 결과를 담음

                GameObject hitobj = results[0].gameObject; //담기는 결과의 게임오브젝트를 담음
                if (hitobj.CompareTag("Monster")) //그 담긴 오브젝트 태그가 몬스터일시 실행
                {
                    hitobj.gameObject.GetComponent<EnemyInfo>().enemyhp += -azarStat.str + hitobj.gameObject.GetComponent<EnemyInfo>().enemydef;
                    Debug.Log("몬스터 클릭");
                    atk_panel.SetActive(false); //선택 패널 닫기
                    azar_atk_click = false; //공격 후 턴 초기화
                    turn_start = false;
                    azar_TurnSlider.value = 99.99f;
                    azar_turncount--;
                    turn_arrow[1].SetActive(false);

                    test.transform.position = hitobj.gameObject.transform.position;
                    Debug.Log(hitobj.gameObject.transform.position);
                }
                else
                {
                    Debug.Log("몬스터 안클릭");
                }
            }
            else if (Input.GetMouseButtonDown(1)) //오른쪽 클릭시 공격 취소
            {
                azar_atk_click = false;
                atk_panel.SetActive(false);

                //여기에 EnemyInfo의 정보의 포지션값을 가져올것!
            }
        }
    }

    public void Joey_Skill_1() // 특별 스킬
    {
        if (joey_TurnSlider.value <= 0 && joey_turncount == 0)
        {
            turn_start = false;
            joey_TurnSlider.value = 99.98f;
            playerStat.hp += joeyStat.str;
            azarStat.hp += joeyStat.str;
            joeyStat.hp += joeyStat.str;
            joey_turncount = 3;
            turn_arrow[2].SetActive(false);
        }
    }

    public void Joey_Skill_2()
    {
        if (joey_TurnSlider.value <= 0)
        {
            joey_atk_click = true;
            atk_panel.SetActive(true);
        }
    }

    public void Joey_Skill_2_Use()
    {
        if (joey_atk_click)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);

                m_PointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                m_Raycaster.Raycast(m_PointerEventData, results);

                GameObject hitobj = results[0].gameObject;
                if (hitobj.CompareTag("Monster"))
                {
                    hitobj.gameObject.GetComponent<EnemyInfo>().enemyhp += -joeyStat.str + hitobj.gameObject.GetComponent<EnemyInfo>().enemydef;
                    Debug.Log("몬스터 클릭");
                    atk_panel.SetActive(false);
                    joey_atk_click = false;
                    turn_start = false;
                    joey_TurnSlider.value = 99.98f;
                    joey_turncount--;
                    turn_arrow[2].SetActive(false);
                }
                else
                {
                    Debug.Log("몬스터 안클릭");
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                joey_atk_click = false;
                atk_panel.SetActive(false);
            }
        }
    }

    public void Player_Skill_1() //특별스킬
    {
        if (player_TurnSlider.value <= 0 && player_turncount == 0)
        {
            for (int i = 0; i < enemySpawn.enemy_count.Count; i++)
            {
                enemy_info[i].enemyhp += -playerStat.str + enemy_info[i].enemydef;
                enemys_TurnSlider[i].value += 15;
            }
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
            player_atk_click = true;
            atk_panel.SetActive(true);
        }
    }

    public void Player_Skill_2_Use()
    {
        if (player_atk_click)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);

                m_PointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                m_Raycaster.Raycast(m_PointerEventData, results);

                GameObject hitobj = results[0].gameObject;
                if (hitobj.CompareTag("Monster"))
                {
                    hitobj.gameObject.GetComponent<EnemyInfo>().enemyhp += -playerStat.str + hitobj.gameObject.GetComponent<EnemyInfo>().enemydef;
                    int r = Random.Range(0, 2);
                    if (r == 0)
                    {
                        azar_TurnSlider.value -= 10f;
                    }
                    else
                    {
                        joey_TurnSlider.value -= 10f;
                    }
                    Debug.Log("몬스터 클릭");
                    atk_panel.SetActive(false);
                    player_atk_click = false;
                    turn_start = false;
                    player_TurnSlider.value = 99.97f;
                    player_turncount--;
                    turn_arrow[0].SetActive(false);
                }
                else
                {
                    Debug.Log("몬스터 안클릭");
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                player_atk_click = false;
                atk_panel.SetActive(false);
            }
        }
    }
}
