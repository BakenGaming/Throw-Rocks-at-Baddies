using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPickup : MonoBehaviour
{
    [SerializeField] private int moneyValue;
    [SerializeField] private float lifetime;
    private PlayerProperties playerScript;
    private AudioManager audioManager;

    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
    }

    private void Start()
    {
        audioManager = AudioManager.instance;

        if (audioManager == null)
        {
            Debug.Log("NO AUDIO MANAGER IN SCENE");
        }

        Invoke("DestroyItem", lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlaySound("PickupCoin");
            playerScript.UpdateMoney(moneyValue);
            DestroyItem();
        }
    }

    void DestroyItem()
    {
        Destroy(gameObject);
    }
}
