using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpMananger : MonoBehaviour
{
    public GameObject panel_Menu;

    public GameObject Start_Menu_Panel;
    public Image Start_Menu_Img;

    public Image start_btn;
    public Image option_btn;
    public Image exit_btn;

    public void OpenPanel()
    {
        panel_Menu.SetActive(true);
    }

    public void Enter_Start_Btn()
    {
        start_btn.enabled = true;
    }

    public void Eixt_Start_Btn()
    {
        start_btn.enabled = false;
    }

    public void Enter_Option_Btn()
    {
        option_btn.enabled = true;
    }

    public void Exit_Option_Btn()
    {
        option_btn.enabled = false;
    }

    public void Enter_Exit_Btn()
    {
        exit_btn.enabled = true;
    }

    public void Exit_Exit_Btn()
    {
        exit_btn.enabled = false;
    }

    public void Start_On_Click()
    {
        Start_Menu_Panel.SetActive(true);
        panel_Menu.SetActive(false);
    }
}
