using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    [SerializeField]
    private Image fade_panel;
    [SerializeField]
    private GameObject fade_panel_obj;
    float timer;
    float fade_timer = 2f;

    private void OnEnable()
    {
        timer = 0;
    }
    private void Update()
    {
        if (timer < fade_timer)
        {
            fade_panel.color = new Color(0, 0, 0, 1f - timer / fade_timer);
        }

        timer += Time.deltaTime;

        if(timer > 3)
        {
            fade_panel_obj.SetActive(false);
        }
    }
}
