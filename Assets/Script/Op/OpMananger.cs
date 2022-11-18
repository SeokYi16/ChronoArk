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
        preview_Text.text = "���ڸ��� ��� ��Ȳ�̶� ��Ȳ���� �ʰ� �ɼ��ϰ� ��ó�Ͽ� ������� ���� ��븦 �ް������� ������ �ڵ� �����ϴ�. \n �ַ� ȯ������ Ȱ���� ���� �����ϴ� ������ �����Դϴ�.";
        preview_Name.text = "���ڸ�";
    }

    public void Joey_Onclick()
    {
        preview_Chr.sprite = preview_Chr_Sprite[1];
        preview_Icon.sprite = preview_Icon_Sprite[1];
        preview_Chr.SetNativeSize();
        preview_Text.text = "�����ҿ��� Ư�� ��� �������� Ȱ���ϴ� õ�� ȭ���� ���̴� ��Ȳ�� �������� ���� ���� ������ ������ ���մϴ�. \n ���� ����, ������� �Ʊ��� ���ų� ���� ������ �� �ֽ��ϴ�.";
        preview_Name.text = "����";
    }
}
