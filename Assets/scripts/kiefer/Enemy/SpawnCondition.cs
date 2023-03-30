using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCondition : MonoBehaviour
{
    public SpawnerData data;

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {

        }
    }
}