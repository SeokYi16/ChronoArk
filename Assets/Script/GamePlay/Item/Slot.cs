using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;

    public TextMeshProUGUI itemDes;
    Inventory inventory;

    private Item _item;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void Enter_ItemDes() //아이템 정보 확인 이벤트 트리거 사용 마우스 오버 시
    {
        if (_item != null)
        {
            itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
        }
        else
        {
            itemDes.text = " ";
        }
    }

    public void Exit_ItemDes() // 마우스에서 벗어날 시
    {
        itemDes.text = " ";
    }


    public void UseItem() //아이템 사용 시
    {
        if (_item != null)
        {
            if (_item.itemType == Item.ItemType.Equipment) //장착 아이템
            {
                Debug.Log("장착템 사용");
                if (ItemDataManager.Instance.index_num == 0)
                {
                    if (!ItemDataManager.Instance.lucy_iseq1) //장착 슬롯이 비여있으면 실행
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.eqslots[0].item = _item;
                        ItemDataManager.Instance.lucy_eqimg1.sprite = _item.itemImage;
                        ItemDataManager.Instance.lucy_iseq1 = true;
                        _item.itemValue--; //아이템 갯수 하나 제거
                        //스텟 증가 시키기
                        GameManager.Instance.playerstat.max_hp += _item.hp;
                        GameManager.Instance.playerstat.str += _item.str;
                        GameManager.Instance.playerstat.def += _item.def;
                        GameManager.Instance.playerstat.speed += _item.spd;
                        if(_item.itemValue <= 0) //아이템 갯수가 0개면 인벤토리에서 아이템 리스트 제거
                        {
                            inventory.RemoveItem(_item);
                        }
                        //정보갱신
                        GameManager.Instance.Lucy_info_Click();
                        if(_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else if (!ItemDataManager.Instance.lucy_iseq2)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.eqslots[1].item = _item;
                        ItemDataManager.Instance.lucy_eqimg2.sprite = _item.itemImage;
                        ItemDataManager.Instance.lucy_iseq2 = true;
                        _item.itemValue--;
                        GameManager.Instance.playerstat.max_hp += _item.hp;
                        GameManager.Instance.playerstat.str += _item.str;
                        GameManager.Instance.playerstat.def += _item.def;
                        GameManager.Instance.playerstat.speed += _item.spd;
                        if (_item.itemValue <= 0)
                        {
                            inventory.RemoveItem(_item);
                        }
                        //정보갱신
                        GameManager.Instance.Lucy_info_Click();
                        if (_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else
                    {
                        //장착템 다 참
                    }
                }
                else if (ItemDataManager.Instance.index_num == 1)
                {
                    if (!ItemDataManager.Instance.azar_iseq1)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.eqslots[2].item = _item;
                        ItemDataManager.Instance.azar_eqimg1.sprite = _item.itemImage;
                        ItemDataManager.Instance.azar_iseq1 = true;
                        _item.itemValue--;
                        GameManager.Instance.azarstat.max_hp += _item.hp;
                        GameManager.Instance.azarstat.str += _item.str;
                        GameManager.Instance.azarstat.def += _item.def;
                        GameManager.Instance.azarstat.speed += _item.spd;
                        if (_item.itemValue <= 0)
                        {
                            inventory.RemoveItem(_item);
                        }
                        //정보갱신
                        GameManager.Instance.Azar_info_Click();
                        if (_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else if (!ItemDataManager.Instance.azar_iseq2)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.eqslots[3].item = _item;
                        ItemDataManager.Instance.azar_eqimg2.sprite = _item.itemImage;
                        ItemDataManager.Instance.azar_iseq2 = true;
                        _item.itemValue--;
                        GameManager.Instance.azarstat.max_hp += _item.hp;
                        GameManager.Instance.azarstat.str += _item.str;
                        GameManager.Instance.azarstat.def += _item.def;
                        GameManager.Instance.azarstat.speed += _item.spd;
                        if (_item.itemValue <= 0)
                        {
                            inventory.RemoveItem(_item);
                        }
                        GameManager.Instance.Azar_info_Click();
                        if (_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else
                    {
                        //장착템 다 참
                    }
                }
                else if (ItemDataManager.Instance.index_num == 2)
                {
                    if (!ItemDataManager.Instance.joey_iseq1)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.eqslots[4].item = _item;
                        ItemDataManager.Instance.joey_eqimg1.sprite = _item.itemImage;
                        ItemDataManager.Instance.joey_iseq1 = true;
                        _item.itemValue--;
                        GameManager.Instance.joeystat.max_hp += _item.hp;
                        GameManager.Instance.joeystat.str += _item.str;
                        GameManager.Instance.joeystat.def += _item.def;
                        GameManager.Instance.joeystat.speed += _item.spd;
                        if (_item.itemValue <= 0)
                        {
                            inventory.RemoveItem(_item);
                        }
                        GameManager.Instance.Joey_info_Click();
                        if (_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else if (!ItemDataManager.Instance.joey_iseq2)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.eqslots[5].item = _item;
                        ItemDataManager.Instance.joey_eqimg2.sprite = _item.itemImage;
                        ItemDataManager.Instance.joey_iseq2 = true;
                        _item.itemValue--;
                        GameManager.Instance.joeystat.max_hp += _item.hp;
                        GameManager.Instance.joeystat.str += _item.str;
                        GameManager.Instance.joeystat.def += _item.def;
                        GameManager.Instance.joeystat.speed += _item.spd;
                        if (_item.itemValue <= 0)
                        {
                            inventory.RemoveItem(_item);
                        }
                        GameManager.Instance.Joey_info_Click();
                        if (_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else
                    {
                        //장착템 다 참
                    }
                }
            }
            else if (_item.itemType == Item.ItemType.Used) //사용아이템
            {
                Debug.Log("먹을거 사용");
                if (ItemDataManager.Instance.index_num == 0) //오브젝트 다시 만들어서 작동시키기
                {
                    _item.itemValue--;
                    GameManager.Instance.playerstat.hp += _item.hp;
                    if (_item.itemValue <= 0)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.RemoveItem(_item);
                    }
                    GameManager.Instance.Lucy_info_Click();
                    if (_item.itemValue > 0)
                    {
                        itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                    }
                    else
                    {
                        itemDes.text = null;
                    }
                }
                else if (ItemDataManager.Instance.index_num == 1)
                {
                    _item.itemValue--;
                    GameManager.Instance.azarstat.hp += _item.hp;
                    if (_item.itemValue <= 0)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.RemoveItem(_item);
                    }
                    GameManager.Instance.Azar_info_Click();
                    if (_item.itemValue > 0)
                    {
                        itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                    }
                    else
                    {
                        itemDes.text = null;
                    }
                }
                else if (ItemDataManager.Instance.index_num == 2)
                {
                    _item.itemValue--;
                    GameManager.Instance.joeystat.hp += _item.hp;
                    if (_item.itemValue <= 0)
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.RemoveItem(_item);
                    }
                    GameManager.Instance.Joey_info_Click();
                    if (_item.itemValue > 0)
                    {
                        itemDes.text = item.itemName + "\n" + item.itemValue + "개" + "\n\n" + item.itemDes;
                    }
                    else
                    {
                        itemDes.text = null;
                    }
                }
                else
                {

                }
            }
        }
    }

    public void UnEq_Lucy1()
    {
        if (ItemDataManager.Instance.lucy_iseq1)
        {
            ItemDataManager.Instance.lucy_eqimg1.sprite = _item.itemImage;
            ItemDataManager.Instance.lucy_iseq1 = false;

            GameManager.Instance.playerstat.max_hp -= _item.hp;
            GameManager.Instance.playerstat.str -= _item.str;
            GameManager.Instance.playerstat.def -= _item.def;
            GameManager.Instance.playerstat.speed -= _item.spd;
            if (_item.itemValue <= 0)
            {
                inventory = FindObjectOfType<Inventory>();
                inventory.AddItem(_item);
            }
            else
            {
                _item.itemValue++;
            }

            _item = null;
            //정보갱신
            GameManager.Instance.Lucy_info_Click();
        }
    }

    public void UnEq_Lucy2()
    {
        if (ItemDataManager.Instance.lucy_iseq2)
        {
            ItemDataManager.Instance.lucy_eqimg2.sprite = _item.itemImage;
            ItemDataManager.Instance.lucy_iseq2 = false;

            GameManager.Instance.playerstat.max_hp -= _item.hp;
            GameManager.Instance.playerstat.str -= _item.str;
            GameManager.Instance.playerstat.def -= _item.def;
            GameManager.Instance.playerstat.speed -= _item.spd;
            if (_item.itemValue <= 0)
            {
                inventory = FindObjectOfType<Inventory>();
                inventory.AddItem(_item);
            }
            else
            {
                _item.itemValue++;
            }

            _item = null;
            //정보갱신
            GameManager.Instance.Lucy_info_Click();
        }
    }

    public void UnEq_Azar1()
    {
        if (ItemDataManager.Instance.azar_iseq1)
        {
            ItemDataManager.Instance.azar_eqimg1.sprite = _item.itemImage;
            ItemDataManager.Instance.azar_iseq1 = false;

            GameManager.Instance.azarstat.max_hp -= _item.hp;
            GameManager.Instance.azarstat.str -= _item.str;
            GameManager.Instance.azarstat.def -= _item.def;
            GameManager.Instance.azarstat.speed -= _item.spd;
            if (_item.itemValue <= 0)
            {
                inventory = FindObjectOfType<Inventory>();
                inventory.AddItem(_item);
            }
            else
            {
                _item.itemValue++;
            }

            _item = null;
            //정보갱신
            GameManager.Instance.Azar_info_Click();
        }
    }

    public void UnEq_Azar2()
    {
        if (ItemDataManager.Instance.azar_iseq2)
        {
            ItemDataManager.Instance.azar_eqimg2.sprite = _item.itemImage;
            ItemDataManager.Instance.azar_iseq2 = false;

            GameManager.Instance.azarstat.max_hp -= _item.hp;
            GameManager.Instance.azarstat.str -= _item.str;
            GameManager.Instance.azarstat.def -= _item.def;
            GameManager.Instance.azarstat.speed -= _item.spd;
            if (_item.itemValue <= 0)
            {
                inventory = FindObjectOfType<Inventory>();
                inventory.AddItem(_item);
            }
            else
            {
                _item.itemValue++;
            }

            _item = null;
            //정보갱신
            GameManager.Instance.Azar_info_Click();
        }
    }

    public void UnEq_Joey1()
    {
        if (ItemDataManager.Instance.joey_iseq1)
        {
            ItemDataManager.Instance.joey_eqimg1.sprite = _item.itemImage;
            ItemDataManager.Instance.joey_iseq1 = false;

            GameManager.Instance.joeystat.max_hp -= _item.hp;
            GameManager.Instance.joeystat.str -= _item.str;
            GameManager.Instance.joeystat.def -= _item.def;
            GameManager.Instance.joeystat.speed -= _item.spd;
            if (_item.itemValue <= 0)
            {
                inventory = FindObjectOfType<Inventory>();
                inventory.AddItem(_item);
            }
            else
            {
                _item.itemValue++;
            }

            _item = null;
            //정보갱신
            GameManager.Instance.Joey_info_Click();
        }
    }

    public void UnEq_Joey2()
    {
        if (ItemDataManager.Instance.joey_iseq2)
        {
            ItemDataManager.Instance.joey_eqimg2.sprite = _item.itemImage;
            ItemDataManager.Instance.joey_iseq2 = false;

            GameManager.Instance.joeystat.max_hp -= _item.hp;
            GameManager.Instance.joeystat.str -= _item.str;
            GameManager.Instance.joeystat.def -= _item.def;
            GameManager.Instance.joeystat.speed -= _item.spd;
            if (_item.itemValue <= 0)
            {
                inventory = FindObjectOfType<Inventory>();
                inventory.AddItem(_item);
            }
            else
            {
                _item.itemValue++;
            }

            _item = null;
            //정보갱신
            GameManager.Instance.Joey_info_Click();
        }
    }
}