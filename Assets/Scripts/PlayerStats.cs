using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Stats Stats;
    private float _ñurrentHP;
    private float _ñurrentMana;
    private float _ñurrentStamina;

    [SerializeField] private Bar HealthBar;
    [SerializeField] private Bar ManaBar;
    [SerializeField] private Bar StaminaBar;

    public float Hp
    {
        get
        {
            return _ñurrentHP;
        }
        set
        {
            _ñurrentHP = value;
            HealthBar?.SetValue(value);

            if (_ñurrentHP < 0) _ñurrentHP = 0;
            if (_ñurrentHP > Stats.HP) _ñurrentHP = Stats.HP;
        }
    }

    public float Mana
    {
        get
        {
            return _ñurrentMana;
        }
        set
        {
            _ñurrentMana = value;
            ManaBar?.SetValue(value);

            if (_ñurrentMana < 0) _ñurrentMana = 0;
            if (_ñurrentMana > Stats.Mana) _ñurrentMana = Stats.Mana;
        }
    }

    public float Stamina
    {
        get
        {
            return _ñurrentStamina;
        }
        set
        {
            _ñurrentStamina = value;
            StaminaBar?.SetValue(value);

            if (_ñurrentStamina < 0) _ñurrentStamina = 0;
            if (_ñurrentStamina > Stats.Stamina) _ñurrentStamina = Stats.Stamina;
        }
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

        _ñurrentHP = Stats.HP;
        _ñurrentMana = Stats.Mana;
        _ñurrentStamina = Stats.Stamina;
    }
}
