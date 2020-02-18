using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private PlayerController playerScript;
    [SerializeField] private Shovel shovelScript;
    [SerializeField] private LayerMask cannotBeDug;

    private PlayerProperties ppscript;

    private float digCoolDownTimer = 0f;
    private float rockThrowCoolDownTimer = 0f;
    public float digCoolDown, rockThrowCoolDown;

    public float digRadius;
    private bool alreadyDug;
    private float directionX, directionY;

    [Header("Events")]
    [Space]

    public UnityEvent wasDugEvent;
    public UnityEvent diggingEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        if (wasDugEvent == null)
            wasDugEvent = new UnityEvent();

        if (diggingEvent == null)
            diggingEvent = new UnityEvent();
    }

    private void Start()
    {
        ppscript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
    }
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");

        if (directionX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (directionX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (digCoolDownTimer <= 0)
        {
            bool wasDug = alreadyDug;
            alreadyDug = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(shovelScript.digPosition.position, digRadius, cannotBeDug);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    alreadyDug = true;
                    if (wasDug)
                        wasDugEvent.Invoke();
                }
            }
            if (Input.GetMouseButtonDown(0) && !wasDug)
            {
                shovelScript.DigHole();
                digCoolDownTimer = digCoolDown;
            }
         }
         else
        {
                digCoolDownTimer -= Time.deltaTime;
        }
        
        if (rockThrowCoolDownTimer <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                shovelScript.ThrowRock();
                rockThrowCoolDownTimer = digCoolDown;
            }
        }
        else
        {
            rockThrowCoolDownTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        playerScript.MovePlayer(directionX, directionY);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shovelScript.digPosition.transform.position, digRadius);
    }
}
