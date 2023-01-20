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

    public void Enter_ItemDes() //������ ���� Ȯ�� �̺�Ʈ Ʈ���� ��� ���콺 ���� ��
    {
        if (_item != null)
        {
            itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
        }
        else
        {
            itemDes.text = " ";
        }
    }

    public void Exit_ItemDes() // ���콺���� ��� ��
    {
        itemDes.text = " ";
    }


    public void UseItem() //������ ��� ��
    {
        if (_item != null)
        {
            if (_item.itemType == Item.ItemType.Equipment) //���� ������
            {
                Debug.Log("������ ���");
                if (ItemDataManager.Instance.index_num == 0)
                {
                    if (!ItemDataManager.Instance.lucy_iseq1) //���� ������ �������� ����
                    {
                        inventory = FindObjectOfType<Inventory>();
                        inventory.eqslots[0].item = _item;
                        ItemDataManager.Instance.lucy_eqimg1.sprite = _item.itemImage;
                        ItemDataManager.Instance.lucy_iseq1 = true;
                        _item.itemValue--; //������ ���� �ϳ� ����
                        //���� ���� ��Ű��
                        GameManager.Instance.playerstat.max_hp += _item.hp;
                        GameManager.Instance.playerstat.str += _item.str;
                        GameManager.Instance.playerstat.def += _item.def;
                        GameManager.Instance.playerstat.speed += _item.spd;
                        if(_item.itemValue <= 0) //������ ������ 0���� �κ��丮���� ������ ����Ʈ ����
                        {
                            inventory.RemoveItem(_item);
                        }
                        //��������
                        GameManager.Instance.Lucy_info_Click();
                        if(_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
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
                        //��������
                        GameManager.Instance.Lucy_info_Click();
                        if (_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else
                    {
                        //������ �� ��
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
                        //��������
                        GameManager.Instance.Azar_info_Click();
                        if (_item.itemValue > 0)
                        {
                            itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
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
                            itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else
                    {
                        //������ �� ��
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
                            itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
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
                            itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
                        }
                        else
                        {
                            itemDes.text = null;
                        }
                    }
                    else
                    {
                        //������ �� ��
                    }
                }
            }
            else if (_item.itemType == Item.ItemType.Used) //��������
            {
                Debug.Log("������ ���");
                if (ItemDataManager.Instance.index_num == 0) //������Ʈ �ٽ� ���� �۵���Ű��
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
                        itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
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
                        itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
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
                        itemDes.text = item.itemName + "\n" + item.itemValue + "��" + "\n\n" + item.itemDes;
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
            //��������
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
            //��������
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
            //��������
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
            //��������
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
            //��������
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
            //��������
            GameManager.Instance.Joey_info_Click();
        }
    }
}