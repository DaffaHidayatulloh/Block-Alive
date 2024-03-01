using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] objectsToSpawn; 
    private GameObject spawnPointObject; 
    private SpriteRenderer spawnPointSpriteRenderer; 
    private bool canSpawn = true;
    private GameObject nextSpawnObject; 
    private SpriteRenderer nextSpawnSpriteRenderer; 

    private void Start()
    {
        
        spawnPointObject = gameObject;
        
        spawnPointSpriteRenderer = spawnPointObject.GetComponent<SpriteRenderer>();

       
        UpdateSpawnPointSpriteRenderer();

        
        SetNextSpawnObject();
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
       
        Instantiate(nextSpawnObject, spawnPointObject.transform.position, Quaternion.identity);

       
        canSpawn = false;

        
        Invoke("DropObject", 2f);

        
        SetNextSpawnObject();
    }

    private void DropObject()
    {
        
        canSpawn = true;
    }

    private void UpdateSpawnPointSpriteRenderer()
    {
       
        if (nextSpawnSpriteRenderer != null && spawnPointSpriteRenderer != null)
        {
            spawnPointSpriteRenderer.sprite = nextSpawnSpriteRenderer.sprite;
        }
    }

    private void SetNextSpawnObject()
    {
       
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        nextSpawnObject = objectsToSpawn[randomIndex];

        
        nextSpawnSpriteRenderer = nextSpawnObject.GetComponent<SpriteRenderer>();

        
        UpdateSpawnPointSpriteRenderer();
    }
}

