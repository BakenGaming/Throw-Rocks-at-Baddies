using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPickup : MonoBehaviour
{
    private PlayerProperties playerScript;
    public int ammoValue;

    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.PickupAmmo(ammoValue);
        }
    }
}
