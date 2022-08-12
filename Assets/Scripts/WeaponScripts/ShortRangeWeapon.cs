using UnityEngine;

public class ShortRangeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private ShortRangeWeaponData weaponData;
    public AttackInvoker AttackInvoker;

    [SerializeField]
    private GameObject weapon;
    private float _timeSinceLastAttack;
    private float TimeSinceLastAttack
    {
        get => _timeSinceLastAttack;
        set
        {
            if (_timeSinceLastAttack >= weaponData.ReloadingTime)
            {
                weaponData.IsReloading = false;
            }
            else
            {
                _timeSinceLastAttack = value;
            }
        }
    }
    void Start()
    {
        weaponData.IsReloading = false;
        TimeSinceLastAttack = weaponData.ReloadingTime;
        AttackInvoker.OnAttack += Attack;
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
            _timeSinceLastAttack = 0;
        }
        else
        {
            Debug.Log($"Reloading...({TimeSinceLastAttack})");
        }
    }

    private bool CanAttack()
    {
        return !weaponData.IsReloading && TimeSinceLastAttack >= weaponData.ReloadingTime;
    }

    private void OnAttack()
    {
        Debug.Log(weaponData.Name + " attacked in short range with damage " + weaponData.Damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        target?.Damage(weaponData.Damage);
    }
}
