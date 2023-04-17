using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDataHolder : MonoBehaviour
{

    [SerializeField] private EnemyData data;

    [SerializeField] private GameObject target;
    public float maxHealth;
    public float currentHealth;
    public float movementSpeed;
    public float movementSpeedModifier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //load in all stats from the data variable
        maxHealth = data.maxHealth;
        currentHealth = maxHealth;
        movementSpeed = data.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        return currentHealth <= 0;
    }

    public EnemyData GetData()
    {
        return data;
    }
}
