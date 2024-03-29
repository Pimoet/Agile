using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/DamageAction")]
public class Damage : ScriptableObject
{
    public static event Action<EnemyData> onEnemyKill;
    public static event Action onPlayerDeath;

    public bool DebugOn;

    public void DealDamage(GameObject target, float damage)
    {

        if (target.CompareTag("Enemy"))
        {
            bool isDead = target.GetComponent<EnemyDataHolder>().TakeDamage(damage);
            if (isDead)
            {
                Destroy(target.gameObject);
                onEnemyKill(target.GetComponent<EnemyDataHolder>().GetData());
            }
        }
        if (target.CompareTag("Player"))
        {
            bool isDead = target.GetComponent<PlayerController>().playerData.TakeDamage(damage);
            if (isDead)
            {
                onPlayerDeath();
            }
        }
        if (DebugOn)
        {
            Debug.Log($"hit {target.name} for {damage} damage.");
        }
        
    }
}
