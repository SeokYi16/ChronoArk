using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            items.Add(_item); //아이템 추가
            _item.itemValue++; //아이템 갯수 증가


            items = items.Distinct().ToList(); //아이템 중복 제거
            /*
            List<Item> removeitems = new List<Item>();
            removeitems = removeitems.Except(items).ToList();
            */

            FreshSlot(); //슬롯 초기화
;
            /*
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemName == _item.itemName)
                {
                    Debug.Log("같은 아이템");
                    items.Remove(_item);
                    _item.itemValue++;
                }
                else
                {
                    items.Add(_item);
                    _item.itemValue++;
                    Debug.Log("다른아이템");
                }
            }
            */
        }
        else
        {
            print("슬롯이 가득 차 있습니다.");
        }
    }
}
