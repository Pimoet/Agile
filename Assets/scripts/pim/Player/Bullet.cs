using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D RB;

    public float lifeTime;
    public float bulletSpeed;
    public float damage;

    [SerializeField] private Damage damageFunction;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        
        
        Destroy(gameObject, lifeTime);

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        RB.velocity = (mouseWorldPos - transform.position).normalized * bulletSpeed;
    }

    // Update is called once per frame      
    void Update()
    {
        //Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageFunction.DealDamage(collision.gameObject, damage);
        }
    }
}
