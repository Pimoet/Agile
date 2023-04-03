using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawnerData")]
public class SpawnerData : ScriptableObject
{
    public List<EnemyData> enemies;

    public float spawnRadius;

    public int maxEnemyCount;
    public int minEnemyCount;

    public int spawnTotalAmount;

    #region tank
    public int spawnTankAmount = 0;
    public int tankEnemyCount = 0;
    #endregion
    #region fast
    public int spawnFastAmount = 0;
    public int fastEnemyCount = 0;
    #endregion
    #region normal
    public int normalEnemyCount = 0;
    #endregion

    public int totalEnemyCount = 0;

    public int needForSpawnAmount = 0;


    public void OnEnemyKill(EnemyData data)
    {
        Debug.Log("yes");
        switch (data.EnemyName)
        {
            case "Normal_Zombie":
                normalEnemyCount--;
                break;
            case "Fast_Zombie":
                fastEnemyCount--;
                break;
            case "Tank_Zombie":
                tankEnemyCount--;
                break;
        }
        totalEnemyCount--;
    }

    public void StartListening()
    {
        Damage.onEnemyKill += OnEnemyKill;
    }

    public void StopListening()
    {
        Damage.onEnemyKill -= OnEnemyKill;
    }

    public void Reset()
    {
        spawnTankAmount = 0;
        tankEnemyCount = 0;
        spawnFastAmount = 0;
        fastEnemyCount = 0;
        normalEnemyCount = 0;
        totalEnemyCount = 0;
        needForSpawnAmount = 0;
    }
}