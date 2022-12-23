using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{
    public enum ItemType  // 아이템 유형
    {
        Equipment,
        Used
    }

    public string itemName; // 아이템의 이름
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; // 아이템의 이미지(인벤토리 안에서 띄울)
    public string itemDes; //아이템 설명
    public int hp; //증가 시킬 스텟
    public int str;
    public int def;
    public int spd;
}
