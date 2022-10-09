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

    private void OnTriggerEnter(Collider collision) 
    {
        //IDamageable target = collision.gameObject.GetComponent<IDamageable>();
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            Debug.Log(weaponData.name + " damage");
            target.Damage(weaponData.Damage);
        }
    }
}