using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private PlayerProperties playerScript;
    private Vector2 targetPosition;

    public float speed;
    public float damage;

    public float lifeTime;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
        targetPosition = playerScript.transform.position;
        Invoke("DestroyProjectile", lifeTime);
    }


    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
