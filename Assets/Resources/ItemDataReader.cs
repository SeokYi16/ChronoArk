using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataReader : MonoBehaviour
{
    static ItemDataReader instance = null;
    List<Dictionary<string, object>> itemData;//아이템 데이터
    [SerializeField] GameObject buttonPrefab; //복사해서 배치될 버튼 스크립트
    [SerializeField] int totalItemCount; //아이템 개수
    public Sprite[] itemIcon; //아이템 아이콘 등록
    public int[] getItemValue;// 각 아이템의 가진 개수

    void Awake()
    {
        instance = this; //싱글톤 활성화
        itemData = CSVReader.Read("ItemData");
        ItemSetting();
    }

    void ItemSetting()
    {
        for (int i = 0; i < totalItemCount; i++)
        {
            GameObject Item = Instantiate(buttonPrefab, Vector3.zero, transform.rotation);
            Debug.Log("Item = " + Item.name);
            ////데이터 입력시키기
            Item.name = "Item_" + i; //이름 부여
            Item.GetComponent<Inventory>().itemID = i;
            Item.GetComponent<Inventory>().icon.sprite = itemIcon[iconNo(i)];
            Item.GetComponent<Inventory>().str = itemStr(i);
            Item.GetComponent<Inventory>().def = itemDef(i);
            Item.GetComponent<Inventory>().spd = itemSpd(i);
            Item.GetComponent<Inventory>().hp = itemHp(i);
            Item.GetComponent<Inventory>().type = itemType(i);
            Item.SetActive(true);
        }
    }

    public static ItemDataReader Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public int itemID(int index)
    {
        int itemID = int.Parse(itemData[index]["itemID"].ToString());
        return itemID;
    }

    public string itemName(int index)
    {
        string itemName = (string)itemData[index]["itemName"].ToString(); ;
        return itemName;
    }

    public int iconNo(int index)
    {
        int iconNo = int.Parse(itemData[index]["iconNo"].ToString());
        return iconNo;
    }

    public string itemType(int index)
    {
        string itemType = (string)itemData[index]["itemType"].ToString(); ;
        return itemType;
    }

    public string itemDes(int index)
    {
        string itemDes = (string)itemData[index]["itemDes"].ToString(); ;
        return itemDes;
    }

    public int itemStr(int index)
    {
        int itemStr = int.Parse(itemData[index]["itemStr"].ToString());
        return itemStr;
    }

    public int itemDef(int index)
    {
        int itemDef = int.Parse(itemData[index]["itemDef"].ToString());
        return itemDef;
    }

    public int itemSpd(int index)
    {
        int itemSpd = int.Parse(itemData[index]["itemSpd"].ToString());
        return itemSpd;
    }

    public int itemHp(int index)
    {
        int itemHp = int.Parse(itemData[index]["itemHp"].ToString());
        return itemHp;
    }

}
