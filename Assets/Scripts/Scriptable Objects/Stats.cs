using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "PlayerStats")]
public class Stats : ScriptableObject
{
    [Header("Player info")]
    public float HP;
    public float Mana;
    public float Stamina;
}
