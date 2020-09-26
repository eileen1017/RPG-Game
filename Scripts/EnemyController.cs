using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public float enemyDelay;

    void SpawnEnemies() {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnemySpawnTimer");
    }

    IEnumerator EnemySpawnTimer() {
        yield return new WaitForSeconds(enemyDelay);
        SpawnEnemies();
        StartCoroutine("EnemySpawnTimer");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
