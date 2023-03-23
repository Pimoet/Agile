using System.Collections;
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
    public int spawnFastAmount;
    public int spawnTankAmount;

    public int tankEnemyCount;
    public int fastEnemyCount;
    public int normalEnemyCount;
    public int totalEnemyCount;

    public int needForSpawnAmount;
}