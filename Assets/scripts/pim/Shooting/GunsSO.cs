using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunsSO : ScriptableObject
{
    public string name;
    public float damage;
    public float fireRate;
    public float magazineSize;
    public float reloadTime;
    public bool Automatic;

    public Sprite gunSprite;
}
