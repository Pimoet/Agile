using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject normalZombie;
    [SerializeField] private GameObject fastZombie2;
    [SerializeField] private GameObject tankZombie;

    [SerializeField] private int maxEnemyCount;
    [SerializeField] private int minEnemyCount;
    [SerializeField] private int EnemyCount;
    [SerializeField] private int spawnAmount;

    private Vector3 spawnPoint;

    private float camMin;
    private float camMax;

    bool spawning = false;
    #endregion

    void Start()
    {
        camMin = Camera.main.orthographicSize;
        camMax = Camera.main.orthographicSize + 2;
    }
    void Update()
    {
        if (spawning)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                spawnEnemy();
            }
        }

        if (EnemyCount <= minEnemyCount && !spawning)
        {
            StartCoroutine(waitfortime(5));
            spawning = true;
        }
        else if (EnemyCount >= minEnemyCount && EnemyCount <= maxEnemyCount && spawning)
        {
            StartCoroutine(waitfortime(10));
            spawning = false;
        }
    }
    void spawnEnemy()
    {
        if (EnemyCount <= maxEnemyCount)
        {
            spawnPoint.x = Random.Range(camMin, camMax);
            spawnPoint.y = Random.Range(camMin, camMax);
            spawnPoint.z = 0;
            Instantiate(normalZombie, spawnPoint, Quaternion.identity);
            EnemyCount++;
        }
    }
    IEnumerator waitfortime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}