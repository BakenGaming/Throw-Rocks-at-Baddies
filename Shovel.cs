using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [SerializeField] private GameObject holePrefab;
    public Transform digPosition;
    private AudioManager audioManager;
    private Animator anim;
    

    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("NO AUDIO MANAGER IN SCENE");
        }
    }
    private void Update()
    {
    }
    public void DigHole()
    {
        Instantiate(holePrefab, digPosition.position, Quaternion.identity);
    }

    public void HoleAlreadyDug()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySound("CannotDig");
        }
    }
}
