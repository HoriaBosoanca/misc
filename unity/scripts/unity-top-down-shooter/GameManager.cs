using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random=UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("!!! Manual Refrences")]
    [SerializeField] private GameObject enemy;
    
    [Header("Editable")]
    [SerializeField] private float enemySpawnCooldown;
    [SerializeField] private float minSpawnRange;
    [SerializeField] private float maxSpawnRange;

    //variables
    private bool enemySpawnOnCooldown;

    //refs
    private Vector3 plr;
    void Update()
    {
        plr = GameObject.Find("Player").transform.position;
        
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        if(!enemySpawnOnCooldown)
        {
            enemySpawnOnCooldown = true;
            StartCoroutine("SpawnEnemy");
        }
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(enemySpawnCooldown);
        Instantiate(enemy, SpawnLocation(), Quaternion.identity);
        enemySpawnOnCooldown = false;
    }

    Vector3 SpawnLocation()
    {
        float xSpawn;
        float ySpawn;

        xSpawn = Random.Range(minSpawnRange, maxSpawnRange);
        ySpawn = Random.Range(minSpawnRange, maxSpawnRange);

        if(Random.value < 0.5f)
        {
            xSpawn *= -1;
        }

        if(Random.value < 0.5f)
        {
            ySpawn *= -1;
        }
        
        return new Vector3(plr.x + xSpawn, plr.y + ySpawn, 0);
    }
}
