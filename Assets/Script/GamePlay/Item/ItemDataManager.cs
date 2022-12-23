using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDataManager : MonoBehaviour
{
    private static ItemDataManager instance = null;

    [SerializeField]
    Image eqimg1;
    [SerializeField]
    Image eqimg2;

    public bool iseq1;
    public bool iseq2;

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
        iseq1 = false;
        iseq2 = false;
    }

    public static ItemDataManager Instance
    {//ΩÃ±€≈Ê
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
        if (!iseq1)
        {
            eqimg1.color = new Color(1, 1, 1, 0);
        }
        else
        {
            eqimg1.color = new Color(1, 1, 1, 1);
        }

        if (!iseq2)
        {
            eqimg2.color = new Color(1, 1, 1, 0);
        }
        else
        {
            eqimg2.color = new Color(1, 1, 1, 1);
        }
    }
}
