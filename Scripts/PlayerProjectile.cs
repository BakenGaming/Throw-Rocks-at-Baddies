using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damageValue;
    public GameObject explosion;


    
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

    }

    private void Update()
    {
       transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
    void DestroyProjectile()
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
