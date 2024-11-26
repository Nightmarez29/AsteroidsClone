using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Wave Numbers")]
    public GameObject enemyPrefab;
    public GameObject enemySmallPrefab;
    public GameObject enemyLargePrefab;
    public int enemyCount;
    public int waveNumber = 1;

    [Header("Enemy Spawn")]
    private float spawnRange = 9;
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
      
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyLargePrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
