using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerInfoObjects playerInfo;
    public PlayerHealth playerHealth;
    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI currentHealth;

    public void SetMaxHealth()
    {
        slider.maxValue = playerInfo.maxHealth;
        slider.value = playerInfo.maxHealth;
        maxHealth.text = "" + playerInfo.maxHealth;
        currentHealth.text = "" + playerInfo.maxHealth;

    }

    public void SetHealth()
    {
        slider.value = playerHealth.playerHealth;
        currentHealth.text = "" + playerHealth.playerHealth;
    }
}
