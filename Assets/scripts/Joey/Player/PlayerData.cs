using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerData")]
public class PlayerData : ScriptableObject
{
    public string PlayerName;
    public GameObject PlayerPrefab;


    [Header("Stats")]
    public float MaxHealth;
    public float CurrentHealth;
    public float MovementSpeed;
    public float MovementSpeedModifier;


    [Header("Lists and Indexes")]
    // [NOTE] weapons might be easier to track in an enum, so this is subject to change
    //public List<WeaponData> Weapons;
    //public int CurrentWeapon;
    public List<QuestSO> QuestList;


    public bool TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
        return CurrentHealth <= 0;
    }
}
