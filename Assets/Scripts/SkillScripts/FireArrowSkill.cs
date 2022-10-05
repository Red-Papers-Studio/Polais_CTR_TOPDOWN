
using UnityEngine;

public class FireArrowSkill : Skill
{
    [SerializeField] private LongRangeWeapon _weapon;
    [SerializeField] private GameObject _magicArrow;
    protected override void AttackAction(SkillData skillData)
    {
        var breviousArrow = _weapon.ammoPrefab;
        _weapon.ammoPrefab = _magicArrow;
        _weapon.Attack();
        _weapon.ammoPrefab = breviousArrow;
    }
}
