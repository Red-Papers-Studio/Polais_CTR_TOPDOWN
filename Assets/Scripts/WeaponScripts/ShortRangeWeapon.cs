using UnityEngine;

public class ShortRangeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private ShortRangeWeaponData weaponData;
    public AttackInvoker AttackInvoker;
    private float TimeSinceLastAttack
    {
        get => weaponData.timeSinceLastAttack;
        set
        {
            if (weaponData.timeSinceLastAttack >= weaponData.ReloadingTime)
            {
                weaponData.IsReloading = false;
            }
            else
            {
                weaponData.timeSinceLastAttack = value;
            }
        }
    }
    void Start()
    {
        weaponData.IsReloading = false;
        TimeSinceLastAttack = weaponData.ReloadingTime;
        AttackInvoker.OnAttack += Attack;
        PlayerBlock.Block += Block;
    }

    private void Update()
    {
        TimeSinceLastAttack += Time.deltaTime;
    }

    public void Attack()
    {
        if (CanAttack())
        {
            OnAttack();
            weaponData.IsReloading = true;
            weaponData.timeSinceLastAttack = 0;
        }
        else
        {
            Debug.Log($"Reloading...({TimeSinceLastAttack})");
        }
    }

    public void Block()
    {
        Debug.Log(weaponData.Name + " blocked damage " + weaponData.Block);
    }

    private bool CanAttack()
    {
        return !weaponData.IsReloading && TimeSinceLastAttack >= weaponData.ReloadingTime;
    }

    private void OnAttack()
    {
        Debug.Log(weaponData.Name + " attacked in short range with damage " + weaponData.Damage);
    }
}
