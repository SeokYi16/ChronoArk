using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDataManager : MonoBehaviour
{
    private static ItemDataManager instance = null;

    public List<Item> items;

    public int index_num;

    public Image lucy_eqimg1;
    public Image lucy_eqimg2;
    public Image azar_eqimg1;
    public Image azar_eqimg2;
    public Image joey_eqimg1;
    public Image joey_eqimg2;

    public bool lucy_iseq1;
    public bool lucy_iseq2;
    public bool azar_iseq1;
    public bool azar_iseq2;
    public bool joey_iseq1;
    public bool joey_iseq2;

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
        lucy_iseq1 = false;
        lucy_iseq2 = false;
        azar_iseq1 = false;
        azar_iseq2 = false;
        joey_iseq1 = false;
        joey_iseq2 = false;

        for (int i = 0; i < items.Count; i++)
        {
            items[i].itemValue = 0;
        }
    }

    public static ItemDataManager Instance
    {//½Ì±ÛÅæ
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
        index_num = GameManager.Instance.indexNum;
        Lucy_Eq();
        Azar_Eq();
        Joey_Eq();
    }

    public void Lucy_Eq() //Ä³¸¯ÅÍ ÀåÂø ¾ÆÀÌÅÛ È®ÀÎ
    {
        if (!lucy_iseq1 && index_num == 0)
        {
            lucy_eqimg1.color = new Color(1, 1, 1, 0);
        }
        else
        {
            lucy_eqimg1.color = new Color(1, 1, 1, 1);
        }

        if (!lucy_iseq2 && index_num == 0)
        {
            lucy_eqimg2.color = new Color(1, 1, 1, 0);
        }
        else
        {
            lucy_eqimg2.color = new Color(1, 1, 1, 1);
        }
    }

    public void Azar_Eq()
    {
        if (!azar_iseq1 && index_num == 1)
        {
            azar_eqimg1.color = new Color(1, 1, 1, 0);
        }
        else
        {
            azar_eqimg1.color = new Color(1, 1, 1, 1);
        }

        if (!azar_iseq2 && index_num == 1)
        {
            azar_eqimg2.color = new Color(1, 1, 1, 0);
        }
        else
        {
            azar_eqimg2.color = new Color(1, 1, 1, 1);
        }
    }

    public void Joey_Eq()
    {
        if (!joey_iseq1 && index_num == 2)
        {
            joey_eqimg1.color = new Color(1, 1, 1, 0);
        }
        else
        {
            joey_eqimg1.color = new Color(1, 1, 1, 1);
        }

        if (!joey_iseq2 && index_num == 2)
        {
            joey_eqimg2.color = new Color(1, 1, 1, 0);
        }
        else
        {
            joey_eqimg2.color = new Color(1, 1, 1, 1);
        }
    }
}
