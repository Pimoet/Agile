using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GunsSO heldGun;
    public KeyCode Shootkey;
    
    public float HeldGunDamage; 

    private string oldGun;
    private string currentGun;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject groundGun;

    
    private void Start()
    {
        oldGun = heldGun.name;
    }

    bool shot;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           // heldGun = 
        }
        if (oldGun != currentGun)
        {
            OnPickup();
        }

        currentGun = heldGun.name;

        if (Input.GetKeyDown(Shootkey) && shot == false && heldGun.Automatic == false)
        {
            Shoot();
        }
        if (Input.GetKey(Shootkey) && shot == false && heldGun.Automatic == true)
        {
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FloorObject")
        {
            
            if(collision.gameObject.name == "fastGun")
            {
                
            }
        }
    }
    void shotReset()
    {
        shot = false;
    }

    void OnPickup()
    {
        HeldGunDamage = heldGun.damage;
    }
    void Shoot()
    {
        shot = true;
        Invoke("shotReset", heldGun.fireRate);
        Instantiate(bullet, gun.transform.position, Quaternion.identity);
    }
}
