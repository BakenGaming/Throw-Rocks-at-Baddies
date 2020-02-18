using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float speedAdjustment;

    private Transform playerTransform;
    private EnemyProperties enemyPropertiesScript;
    private Vector2 spawnPointToMoveTowards;
    private float waitTime;
    private bool inRange;
    private bool tooClose;
    
    
    public float stopDistance;
    public int aggroRange;
    public float attackCoolDown;
    public float startAttackCoolDown;
    public Transform firePoint;
    public float startWaitTime;
    public float pushRadius;
    

    [Header("Events")]
    [Space]

    public UnityEvent tooCloseToEnemy;


    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        if (tooCloseToEnemy == null)
            tooCloseToEnemy = new UnityEvent();
        speedAdjustment = Random.Range(0, 2f);
    }

    private void Start()
    {
        startAttackCoolDown = attackCoolDown;
        enemyPropertiesScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyProperties>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnPointToMoveTowards = new Vector2 (Random.Range(minX, maxX), Random.Range(minY, maxY));
        waitTime = startWaitTime;

    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < aggroRange)
            {
                inRange = true;

                if (Vector2.Distance(transform.position, playerTransform.position) > stopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, (enemyPropertiesScript.aggroSpeed + speedAdjustment) * Time.deltaTime);
                }

                if (attackCoolDown <= 0)
                {
                    AttackPlayer();
                    attackCoolDown = startAttackCoolDown;
                }
                else
                {
                    attackCoolDown -= Time.deltaTime;
                }

                if (playerTransform.position.x > transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (playerTransform.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
            else
            {
                inRange = false;
            }
        }

        if (!inRange)
        {
            MoveTowardsSpawn();
        }
        
    }

    private void MoveTowardsSpawn()
    {
        transform.position = Vector2.MoveTowards(transform.position, spawnPointToMoveTowards, (enemyPropertiesScript.baseSpeed + speedAdjustment) * Time.deltaTime);

        if (spawnPointToMoveTowards.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (spawnPointToMoveTowards.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Vector2.Distance(transform.position, spawnPointToMoveTowards) <= 0.2f)
        {
            if (waitTime <= 0)
            {
                spawnPointToMoveTowards = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }

    private void AttackPlayer()
    {
        Vector2 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        Instantiate(enemyProjectile, firePoint.position, transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange); 
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pushRadius);
    }
}
