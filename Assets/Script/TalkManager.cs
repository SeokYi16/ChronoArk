using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkManager : MonoBehaviour
{
    private static TalkManager instance = null;

    List<Dictionary<string, object>> talkData;//대화 데이터

    public GameObject talkPanel;

    public TextMeshProUGUI talk_text;
    public TextMeshProUGUI talk_name_text;
    public Image[] talk_img;
    [SerializeField]
    private Image talking_npc;

    public int i = 0;
    //콜라이더 파괴를 위한 오브젝트 선언
    public GameObject talk_obj;
    public bool isTalking;
    Inventory inventory;

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
        talkData = CSVReader.Read("TalkData");
        isTalking = false;
    }

    public static TalkManager Instance
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


    public int TextNum(int index)
    {
        int TextNum = int.Parse(talkData[index]["TextNum"].ToString());
        return TextNum;
    }

    public int TextImg(int index)
    {
        int TextImg = int.Parse(talkData[index]["TextImg"].ToString());
        return TextImg;
    }

    public string TextName(int index)
    {
        string TextName = (string)talkData[index]["TextName"].ToString(); ;
        return TextName;
    }

    public string TextDesk(int index)
    {
        string TextDesk = (string)talkData[index]["TextDesk"].ToString(); ;
        return TextDesk;
    }


    public void Npc_Rian_Talk()
    {
        talkPanel.SetActive(true);
        talk_name_text.text = TextName(i);//0번부터 나오게 실행
        talk_text.text = TextDesk(i);
        i++;
    }

    public void Npc_Rian_Talking() //버튼 클릭시 다음으로 넘김
    {
        if (i <= 5)
        {
            talk_name_text.text = TextName(i);
            talk_text.text = TextDesk(i);
            i++;
        }
        else if (i == 6)
        {
            Destroy(talk_obj.gameObject);
            talkPanel.SetActive(false);
            isTalking = false;
        }
    }
}
