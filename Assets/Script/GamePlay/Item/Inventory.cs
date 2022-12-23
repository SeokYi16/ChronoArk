using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Slot[] slots;

    public TextMeshProUGUI itemDes;

    void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 차 있습니다.");
        }
    }

    public void UseItem(Item _item)
    {
        if (_item.itemType == Item.ItemType.Equipment) //장착 아이템
        {
            
        }
        else if(_item.itemType == Item.ItemType.Used) //사용아이템
        {

        }
    }

    public void ItemDes_Enter(Item _item)
    {
        if(_item = null)
        {
            itemDes.text = " ";
        }
        else
        {
            itemDes.text = _item.itemDes;
        }
    }

    public void ItemDes_Exit()
    {
        itemDes.text = " ";
    }
}
