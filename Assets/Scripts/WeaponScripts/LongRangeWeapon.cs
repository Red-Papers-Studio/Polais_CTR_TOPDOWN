using UnityEngine;

public class LongRangeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private LongRangeWeaponData weaponData;
    [SerializeField]
    private Transform ammoSpawnPoint;
    [SerializeField]
    public AttackInvoker AttackInvoker;
    public GameObject ammoPrefab;
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
    // Start is called before the first frame update
    void Start()
    {
        TimeSinceLastAttack = weaponData.ReloadingTime;
        weaponData.IsReloading = false;
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
            OnWeaponAttack();
            weaponData.timeSinceLastAttack = 0;
            weaponData.IsReloading = true;
        }
        else
        {
            Debug.Log($"Reloading...({TimeSinceLastAttack}sec)");
        }
    }

    public void Block()
    {
        Debug.Log(weaponData.Name + " blocked in short range with damage " + weaponData.Block);
    }

    private bool CanAttack()
    {
        return !weaponData.IsReloading && weaponData.ReloadingTime <= TimeSinceLastAttack;
    }

    private void OnWeaponAttack()
    {
        var ammo = Instantiate(ammoPrefab, ammoSpawnPoint.position, ammoSpawnPoint.rotation);

        ammo.GetComponent<Rigidbody>().velocity = ammoSpawnPoint.transform.forward * weaponData.AmmunationSpeed;
        Debug.Log(weaponData.Name + " attackted in long range with damage " + weaponData.Damage);
    }
}
