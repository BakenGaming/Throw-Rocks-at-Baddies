using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    private PlayerProperties playerPropertiesScript;
    private AudioManager audioManager;
    public int lifetime;
    public int healthValue;

    private void Start()
    {
        playerPropertiesScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
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
            playerPropertiesScript.RestoreHealth(healthValue);
            audioManager.PlaySound("HealthPickup");
            Destroy(gameObject);

        }
    }

    void DestroyItem()
    {
        Destroy(gameObject);
    }
}
