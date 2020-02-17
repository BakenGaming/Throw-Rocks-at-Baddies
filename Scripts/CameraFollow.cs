using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public float speed, minX, minY, maxX, maxY;

    void Start()
    {
        transform.position = playerTransform.position;    
    }

    
    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
    }
}
