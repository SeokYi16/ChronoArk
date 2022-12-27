using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;

    public TextMeshProUGUI itemDes;

    private Item _item;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void Enter_ItemDes() //������ ���� Ȯ�� �̺�Ʈ Ʈ���� ��� ���콺 ���� ��
    {
        if(_item != null)
        {
            itemDes.text = item.itemName + "\n" + item.itemValue + "��" +"\n\n" + item.itemDes;
        }
        else
        {
            itemDes.text = " ";
        }
    }

    public void Exit_ItemDes() // ���콺���� ��� ��
    {
        itemDes.text = " ";
    }


    public void UseItem() //������ ��� ��
    {
        if(_item != null)
        {
            if (_item.itemType == Item.ItemType.Equipment) //���� ������
            {
                Debug.Log("������ ���");
                if(ItemDataManager.Instance.index_num == 0) //������Ʈ �ٽ� ���� �۵���Ű��
                {
                    if (!ItemDataManager.Instance.lucy_iseq1)
                    {
                        ItemDataManager.Instance.eqimg1.sprite = _item.itemImage;
                        ItemDataManager.Instance.lucy_iseq1 = true;
                    }
                    else if(!ItemDataManager.Instance.lucy_iseq2)
                    {
                        ItemDataManager.Instance.eqimg2.sprite = _item.itemImage;
                        ItemDataManager.Instance.lucy_iseq2 = true;
                    }
                    else
                    {
                        //������ �� ��
                    }
                }
                else if (ItemDataManager.Instance.index_num == 1)
                {
                    if (!ItemDataManager.Instance.azar_iseq1)
                    {
                        ItemDataManager.Instance.eqimg1.sprite = _item.itemImage;
                        ItemDataManager.Instance.azar_iseq1 = true;
                    }
                    else if (!ItemDataManager.Instance.azar_iseq2)
                    {
                        ItemDataManager.Instance.eqimg2.sprite = _item.itemImage;
                        ItemDataManager.Instance.azar_iseq2 = true;
                    }
                    else
                    {
                        //������ �� ��
                    }
                }
                else if (ItemDataManager.Instance.index_num == 2)
                {
                    if (!ItemDataManager.Instance.joey_iseq1)
                    {
                        ItemDataManager.Instance.eqimg1.sprite = _item.itemImage;
                        ItemDataManager.Instance.joey_iseq1 = true;
                    }
                    else if (!ItemDataManager.Instance.azar_iseq2)
                    {
                        ItemDataManager.Instance.eqimg2.sprite = _item.itemImage;
                        ItemDataManager.Instance.joey_iseq2 = true;
                    }
                    else
                    {
                        //������ �� ��
                    }
                }
            }
            else if (_item.itemType == Item.ItemType.Used) //��������
            {
                Debug.Log("������ ���");
            }
        }
        else
        {

        }
    }
}
