using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private AzarStat azarstat;
    [SerializeField]
    private JoeyStat joeystat;
    [SerializeField]
    private PlayerStat playerstat;

    //아군 체력 슬라이더
    [SerializeField]
    private Slider player_hp_slider;
    [SerializeField]
    private Slider player_dmg_slider;
    [SerializeField]
    private Slider player_hp_slider_enemy;
    [SerializeField]
    private Slider azar_hp_slider;
    [SerializeField]
    private Slider azar_dmg_slider;
    [SerializeField]
    private Slider azar_hp_slider_enemy;
    [SerializeField]
    private Slider joey_hp_slider;
    [SerializeField]
    private Slider joey_dmg_slider;
    [SerializeField]
    private Slider joey_hp_slider_enemy;
    [SerializeField]
    private TextMeshProUGUI player_hp_slider_text;
    [SerializeField]
    private TextMeshProUGUI player_hp_slider_enemy_text;
    [SerializeField]
    private TextMeshProUGUI azar_hp_slider_text;
    [SerializeField]
    private TextMeshProUGUI azar_hp_slider_enemy_text;
    [SerializeField]
    private TextMeshProUGUI joey_hp_slider_text;
    [SerializeField]
    private TextMeshProUGUI joey_hp_slider_enemy_text;

    private void Update()
    {
        // 캐릭터 체력 슬라이더
        player_hp_slider.maxValue = playerstat.max_hp;
        player_hp_slider.value = playerstat.hp;
        player_hp_slider_enemy.maxValue = playerstat.max_hp;
        player_hp_slider_enemy.value = playerstat.hp;
        player_hp_slider_text.text = "HP : " + playerstat.hp + " / " + playerstat.max_hp;
        player_hp_slider_enemy_text.text = "HP : " + playerstat.hp + " / " + playerstat.max_hp;

        azar_hp_slider.maxValue = azarstat.max_hp;
        azar_hp_slider.value = azarstat.hp;
        azar_hp_slider_enemy.maxValue = azarstat.max_hp;
        azar_hp_slider_enemy.value = azarstat.hp;
        azar_hp_slider_text.text = "HP : " + azarstat.hp + " / " + azarstat.max_hp;
        azar_hp_slider_enemy_text.text = "HP : " + azarstat.hp + " / " + azarstat.max_hp;

        joey_hp_slider.maxValue = joeystat.max_hp;
        joey_hp_slider.value = joeystat.hp;
        joey_hp_slider_enemy.maxValue = joeystat.max_hp;
        joey_hp_slider_enemy.value = joeystat.hp;
        joey_hp_slider_text.text = "HP : " + joeystat.hp + " / " + joeystat.max_hp;
        joey_hp_slider_enemy_text.text = "HP : " + joeystat.hp + " / " + joeystat.max_hp;


        player_dmg_slider.maxValue = player_hp_slider.maxValue;

        if (player_hp_slider.value <= player_dmg_slider.value)
        {
            player_dmg_slider.value -= Time.deltaTime * 3;
        }
        if (player_hp_slider.value > player_dmg_slider.value)
        {
            player_dmg_slider.value = player_hp_slider.value;
        }

        azar_dmg_slider.maxValue = azar_hp_slider.maxValue;

        if (azar_hp_slider.value <= azar_dmg_slider.value)
        {
            azar_dmg_slider.value -= Time.deltaTime * 3;
        }
        if (azar_hp_slider.value > azar_dmg_slider.value)
        {
            azar_dmg_slider.value = azar_hp_slider.value;
        }

        joey_dmg_slider.maxValue = joey_hp_slider.maxValue;

        if (joey_hp_slider.value <= joey_dmg_slider.value)
        {
            joey_dmg_slider.value -= Time.deltaTime * 3;
        }
        if (joey_hp_slider.value > joey_dmg_slider.value)
        {
            joey_dmg_slider.value = joey_hp_slider.value;
        }
    }
}
