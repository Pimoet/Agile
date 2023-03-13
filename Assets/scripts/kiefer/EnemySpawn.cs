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
        if (EnemyCount <= maxEnemyCount && spawning)
        {
            InvokeRepeating("spawnEnemy", 1f, 2f);
        }

        if (EnemyCount <= minEnemyCount)
        {
            StartCoroutine(waitfortime(5));
            spawning = true;
            StartCoroutine(waitfortime(10));
            spawning = false;
        }
    }
    void spawnEnemy()
    {
        spawnPoint.x = Random.Range(camMin, camMax);
        spawnPoint.y = Random.Range(camMin, camMax);
        spawnPoint.z = 0;
        Instantiate(normalZombie, spawnPoint, Quaternion.identity);
        EnemyCount++;
        CancelInvoke();
    }
    IEnumerator waitfortime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}