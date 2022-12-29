using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Slot[] slots;

    public Slot[] eqslots;

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

    public void RemoveItem(Item _item)
    {
        items.Remove(_item);
        FreshSlot();
    }

    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            _item.itemValue++;
            FreshSlot();
        }
        else
        {
            print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }
}
