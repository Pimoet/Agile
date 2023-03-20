using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    [SerializeField] private SpawnerData data;

    private GameObject camera;

    private int EnemyCount;

    private Vector3 enemySpawn;

    float cameraXMaxConst = 8.9f;
    float cameraXMinConst = -8.9f;
    float cameraYMaxConst = 5f;
    float cameraYMinConst = -5f;

    float cameraXMax;
    float cameraXMin;
    float cameraYMax;
    float cameraYMin;

    float spawnXMax;
    float spawnXMin;
    float spawnYMax;
    float spawnYMin;

    bool spawning = false;
    bool needForSpawn = false;
    #endregion
    private void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        updateCameraPos();
        if (spawning)
        {
            for (int i = 0; i < data.spawnTotalAmount; i++)
            {
                spawnEnemy(data.enemies);
            }
        }

        if (EnemyCount <= data.minEnemyCount && !spawning || needForSpawn)
        {
            spawning = true;
            needForSpawn = false;
        }
        else if (EnemyCount >= data.minEnemyCount && EnemyCount <= data.maxEnemyCount && spawning)
        {
            StartCoroutine(waitfortime(10));
            spawning = false;
        }
    }
    void spawnEnemy(List<EnemyData> enemies)
    {
        if (EnemyCount <= data.maxEnemyCount)
        {
            enemySpawn = new Vector3(Random.Range(spawnXMin, spawnXMax + 1), Random.Range(spawnYMin, spawnYMax + 1), 0);

            if (data.spawnTankAmount > 0)
            {
                Instantiate(enemies[2].EnemyPrefab, checkSpawnPos(enemySpawn), Quaternion.identity);
                data.spawnTankAmount--;
                EnemyCount++;
            }
            else if (data.spawnFastAmount > 0)
            {
                Instantiate(enemies[1].EnemyPrefab, checkSpawnPos(enemySpawn), Quaternion.identity);
                data.spawnFastAmount--;
                EnemyCount++;
            }
            else
            {
                Instantiate(enemies[0].EnemyPrefab, checkSpawnPos(enemySpawn), Quaternion.identity);
                EnemyCount++;
            }
        }
    }

    void updateCameraPos()
    {
        cameraXMax = camera.transform.position.x + cameraXMaxConst;
        cameraXMin = camera.transform.position.x - cameraXMinConst;
        cameraYMax = camera.transform.position.x + cameraYMaxConst;
        cameraYMin = camera.transform.position.x - cameraYMinConst;

        spawnXMax = camera.transform.position.x + data.spawnRadius;
        spawnXMin = camera.transform.position.x - data.spawnRadius;
        spawnYMax = camera.transform.position.x + data.spawnRadius;
        spawnYMin = camera.transform.position.x - data.spawnRadius;
    }

    Vector3 checkSpawnPos(Vector3 needsChecking)
    {
        bool hasChecked = false;
        while (hasChecked == false) {
            int checks = 0;
            
            if (needsChecking.x > cameraXMin && needsChecking.x < cameraXMax)
            {
                checks++;
            }
            if (needsChecking.y > cameraYMin && needsChecking.y < cameraYMax)
            {
                checks++;
            }

            if (checks > 0)
            {
                needsChecking = new Vector3(Random.Range(spawnXMin, spawnXMax + 1), Random.Range(spawnYMin, spawnYMax + 1), 0);
            }
            else
            {
                hasChecked = true;
            }
        }
        return needsChecking;
    }

    IEnumerator waitfortime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}