using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawnerData")]
public class SpawnerData : ScriptableObject
{
    public List<EnemyData> enemies;

    public int maxEnemyCount;
    public int minEnemyCount;

    public int spawnTotalAmount;
    public int spawnFastAmount;
    public int spawnTankAmount;

    public float spawnXMaxConst;
    public float spawnXMinConst;
    public float spawnYMaxConst;
    public float spawnYMinConst;
}
