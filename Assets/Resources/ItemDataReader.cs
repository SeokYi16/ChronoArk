using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDataReader : MonoBehaviour
{
    static ItemDataReader instance = null;
    // Start is called before the first frame update
    List<Dictionary<string, object>> itemData;//아이템 데이터
    [SerializeField] GameObject buttonPrefab; //복사해서 배치될 버튼 스크립트
    [SerializeField] int totalItemCount; //아이템 개수
    public Sprite[] itemIcon; //아이템 아이콘 등록
    public int[] getItemValue;// 각 아이템의 가진 개수
    [SerializeField] Transform ItemBox; //아이템들이 배치될 박스의 트랜스폼
    [SerializeField] Vector2 itemSize; //행 간격
    [SerializeField] TextMeshProUGUI infoText; //행 간격
    public GameObject infoWindow;
    int rowCount;

    void Awake()
    {
        instance = this; //싱글톤 활성화
        itemData = CSVReader.Read("ItemData");
        itemSize = buttonPrefab.GetComponent<RectTransform>().sizeDelta;
        ItemSetting();
    }

    void ItemSetting()
    {
        for (int i = 0; i < totalItemCount; i++)
        {
            GameObject Item = Instantiate(buttonPrefab, Vector3.zero, transform.rotation, ItemBox);
            Debug.Log("Item = " + Item.name);
            ////데이터 입력시키기
            Item.name = "Item_" + i; //이름 부여
            Item.GetComponent<Inventory>().itemID = i;
            Item.GetComponent<Inventory>().icon.sprite = itemIcon[iconNo(i)];
            Item.GetComponent<Inventory>().infoWindow = infoWindow;
            Item.GetComponent<Inventory>().hungry = itemhungry(i);
            Item.GetComponent<Inventory>().hp = itemhp(i);
            Item.GetComponent<Inventory>().str = itemstr(i);
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
        string itemDes = (string)itemData[index]["itemDes"].ToString();
        return itemDes;
    }

    public float itemhp(int index)
    {
        float itemhp = float.Parse(itemData[index]["hp"].ToString());
        return itemhp;
    }

    public float itemhungry(int index)
    {
        float itemhungry = float.Parse(itemData[index]["hungry"].ToString());
        return itemhungry;
    }

    public float itemstr(int index)
    {
        float itemstr = float.Parse(itemData[index]["str"].ToString());
        return itemstr;
    }
    public void ItemInfo(int itemID)
    {
        infoText.text = itemName(itemID) + '\n' +itemDes(itemID) +
        '\n' + '\n' + "보유 :" + getItemValue[itemID].ToString();
    }

}
