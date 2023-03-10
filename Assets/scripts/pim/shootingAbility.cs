using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu]

public class shootingAbility : Abillity
{
    [SerializeField]
    private float damage;
    [SerializeField]

    GameObject Bullet;
    public override void Activate(GameObject parent)
    {
        Debug.Log("Shoot");
        Instantiate(Bullet, parent.transform.position, quaternion.identity);
    }
}
