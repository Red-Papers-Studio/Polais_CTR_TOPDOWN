using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Skills/BaseSkillData")]
public class SkillData : ScriptableObject
{
    public Sprite Sprite;

    [Header("Info")]
    public float Damage;

    [Range(0f, 1f)]
    public float CritChance;

    public float CritScale;
    public float ManaCost;
    public float CD;
    public float CastTime;
}
