using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpMananger : MonoBehaviour
{
    [SerializeField]
    private GameObject panel_Menu;
    [SerializeField]
    private GameObject Start_Menu_Panel;
    [SerializeField]
    private Image Start_Menu_Img;
    [SerializeField]
    private Image start_btn;
    [SerializeField]
    private Image option_btn;
    [SerializeField]
    private Image exit_btn;
    [SerializeField]
    private Sprite[] preview_Chr_Sprite;
    [SerializeField]
    private Sprite[] preview_Icon_Sprite;
    [SerializeField]
    private Image preview_Chr;
    [SerializeField]
    private Image preview_Icon;
    [SerializeField]
    private TextMeshProUGUI preview_Text;
    [SerializeField]
    private TextMeshProUGUI preview_Name;
    [SerializeField]
    private Image Select_img_1;
    [SerializeField]
    private Image Select_img_2;
    [SerializeField]
    private GameObject Select_btn;
    [SerializeField]
    private GameObject Unselect_btn;
    [SerializeField]
    private Image UI_Mask;
    [SerializeField]
    private Image preview_chr_icon;
    [SerializeField]
    private Sprite[] preview_chr_img;

    public void Enter_Start_Btn()
    {
        start_btn.enabled = true;
    }

    public void Exit_Start_Btn()
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
        preview_chr_icon.sprite = preview_chr_img[0];
        preview_Chr.SetNativeSize();
        preview_Text.text = "���ڸ��� ��� ��Ȳ�̶� ��Ȳ���� �ʰ� �ɼ��ϰ� ��ó�Ͽ� ������� ���� ��븦 �ް������� ������ �ڵ� �����ϴ�. \n �ַ� ȯ������ Ȱ���� ���� �����ϴ� ������ �����Դϴ�.";
        preview_Name.text = "���ڸ�";
    }

    public void Joey_Onclick()
    {
        preview_Chr.sprite = preview_Chr_Sprite[1];
        preview_Icon.sprite = preview_Icon_Sprite[1];
        preview_chr_icon.sprite = preview_chr_img[1];
        preview_Chr.SetNativeSize();
        preview_Text.text = "�����ҿ��� Ư�� ��� �������� Ȱ���ϴ� õ�� ȭ���� ���̴� ��Ȳ�� �������� ���� ���� ������ ������ ���մϴ�. \n ���� ����, ������� �Ʊ��� ���ų� ���� ������ �� �ֽ��ϴ�.";
        preview_Name.text = "����";
    }

    bool isSelect1 = false;
    bool isSelect2 = false;

    public void Select_Onclick()
    {
        if (isSelect1 == false)
        {
            Select_img_1.sprite = preview_chr_icon.sprite;
            isSelect1 = true;
        }
        else
        {
            Select_img_2.sprite = preview_chr_icon.sprite;
            isSelect2 = true;
        }
    }

    public void Unselect_Onclick()
    {
        if(Select_img_1.sprite == preview_chr_icon.sprite || Select_img_2.sprite == preview_chr_icon.sprite)
        {
            Select_img_2.sprite = UI_Mask.sprite;
            isSelect2 = false;
        }
        else
        {
            Select_img_1.sprite = UI_Mask.sprite;
            isSelect1 = false;
        }
    }

}
