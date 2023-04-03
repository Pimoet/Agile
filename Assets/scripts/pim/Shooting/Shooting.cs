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
    public List<GunsSO> guns = new List<GunsSO>();

    private GunsSO heldGun;
    public KeyCode Shootkey;
    public KeyCode PickUpKey;
    
    public float HeldGunDamage; 

    private string oldGun;
    private string currentGun;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject gunSprite;

    private float ammo;


    private void Start()
    {
        heldGun = guns[0];
        oldGun = heldGun.name;
    }

    bool shot;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(heldGun);
        gunSprite.GetComponent<SpriteRenderer>().sprite = heldGun.gunSprite;
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            heldGun = guns[1];
        }
        if (oldGun != currentGun)
        {
            OnPickup();
        }

        currentGun = heldGun.name;

        if (Input.GetKeyDown(Shootkey) && shot == false && heldGun.Automatic == false && ammo > 0)
        {
            Shoot();
        }
        if (Input.GetKey(Shootkey) && shot == false && heldGun.Automatic == true && ammo > 0)
        {
            Shoot();
        }

        Reload();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(PickUpKey))
        {
            if (collision.gameObject.name == "fastGun")
            {
                heldGun = guns[1];
            }
            if (collision.gameObject.name == "sniper")
            {
                heldGun = guns[2];
            }
            if (collision.gameObject.name == "pistol")
            {
                heldGun = guns[0];
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
        MaxAmmo();
        oldGun = currentGun;
    }
    void Shoot()
    {
        ammo--;
        shot = true;
        Invoke("shotReset", heldGun.fireRate);
        var bulletInstance = Instantiate(bullet, gun.transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Bullet>().SetData(heldGun.bulletData); ;

        //Debug.Log(ammo);
    }

    void MaxAmmo()
    {
        ammo = heldGun.magazineSize;
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MaxAmmo();
        }
    }
}
