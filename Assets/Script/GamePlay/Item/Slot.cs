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

    public void Enter_ItemDes() //아이템 정보 확인 이벤트 트리거 사용 마우스 오버 시
    {
        if(_item != null)
        {
            itemDes.text = item.itemName + "\n" + item.itemValue + "개" +"\n\n" + item.itemDes;
        }
        else
        {
            itemDes.text = " ";
        }
    }

    public void Exit_ItemDes() // 마우스에서 벗어날 시
    {
        itemDes.text = " ";
    }


    public void UseItem() //아이템 사용 시
    {
        if(_item != null)
        {
            if (_item.itemType == Item.ItemType.Equipment) //장착 아이템
            {
                Debug.Log("장착템 사용");
                if(ItemDataManager.Instance.index_num == 0) //오브젝트 다시 만들어서 작동시키기
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
                        //장착템 다 참
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
                        //장착템 다 참
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
                        //장착템 다 참
                    }
                }
            }
            else if (_item.itemType == Item.ItemType.Used) //사용아이템
            {
                Debug.Log("먹을거 사용");
            }
        }
        else
        {

        }
    }
}
