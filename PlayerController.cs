using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRigidbody2D;

    public int speed;

    public void MovePlayer(float _directionX, float _directionY)
    {
        playerRigidbody2D.velocity = new Vector2(_directionX, _directionY) * speed;
    }
}
