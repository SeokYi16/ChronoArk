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

    //�Ʊ� ü�� �����̴�
    [SerializeField]
    private Slider player_hp_slider;
    [SerializeField]
    private Slider player_hp_slider_enemy;
    [SerializeField]
    private Slider azar_hp_slider;
    [SerializeField]
    private Slider azar_hp_slider_enemy;
    [SerializeField]
    private Slider joey_hp_slider;
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
        // ĳ���� ü�� �����̴�
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
    }
}