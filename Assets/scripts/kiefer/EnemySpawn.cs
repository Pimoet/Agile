using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    public GameObject normalZombie;
    public GameObject fastZombie2;
    public GameObject tankZombie;

    int playerPos;
    int spawnRadius = 50;

    int maxYSpawn;
    int minYSpawn;
    int maxXSpawn;
    int minXSpawn;
    #endregion

    void Start()
    {
        playerPos = playerPos -1;
        maxYSpawn = playerPos + spawnRadius;
        minYSpawn = playerPos - spawnRadius;
        maxXSpawn = playerPos + spawnRadius;
        minXSpawn = playerPos - spawnRadius;
        int name = Random.Range(1, 51);
    }

    void Update()
    {
    }
}
