
using UnityEngine;

public class FireArrowSkill : Skill
{
    [SerializeField] private WeaponSwitcher _switcher;
    [SerializeField] private GameObject _magicArrow;

    private GameObject _weaponAmmo;
    private LongRangeWeapon _weapon;
    private bool _isSwitch;
    private void Start()
    {
        _weapon = _switcher.SecondWeapon;
        _weaponAmmo = _weapon.ammoPrefab;
    }
    protected override void AttackAction(SkillData skillData)
    {
        _isSwitch = false;
        if (_switcher.IsFirstWeapon)
        {
            _switcher.SwitchWeapon();
            _isSwitch = true;
        }

        _weapon.ammoPrefab = _magicArrow;
        _weapon.AttackInvoker.Attack();
        _weapon.AttackInvoker.EndAttack += EndAttackAction;
    }

    private void EndAttackAction()
    {
        _weapon.ammoPrefab = _weaponAmmo;
        _weapon.AttackInvoker.EndAttack -= EndAttackAction;
        if(_isSwitch)
        {
            _switcher.SwitchWeapon();
        }
    }
}
