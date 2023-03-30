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

    public int spawnTankAmount = 0;
    public int spawnFastAmount = 0;

    public int tankEnemyCount = 0;
    public int fastEnemyCount = 0;
    public int normalEnemyCount = 0;
    public int totalEnemyCount = 0;

    public int needForSpawnAmount = 0;
}