using UnityEngine;
using System.Collections.Generic;

public class PlatformGenerator : MonoBehaviour
{
    
    public GameObject[] platformPrefabs; 
    public GameObject enemyPrefab; 
    public float minX = 2f; 
    public float maxX = 5f; 
    public float minY = -2f; 
    public float maxY = 2f;
    public float enemySpawnChance = 0.3f; 

    public Transform player; 
    public float spawnDistance = 10f; 

    public float cleancache = 15f; 
    private float lastSpawnX; 
    private Queue<GameObject> activePlatforms = new Queue<GameObject>(); 

    void Start()
    {
        lastSpawnX = player.position.x;
        
    }

    void Update()
    {
        GeneratePlatforms();
        RecyclePlatforms();
    }

    void GeneratePlatforms()
    {
        while (player.position.x + spawnDistance > lastSpawnX)
        {
            GameObject platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

            float spawnX = lastSpawnX + Random.Range(minX, maxX);
            float spawnY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            activePlatforms.Enqueue(newPlatform); 
            SpawnEnemy(newPlatform);

            lastSpawnX = spawnX;
        }
    }    

    public float enemyOffsetY = 1.2f; 

    void SpawnEnemy(GameObject platform)
    {
    if (Random.value < enemySpawnChance)
    {
        Renderer platformRenderer = platform.GetComponent<Renderer>();
        float platformWidth = platformRenderer.bounds.size.x;

        float enemyX = platform.transform.position.x + Random.Range(-platformWidth / 2f, platformWidth / 2f);
        float enemyY = platform.transform.position.y + enemyOffsetY; 
        Vector3 enemyPosition = new Vector3(enemyX, enemyY, 0);

        Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
    }
    }


    void RecyclePlatforms()
    {
        while (activePlatforms.Count > 0 && activePlatforms.Peek().transform.position.x < player.position.x - cleancache)
        {
            GameObject oldPlatform = activePlatforms.Dequeue(); 
            Destroy(oldPlatform); 
        }
    }

    
}
