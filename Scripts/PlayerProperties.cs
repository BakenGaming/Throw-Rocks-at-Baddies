using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProperties : MonoBehaviour
{
    public float playerMaxHealth;
    public float currentHealth;
    public int playerMoney = 0;
    public int currentAmmo = 0;
    public int ammoPouchMax;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI moneyText;
    
       
    private void Start()
    {

        ammoText.text = currentAmmo.ToString();
        moneyText.text = playerMoney.ToString();
        currentHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if (currentAmmo <= 0)
        {
            ammoText.color = Color.red;
            currentAmmo = 0;
        }
        ammoText.text = currentAmmo.ToString();
    }
    public void UpdateMoney(int _money)
    {
        playerMoney += _money;
        moneyText.text = playerMoney.ToString();
    }

    public void PickupAmmo(int _ammoCount)
    {
        currentAmmo += _ammoCount;
        if (currentAmmo >= ammoPouchMax)
        {
            Debug.Log("Ammo Full");
            currentAmmo = ammoPouchMax;
            ammoText.color = Color.green;
        }
        else
        {
            ammoText.color = Color.yellow;
        }
    }
    public void ReduceAmmo()
    {
        if (currentAmmo >= 1)
        {
            currentAmmo--;
        }
    }

    public void TakeDamage(float _healthValue)
    {

        if (currentHealth - _healthValue < 0)
        {
            //Die
        }
        else
        {
            currentHealth -= _healthValue;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void RestoreHealth(int _healthValue)
    {
        if (currentHealth + _healthValue > playerMaxHealth)
        {
            currentHealth = playerMaxHealth;
        }
        else
        {
            currentHealth += _healthValue;
        }
        healthBar.SetHealth(currentHealth);
    }
}


