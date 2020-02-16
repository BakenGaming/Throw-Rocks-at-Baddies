using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("NO AUDIO MANAGER IN SCENE");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
