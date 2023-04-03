using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D RB;
    public BulletData data;

    public float lifeTime;
    public float bulletSpeed;
    public float damage;
    public float pierce;

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

    public void SetData(BulletData d)
    {
        data = d;
        lifeTime = data.Lifetime;
        bulletSpeed = data.Speed;
        damage = data.Damage;
        pierce = data.Pierce;
        GetComponent<SpriteRenderer>().sprite = data.bulletSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageFunction.DealDamage(collision.gameObject, damage);
            pierce--;
            if(pierce <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
