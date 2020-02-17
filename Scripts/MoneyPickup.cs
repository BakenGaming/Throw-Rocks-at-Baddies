using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPickup : MonoBehaviour
{
    [SerializeField] private int moneyValue;
    private PlayerProperties playerScript;


    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.UpdateMoney(moneyValue);
        }
    }
}
