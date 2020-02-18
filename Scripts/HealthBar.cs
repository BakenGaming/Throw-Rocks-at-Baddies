using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float _maxHealth)
    {
        slider.maxValue = _maxHealth;
        slider.value = _maxHealth;
    }

    public void SetHealth(float _healthValue)
    {
        slider.value = _healthValue;
    }

}
