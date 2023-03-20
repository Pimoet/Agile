using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Zombie")]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public GameObject EnemyPrefab;

    public float maxHealth;
    public float movementSpeed;
    public float dammage;
}
