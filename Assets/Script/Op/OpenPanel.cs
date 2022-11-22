using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panel_Menu;

    public void Open_Panel()
    {
        panel_Menu.SetActive(true);
    }
}
