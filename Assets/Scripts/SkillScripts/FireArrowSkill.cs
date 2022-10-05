
using UnityEngine;

public class FireArrowSkill : Skill
{
    [SerializeField] private LongRangeWeapon _weapon;
    [SerializeField] private GameObject _magicArrow;

    private GameObject _weaponAmmo;
    private void Start()
    {
        _weaponAmmo = _weapon.ammoPrefab;
    }
    protected override void AttackAction(SkillData skillData)
    {

        _weapon.ammoPrefab = _magicArrow;
        _weapon.AttackInvoker.Attack();
        _weapon.AttackInvoker.EndAttack += EndAttackAction;
    }

    private void EndAttackAction()
    {
        _weapon.ammoPrefab = _weaponAmmo;
        _weapon.AttackInvoker.EndAttack -= EndAttackAction;
    }
}
