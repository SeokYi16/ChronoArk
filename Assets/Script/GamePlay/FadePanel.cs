using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject fade_panel_obj;
    float timer;
    float fade_timer = 0.5f;

    private void OnEnable()
    {
        timer = 0; //���� �� Ÿ�̸� �ʱ�ȭ
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > fade_timer)
        {
            fade_panel_obj.SetActive(false); //0.5���� ������Ʈ ����
        }
    }
}
