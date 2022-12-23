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
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }

    public void UseItem(Item _item)
    {
        if (_item.itemType == Item.ItemType.Equipment) //���� ������
        {
            
        }
        else if(_item.itemType == Item.ItemType.Used) //��������
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
