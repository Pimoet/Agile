using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    public SpawnerData data;

    private GameObject camera;

    float cameraXMaxConst = 8.9f;
    float cameraXMinConst = -8.9f;
    float cameraYMaxConst = 5f;
    float cameraYMinConst = -5f;

    bool spawning = false;

    float cameraXMax;
    float cameraXMin;
    float cameraYMax;
    float cameraYMin;

    float spawnXMax;
    float spawnXMin;
    float spawnYMax;
    float spawnYMin;

    #endregion
    private void Start()
    {
        camera = GameObject.Find("Main Camera");
        data.Reset();
    }
    void Update()
    {
        UpdateVariables();
        if (spawning)
        {
            for (int i = 0; i < data.spawnTotalAmount; i++)
            {
                spawnEnemy();
            }
        }

        if (data.totalEnemyCount <= data.minEnemyCount && !spawning || data.needForSpawnAmount > 0)
        {
            spawning = true;
            if (data.needForSpawnAmount > 0)
            {
                data.needForSpawnAmount--;
            }
        }
        else if (data.totalEnemyCount >= data.minEnemyCount && data.totalEnemyCount <= data.maxEnemyCount && spawning)
        {
            spawning = false;
        }
    }
    void spawnEnemy()
    {
        if (data.totalEnemyCount <= data.maxEnemyCount)
        {
            if (data.spawnTankAmount > 0)
            {
                Instantiate(data.enemies[2].EnemyPrefab, checkSpawnPos(), Quaternion.identity);
                data.tankEnemyCount++;
                data.spawnTankAmount--;
                data.totalEnemyCount++;
            }
            else if (data.spawnFastAmount > 0)
            {
                Instantiate(data.enemies[1].EnemyPrefab, checkSpawnPos(), Quaternion.identity);
                data.fastEnemyCount++;
                data.spawnFastAmount--;
                data.totalEnemyCount++;
            }
            else
            {
                Instantiate(data.enemies[0].EnemyPrefab, checkSpawnPos(), Quaternion.identity);
                data.normalEnemyCount++;
                data.totalEnemyCount++;
            }
        }
    }
    void UpdateVariables()
    {
        cameraXMax = camera.transform.position.x + cameraXMaxConst;
        cameraXMin = camera.transform.position.x + cameraXMinConst;
        cameraYMax = camera.transform.position.x + cameraYMaxConst;
        cameraYMin = camera.transform.position.x + cameraYMinConst;

        spawnXMax = camera.transform.position.x + data.spawnRadius;
        spawnXMin = camera.transform.position.x - data.spawnRadius;
        spawnYMax = camera.transform.position.x + data.spawnRadius;
        spawnYMin = camera.transform.position.x - data.spawnRadius;
    }
    Vector3 checkSpawnPos()
    {
        Vector3 needsChecking = new Vector3(Random.Range(spawnXMin, spawnXMax + 1), Random.Range(spawnYMin, spawnYMax + 1), 0);

        bool hasChecked = false;
        while (hasChecked == false) {
            int inCamera = 0;
            float X = needsChecking.x;
            float Y = needsChecking.y;
            
            if (X > cameraXMin && X < cameraXMax)
            {
                inCamera += 1;
            }
            if (Y > cameraYMin && Y < cameraYMax)
            {
                inCamera += 1;
            }

            if (inCamera == 0)
            {
                hasChecked = true;
            }
            else
            {
                needsChecking = new Vector3(Random.Range(spawnXMin, spawnXMax + 1), Random.Range(spawnYMin, spawnYMax + 1), 0);
            }
        }
        return needsChecking;
    }
}