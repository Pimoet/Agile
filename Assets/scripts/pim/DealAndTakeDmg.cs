using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealAndTakeDmg : MonoBehaviour
{
    private EnemyDataHolder data;
    float hp = 1f;
    float damage = 5f;
    float damagecooldown = 1f;

    [SerializeField]
    private PlayerData _PlayerData;

    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Deal damage
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        hp =- damage;
        if (hp <= 0)
        {
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
}
