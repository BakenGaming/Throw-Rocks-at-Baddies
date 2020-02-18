using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPickup : MonoBehaviour
{
    private PlayerProperties playerScript;
    private AudioManager audioManager;
    public int lifetime;
    public int ammoValue;

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
            playerScript.PickupAmmo(ammoValue);
            audioManager.PlaySound("PickupRock");
            DestroyItem();
        }
    }
    void DestroyItem()
    {
        Destroy(gameObject);
    }
}
