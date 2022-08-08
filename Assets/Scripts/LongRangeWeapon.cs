using UnityEngine;

public class LongRangeWeapon : MonoBehaviour
{
    [SerializeField]
    private LongRangeWeaponData weaponData;
    private float TimeSinceLastAttack
    {
        get => weaponData.timeSinceLastAttack;
        set
        {
            if(weaponData.timeSinceLastAttack >= weaponData.ReloadingTime)
            {
                weaponData.IsReloading = false;
            }
            else
            {
                weaponData.timeSinceLastAttack = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        TimeSinceLastAttack = weaponData.ReloadingTime;
        weaponData.IsReloading = false;
        PlayerAttack.Attack += Attack;
        PlayerBlock.Block += Block;
    }

    private void Update()
    {
        TimeSinceLastAttack += Time.deltaTime;
    }
    private bool CanAttack()
    {
        return !weaponData.IsReloading && weaponData.ReloadingTime <= TimeSinceLastAttack;
    }
    private void Attack()
    {
        if (weaponData.CurrentAmmunationCount > 0)
        {
            if (CanAttack())
            {
                OnWeaponAttack();
                weaponData.CurrentAmmunationCount--;
                weaponData.timeSinceLastAttack = 0;
                weaponData.IsReloading = true;
            }
            else
            {
                Debug.Log($"Reloading...({TimeSinceLastAttack}sec)");
            }
        }
        else
        {
            Debug.Log("No ammo");
        }
    }

    private void OnWeaponAttack()
    {
        Debug.Log(weaponData.Name + " attackted in long range with damage " + weaponData.Damage);
    }

    private void Block()
    {
        Debug.Log(weaponData.Name + " blocked in short range with damage " + weaponData.Block);
    }
}
