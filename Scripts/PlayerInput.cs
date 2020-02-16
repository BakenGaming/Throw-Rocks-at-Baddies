using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private PlayerController playerScript;
    [SerializeField] private Shovel shovelScript;
    [SerializeField] private LayerMask whatIsHole;


    private float digCoolDownTimer = 0f;
    public float digCoolDown;

    public float digRadius;
    private bool alreadyDug;
    private float directionX, directionY;


    private Animator anim;

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
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");

    if (digCoolDownTimer <= 0)
    {
            bool wasDug = alreadyDug;
        alreadyDug = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(shovelScript.digPosition.position, digRadius, whatIsHole);

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
            anim.SetBool("isDigging", true);
            shovelScript.DigHole();
            digCoolDownTimer = digCoolDown;
        }
        else
        {
            anim.SetBool("isDigging", false);
        }
     }
     else
     {
            digCoolDownTimer -= Time.deltaTime;
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
