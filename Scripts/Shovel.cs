using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [SerializeField] private GameObject holePrefab;
    public Transform digPosition;
    private AudioManager audioManager;
    private Animator anim;

    public int[] table = { 60, 25, 10, 5 };
    private int itemToSpawn;
    public int totalSpawnables;
    public GameObject[] itemsInHole;

    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private Transform throwPosition;

    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("NO AUDIO MANAGER IN SCENE");
        }

        foreach (int item in table)
        {
            totalSpawnables += item;
        }
    }
    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

    }
    public void DigHole()
    {
        Instantiate(holePrefab, digPosition.position, Quaternion.identity);
        itemToSpawn = FindItem();
        Instantiate(itemsInHole[itemToSpawn], digPosition.position, Quaternion.identity);
    }

    public void HoleAlreadyDug()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySound("CannotDig");
        }
    }
    public void ThrowRock()
    {
        Instantiate(rockPrefab, throwPosition.position, transform.rotation);
    }

    private int FindItem()
    {
        int randomNumber = Random.Range(0, totalSpawnables);


        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                Debug.Log("Spawn: " + table[i]);
                return(i);
            }
            else
            {
                randomNumber -= table[i]; 
            }
        }
        return (-99);
    }
}
