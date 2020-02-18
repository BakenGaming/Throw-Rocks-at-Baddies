using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int attackDamage;
    //public int attackRange;

    public float baseSpeed;
    public float aggroSpeed;

    
    private AudioManager audioManager;

    private PlayerProperties playerPropertiesScript;

    void Start()
    {
        currentHealth = maxHealth;
        
        playerPropertiesScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("NO AUDIO MANAGER IN SCENE");
        }

    }

    // Update is called once per frame
    public void TakeDamage(float _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
