using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProperties : MonoBehaviour
{
    public int playerHealth;
    public int playerMoney = 0;
    public int ammoPouchMax;
    private int currentAmmo = 0;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI moneyText;
    


    private void Start()
    {

        ammoText.text = currentAmmo.ToString();
        moneyText.text = playerMoney.ToString();
    }

    private void Update()
    {
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

}
