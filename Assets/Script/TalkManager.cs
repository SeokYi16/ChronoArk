using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    private static TalkManager instance = null;

    List<Dictionary<string, object>> talkData;//��ȭ ������

    public GameObject talkPanel;

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
    }

    public static TalkManager Instance
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


    public int talkNum(int index)
    {
        int itemID = int.Parse(talkData[index]["itemID"].ToString());
        return itemID;
    }

    public int talkImg(int index)
    {
        int iconNo = int.Parse(talkData[index]["iconNo"].ToString());
        return iconNo;
    }

    public string talkName(int index)
    {
        string itemType = (string)talkData[index]["itemType"].ToString(); ;
        return itemType;
    }

    public string talkDes(int index)
    {
        string itemType = (string)talkData[index]["itemType"].ToString(); ;
        return itemType;
    }


}
