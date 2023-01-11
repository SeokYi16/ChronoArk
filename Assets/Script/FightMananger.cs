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

    //�� �����̵� ��
    public Slider player_TurnSlider;
    public Slider azar_TurnSlider;
    public Slider joey_TurnSlider;
    // ��ų �� �ؽ�Ʈ
    public TextMeshProUGUI player_turncount_text;
    public TextMeshProUGUI azar_turncount_text;
    public TextMeshProUGUI joey_turncount_text;
    // ��ų �� ī��Ʈ
    public int player_turncount;
    public int azar_turncount;
    public int joey_turncount;
    // ����
    public PlayerStat playerStat;
    public AzarStat azarStat;
    public JoeyStat joeyStat;
    // ������ �� �����̵�� ������ �̹���
    public Slider[] enemys_TurnSlider;
    public Image[] enemy_Slider_icon;
    // �� ǥ�� ȭ��ǥ
    public GameObject[] turn_arrow;
    //���� ���۵��� �˸�
    public bool turn_start = false;
    //�� ������Ʈ �޴� �׸�
    public List<GameObject> enemy_gameObjects;

    public List<EnemyInfo> enemy_info;
    //������ �޾Ҵ��� Ȯ��
    bool info_on = false;
    //���� Ŭ�� Ȯ��
    bool player_atk_click = false;
    bool azar_atk_click = false;
    bool joey_atk_click = false;
    //ĵ���� ����ĳ��Ʈ (ĵ���������� GraphicRaycaster�� ����ؾ���/ �� �ܴ� Raycast�� ����)
    [SerializeField] private GameObject canvas;
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;
    public GameObject atk_panel;

    //���� ��� ĵ����
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
    {//�̱���
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

        if (enemy_gameObjects == null) //�� ������Ʈ �迭�� ������ �ο���� �ʱ�ȭ
        {
            GameManager.Instance.isEnemy_Fight = false;
        }
        //�÷��̾� ��ų �� ����
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

        if(enemy_gameObjects.Count == 0) //���� ������Ʈ �迭�� 0���� ����
        {
            GameManager.Instance.Enemy_Panel_Close(); //���� �г� �ݱ�
            info_on = false; //���� ���� ��ƿ��� �ʱ�ȭ
            azar_TurnSlider.value = 99.99f; //�Ͻ����̵� �ʱ�ȭ
            joey_TurnSlider.value = 99.98f;
            player_TurnSlider.value = 99.97f;
            if (use_win_cvs)
            {
                win_cvs.SetActive(true); //�¸� ��
                use_win_cvs = false;
            }
        }

        if (playerStat.hp <= 0 && azarStat.hp <= 0 && joeyStat.hp <= 0)
        {
            over_cvs.SetActive(true); //�й� ��
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

    void Enemy_Info_obj() //�� ���� �߰�
    {
        info_on = true;
        for (int i = 0; i < enemySpawn.enemy_count.Count; i++)
        {
            enemy_info.Add(enemy_gameObjects[i].GetComponent<EnemyInfo>());
        }
    }

    void SliderCount() //���� ����
    {
        int[] enemycount = new int[enemySpawn.enemy_count.Count];
        int[] enemystr = new int[enemySpawn.enemy_count.Count];

        for (int i = 0; i < enemy_info.Count; i++) //���� ���� �� �����̵� ������Ʈ ���� �� ����Ʈ ����
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
            enemycount[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemyspd; //�� ���ǵ带 ����
            enemystr[i] = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemystr; // �� ���ݷ��� ����
            enemy_Slider_icon[i].sprite = enemySpawn.enemy_count[i].GetComponent<EnemyInfo>().enemy_slier_icon; // ������ �ڵ� ����
            enemys_TurnSlider[i].gameObject.SetActive(true); // ���� ����ŭ �����̴� ������Ʈ ����
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

                if(enemys_TurnSlider[i].value <= 0) //���� �ӵ��� �� �Ǹ� ����
                {
                    int x = Random.Range(0, 3); //ó�� ���ݴ�� ����
                    switch (x)
                    {
                        case 0:
                            if (playerStat.hp <= 0) //���� ����� ü���� 0�̸� ���� ����� ã��
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

                            //enemy_gameObjects[i].GetComponent<EnemyInfo>().Monster_Atk(); //�÷��̾ �����ϴ� ��(�ٸ����)
                            break;
                    }
                }
            }
        }
        else
        {

        }

        if(player_TurnSlider.value <= 0 || azar_TurnSlider.value <= 0 || joey_TurnSlider.value <=0) //�Ʊ� ĳ���Ͱ� �ӵ��� �� ���� ��� ���߰� ���ݰ����ϰ� �����
        {
            turn_start = true;
            if(player_TurnSlider.value <= 0) //�� ĳ������ ���̸� ȭ��ǥ ǥ��
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

    public void Azar_Skill_1() // Ư����ų
    {
        if(azar_TurnSlider.value <= 0 && azar_turncount == 0) //�Ͻ����̵�� ��ų ��Ÿ���� 0�Ͻ� ���ݰ���
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

    public void Azar_Skill_2() //�Ϲ� ��ų
    {
        if (azar_TurnSlider.value <= 0)
        {
            azar_atk_click = true;
            atk_panel.SetActive(true);
        }
    }

    public void Azar_Skill_2_Use() // Ŭ�� �� ��� Ŭ�� ��
    {
        if (azar_atk_click) //�ѹ� Ŭ�� �� ��� Ŭ�� ��
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem); //  �̺�Ʈ �ý����� ���� ���� ����

                m_PointerEventData.position = Input.mousePosition; // �̺�Ʈ �ý����� ��ǥ�� ���콺 ��ǥ

                List<RaycastResult> results = new List<RaycastResult>(); //List�� RaycastRsult�� ����

                m_Raycaster.Raycast(m_PointerEventData, results); //���� ��ǥ�� ����� ����

                GameObject hitobj = results[0].gameObject; //���� ����� ���ӿ�����Ʈ�� ����
                if (hitobj.CompareTag("Monster")) //�� ��� ������Ʈ �±װ� �����Ͻ� ����
                {
                    hitobj.gameObject.GetComponent<EnemyInfo>().enemyhp += -azarStat.str + hitobj.gameObject.GetComponent<EnemyInfo>().enemydef;
                    Debug.Log("���� Ŭ��");
                    atk_panel.SetActive(false); //���� �г� �ݱ�
                    azar_atk_click = false; //���� �� �� �ʱ�ȭ
                    turn_start = false;
                    azar_TurnSlider.value = 99.99f;
                    azar_turncount--;
                    turn_arrow[1].SetActive(false);

                    test.transform.position = hitobj.gameObject.transform.position;
                    Debug.Log(hitobj.gameObject.transform.position);
                }
                else
                {
                    Debug.Log("���� ��Ŭ��");
                }
            }
            else if (Input.GetMouseButtonDown(1)) //������ Ŭ���� ���� ���
            {
                azar_atk_click = false;
                atk_panel.SetActive(false);

                //���⿡ EnemyInfo�� ������ �����ǰ��� �����ð�!
            }
        }
    }

    public void Joey_Skill_1() // Ư�� ��ų
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
                    Debug.Log("���� Ŭ��");
                    atk_panel.SetActive(false);
                    joey_atk_click = false;
                    turn_start = false;
                    joey_TurnSlider.value = 99.98f;
                    joey_turncount--;
                    turn_arrow[2].SetActive(false);
                }
                else
                {
                    Debug.Log("���� ��Ŭ��");
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                joey_atk_click = false;
                atk_panel.SetActive(false);
            }
        }
    }

    public void Player_Skill_1() //Ư����ų
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
                    Debug.Log("���� Ŭ��");
                    atk_panel.SetActive(false);
                    player_atk_click = false;
                    turn_start = false;
                    player_TurnSlider.value = 99.97f;
                    player_turncount--;
                    turn_arrow[0].SetActive(false);
                }
                else
                {
                    Debug.Log("���� ��Ŭ��");
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
