using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerStats : MonoBehaviour, IDamagable
{
    [SerializeField] private Stats Stats;
    private float _�urrentHP;
    private float _�urrentMana;
    private float _�urrentStamina;

    [SerializeField] private Bar HealthBar;
    [SerializeField] private Bar ManaBar;
    [SerializeField] private Bar StaminaBar;

    private Animator _animator;

    public float Hp
    {
        get
        {
            return _�urrentHP;
        }
        set
        {
            _�urrentHP = value;
            HealthBar?.SetValue(value);

            if (_�urrentHP < 0) _�urrentHP = 0;
            if (_�urrentHP > Stats.HP) _�urrentHP = Stats.HP;
        }
    }

    public float Mana
    {
        get
        {
            return _�urrentMana;
        }
        set
        {
            _�urrentMana = value;
            ManaBar?.SetValue(value);

            if (_�urrentMana < 0) _�urrentMana = 0;
            if (_�urrentMana > Stats.Mana) _�urrentMana = Stats.Mana;
        }
    }

    public float Stamina
    {
        get
        {
            return _�urrentStamina;
        }
        set
        {
            _�urrentStamina = value;
            StaminaBar?.SetValue(value);

            if (_�urrentStamina < 0) _�urrentStamina = 0;
            if (_�urrentStamina > Stats.Stamina) _�urrentStamina = Stats.Stamina;
        }
    }

    public void Damage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            DeadAnimation();
        }
        else
        {
            StartDamageAnimation();
        }
    }

    private void StartDamageAnimation()
    {
        _animator.SetBool("IsDamaged", true);
    }

    private void EndDamageAnimation()
    {
        _animator.SetBool("IsDamaged", false);
        Debug.Log("End animation");
    }

    private void DeadAnimation()
    {
        _animator.SetBool("IsDead", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthBar?.SetMaxValue(Stats.HP);
        ManaBar?.SetMaxValue(Stats.Mana);
        StaminaBar?.SetMaxValue(Stats.Stamina);
        HealthBar?.SetValue(Stats.HP);
        ManaBar?.SetValue(Stats.Mana);
        StaminaBar?.SetValue(Stats.Stamina);

        _�urrentHP = Stats.HP;
        _�urrentMana = Stats.Mana;
        _�urrentStamina = Stats.Stamina;

        _animator = GetComponent<Animator>();
    }
}
