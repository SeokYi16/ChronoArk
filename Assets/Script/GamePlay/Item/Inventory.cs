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
            items.Add(_item); //������ �߰�
            _item.itemValue++; //������ ���� ����


            items = items.Distinct().ToList(); //������ �ߺ� ����
            /*
            List<Item> removeitems = new List<Item>();
            removeitems = removeitems.Except(items).ToList();
            */

            FreshSlot(); //���� �ʱ�ȭ
;
            /*
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemName == _item.itemName)
                {
                    Debug.Log("���� ������");
                    items.Remove(_item);
                    _item.itemValue++;
                }
                else
                {
                    items.Add(_item);
                    _item.itemValue++;
                    Debug.Log("�ٸ�������");
                }
            }
            */
        }
        else
        {
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }
}
