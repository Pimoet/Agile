using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject normalZombie;
    [SerializeField] private GameObject fastZombie2;
    [SerializeField] private GameObject tankZombie;

    [SerializeField] private GameObject camera;

    [SerializeField] private int maxEnemyCount;
    [SerializeField] private int minEnemyCount;
    private int EnemyCount;

    [SerializeField] private int spawnAmount;

    private Vector3 enemySpawn;

    float cameraXMax = 8.9f;
    float cameraXMin = -8.9f;
    float cameraYMax = 5f;
    float cameraYMin = -5f;

    [SerializeField] float spawnXMax;
    [SerializeField] float spawnXMin;
    [SerializeField] float spawnYMax;
    [SerializeField] float spawnYMin;


    bool spawning = false;
    bool needForSpawn = false;
    #endregion

    
    void Update()
    {
        updateCameraPos();
        if (spawning)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                spawnEnemy();
            }
        }

        if (EnemyCount <= minEnemyCount && !spawning || needForSpawn)
        {
            spawning = true;
            needForSpawn = false;
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
            enemySpawn = new Vector3(Random.Range(spawnXMin, spawnXMax + 1), Random.Range(spawnYMin, spawnYMax + 1), 0);

            Instantiate(normalZombie, checkSpawnPos(enemySpawn), Quaternion.identity);
            EnemyCount++;
        }
    }

    Vector3 checkSpawnPos(Vector3 needsChecking)
    {
        int checks = 0;
        bool hasChecked = false;
        while (hasChecked == false) {

            if (needsChecking.x > cameraXMin & needsChecking.x < cameraXMax)
            {
                checks++;
            }
            if (needsChecking.y > cameraYMin & needsChecking.y < cameraYMax)
            {
                checks++;
            }

            if (checks == 2 || checks == 1)
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

    void updateCameraPos()
    {
        
    }

    IEnumerator waitfortime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}