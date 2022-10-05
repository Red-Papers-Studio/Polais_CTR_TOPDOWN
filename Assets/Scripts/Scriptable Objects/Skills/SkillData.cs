using UnityEngine;

public class SkillData : ScriptableObject
{
    [Header("Info")]
    public float Damage;

    [Range(0f, 1f)]
    public int CritChance;

    public float CritScale;
    public float ManaCost;
    public float CD;
    public float CastTime;
}
