using UnityEngine;

public class WeaponData : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public float Damage;
    public float Block;
    public float Durability;
    public bool IsTwoHanded;
    public float ReloadingTime;
    [HideInInspector]
    public bool IsReloading;
    [HideInInspector]
    public float timeSinceLastAttack;
}
