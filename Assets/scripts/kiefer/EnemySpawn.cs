using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    public GameObject normalZombie;
    public GameObject fastZombie2;
    public GameObject tankZombie;

    public int amount;
    private Vector3 spawnPoint;
    private float camMin;
    private float camMax;
    #endregion

    void Start()
    {
        camMin = Camera.main.orthographicSize;
        camMax = Camera.main.orthographicSize + 2;
    }
    void Update()
    {
        if (amount != 10)
        {
            InvokeRepeating("spawnEnemy", 1f, 2f);
        }
    }
    void spawnEnemy()
    {
        spawnPoint.x = Random.Range(camMin, camMax);
        spawnPoint.y = Random.Range(camMin, camMax);
        spawnPoint.z = 0;
        Instantiate(normalZombie, spawnPoint, Quaternion.identity);
        CancelInvoke();
    }
}