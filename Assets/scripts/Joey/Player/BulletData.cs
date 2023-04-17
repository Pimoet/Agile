using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="BulletData")]
public class BulletData : ScriptableObject
{
    public float Damage;
    public float Speed;
    public float Pierce;
    public float Lifetime;

    public Sprite bulletSprite;
}
