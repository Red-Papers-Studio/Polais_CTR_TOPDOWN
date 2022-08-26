using UnityEngine;

public class ShortRangeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private ShortRangeWeaponData weaponData;
    public AttackInvoker AttackInvoker;

    //[SerializeField]
    //private GameObject weapon;
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
            weaponData.IsReloading = true;
            _timeSinceLastAttack = 0;
        }
    }

    private bool CanAttack()
    {
        return !weaponData.IsReloading && TimeSinceLastAttack >= weaponData.ReloadingTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable target = collision.gameObject.GetComponent<IDamageable>();
        target?.Damage(weaponData.Damage);
    }
}