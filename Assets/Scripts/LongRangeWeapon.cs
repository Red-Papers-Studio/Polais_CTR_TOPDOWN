using UnityEngine;

public class LongRangeWeapon : MonoBehaviour
{
    [SerializeField]
    private LongRangeWeaponData weaponData;
    private float timeSinceLastAttack;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastAttack = weaponData.ReloadingTime;
        weaponData.IsReloading = false;
        PlayerAttack.Attack += Attack;
        PlayerBlock.Block += Block;
    }

    private void Update()
    {
        if (timeSinceLastAttack > weaponData.ReloadingTime)
        {
            weaponData.IsReloading = false;
        }
        else
        {
            timeSinceLastAttack -= Time.deltaTime;
        }
    }
    private bool CanAttack() => !weaponData.IsReloading && weaponData.ReloadingTime < timeSinceLastAttack;

    private void Attack()
    {
        if (weaponData.CurrentAmmunationCount > 0)
        {
            if (CanAttack())
            {
                weaponData.CurrentAmmunationCount--;
                timeSinceLastAttack = 0;
                weaponData.IsReloading = true;
                OnWeaponAttack();
            }
            else
            {
                Debug.Log($"Reloading...({weaponData.ReloadingTime - timeSinceLastAttack}sec)");
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
