using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    private GameObject camera;

    public List<EnemyData> enemies;

    public float spawnRadius;

    public int maxEnemyCount;
    public int minEnemyCount;

    public int spawnTotalAmount;
    public int spawnFastAmount;
    public int spawnTankAmount;

    public int tankEnemyCount; 
    public int fastEnemyCount;
    public int normalEnemyCount;
    public int totalEnemyCount;

    public int needForSpawnAmount = 0;

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
    }
    void Update()
    {
        ChangeCameraPos();
        if (spawning)
        {
            for (int i = 0; i < spawnTotalAmount; i++)
            {
                spawnEnemy();
            }
        }

        if (totalEnemyCount <= minEnemyCount && !spawning || needForSpawnAmount > 0)
        {
            spawning = true;
            if (needForSpawnAmount > 0)
            {
                needForSpawnAmount--;
            }
        }
        else if (totalEnemyCount >= minEnemyCount && totalEnemyCount <= maxEnemyCount && spawning)
        {
            spawning = false;
        }
    }
    void spawnEnemy()
    {
        if (totalEnemyCount <= maxEnemyCount)
        {
            if (spawnTankAmount > 0)
            {
                Instantiate(enemies[2].EnemyPrefab, checkSpawnPos(), Quaternion.identity);
                spawnTankAmount--;
                totalEnemyCount++;
                tankEnemyCount++;
            }
            else if (spawnFastAmount > 0)
            {
                Instantiate(enemies[1].EnemyPrefab, checkSpawnPos(), Quaternion.identity);
                spawnFastAmount--;
                totalEnemyCount++;
                fastEnemyCount++;
            }
            else
            {
                Instantiate(enemies[0].EnemyPrefab, checkSpawnPos(), Quaternion.identity);
                totalEnemyCount++;
                normalEnemyCount++;
            }
        }
    }
    void ChangeCameraPos()
    {
        cameraXMax = camera.transform.position.x + cameraXMaxConst;
        cameraXMin = camera.transform.position.x + cameraXMinConst;
        cameraYMax = camera.transform.position.x + cameraYMaxConst;
        cameraYMin = camera.transform.position.x + cameraYMinConst;

        spawnXMax = camera.transform.position.x + spawnRadius;
        spawnXMin = camera.transform.position.x - spawnRadius;
        spawnYMax = camera.transform.position.x + spawnRadius;
        spawnYMin = camera.transform.position.x - spawnRadius;
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