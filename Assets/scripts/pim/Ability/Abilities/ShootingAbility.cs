using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu]

public class ShootingAbility : Abillity
{
    [SerializeField]
    private float damage;
    [SerializeField]

    GameObject Bomb;
    public override void Activate(GameObject parent)
    {
        Debug.Log("Shoot");
        Instantiate(Bomb, parent.transform.position, quaternion.identity);
    }
}
