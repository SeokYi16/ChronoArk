using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    public GameObject Item_Info_obj;
    public TextMeshProUGUI Item_Info_des;

    public int itemID;

    public void Item_Info_Open()
    {
        Item_Info_obj.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Item_Info_des.text = ItemDataReader.Instance.itemDes(itemID);
    }
}
