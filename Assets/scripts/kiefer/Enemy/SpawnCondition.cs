using UnityEngine;

public class SpawnCondition : MonoBehaviour
{
    public SpawnerData data;

    private bool activatedTrap = false;

    void Update()
    {
        if (data.tankEnemyCount == 0 && data.spawnTankAmount == 0)
        {
            data.spawnTankAmount++;
        }
        if (data.fastEnemyCount == 0 && data.spawnFastAmount == 0)
        {
            data.spawnFastAmount++;
        }

        if (activatedTrap)
        {
            data.needForSpawnAmount += 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            activatedTrap = true;
        }
    }
}