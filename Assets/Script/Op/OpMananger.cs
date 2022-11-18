using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpMananger : MonoBehaviour
{
    public GameObject panel_Menu;

    public GameObject Start_Menu_Panel;
    public Image Start_Menu_Img;

    public Image start_btn;
    public Image option_btn;
    public Image exit_btn;

    public Sprite[] preview_Chr_Sprite;
    public Sprite[] preview_Icon_Sprite;

    public Image preview_Chr;
    public Image preview_Icon;

    public TextMeshProUGUI preview_Text;
    public TextMeshProUGUI preview_Name;

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

    public void Azar_Onclick()
    {
        preview_Chr.sprite = preview_Chr_Sprite[0];
        preview_Icon.sprite = preview_Icon_Sprite[0];
        preview_Chr.SetNativeSize();
        preview_Text.text = "아자르는 어떠한 상황이라도 당황하지 않고 능숙하게 대처하여 조사단의 많은 기대를 받고있으며 따르는 자도 많습니다. \n 주로 환영검을 활용해 적을 공격하는 데미지 딜러입니다.";
        preview_Name.text = "아자르";
    }

    public void Joey_Onclick()
    {
        preview_Chr.sprite = preview_Chr_Sprite[1];
        preview_Icon.sprite = preview_Icon_Sprite[1];
        preview_Chr.SetNativeSize();
        preview_Text.text = "연구소에서 특수 장비 제작으로 활약하던 천재 화학자 조이는 상황이 나아지지 않자 직접 뒤집힌 땅으로 향합니다. \n 각종 버프, 디버프로 아군을 돕거나 적을 괴롭힐 수 있습니다.";
        preview_Name.text = "조이";
    }
}
