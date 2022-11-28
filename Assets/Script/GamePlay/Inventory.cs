using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public Image icon;
    public int str;
    public int def;
    public int spd;
    public int hp;
    public string type;

    public bool isEq;

    public GameObject Item_Info_obj;
    public TextMeshProUGUI Item_Info_des;
    public int itemID;

    public void Item_Info_Open()
    {
        Item_Info_obj.SetActive(true);
        Item_Info_obj.transform.position = new Vector2(Input.mousePosition.x + 150,
            Input.mousePosition.y - 70);

        Item_Info_des.text = 
        ItemDataReader.Instance.itemName(itemID) + '\n' + ItemDataReader.Instance.itemDes(itemID) +
        '\n' + '\n' + "보유 :" + ItemDataReader.Instance.getItemValue[itemID].ToString();
    }

    public void Item_Info_Close()
    {
        Item_Info_obj.SetActive(false);
    }

    public void UseItem()
    {
        if (ItemDataReader.Instance.getItemValue[itemID] > 0)
        {
            //사용
            Debug.Log("아이템사용");
            if (type == "Used")
            {
                //GM.Instance.player.hp += hp;
                //GM.Instance.player.hungry += hungry;
                ItemDataReader.Instance.getItemValue[itemID]--;
            }
            else if (type == "ETC")
            {

            }

            else if (type == "Equipment")
            {
                if (isEq == false)
                {
                    //GM.Instance.player.str += str;
                    isEq = true;
                    //GM.Instance.eqitem.sprite = ItemDataReader.Instance.itemIcon[itemID];
                }
                else if(isEq == true)
                {
                    if(ItemDataReader.Instance.getItemValue[itemID] == ItemDataReader.Instance.getItemValue[itemID])
                    {
                        //GM.Instance.player.str -= str;
                        isEq = false;
                        //GM.Instance.eqitem.sprite = null;
                    }
                }
            }

        }
        else
        {
            //안사용
        }
    }
}
