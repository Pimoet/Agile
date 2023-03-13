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
        camMin = Camera.main.orthograp$$anonymous$$cSize;
        camMax = Camera.main.orthograp$$anonymous$$cSize + 2;
    }
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemy.Length;
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
        Instantiate(enemy[UnityEngine.Random.Range(0, enemy.Length - 1)], spawnPoint, Quaternion.identity);
        CancelInvoke();
    }
}