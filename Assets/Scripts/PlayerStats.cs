using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Stats Stats = new Stats(100, 100, 100);
    [SerializeField] private float _currentHP;
    [SerializeField] private float _currentMana;
    [SerializeField] private float _currentStamina;

    [SerializeField] private Bar HealthBar;
    [SerializeField] private Bar ManaBar;
    [SerializeField] private Bar StaminaBar;

    public float Hp
    {
        get
        {
            return _currentHP;
        }
        set
        {
            _currentHP = value;
            HealthBar.SetValue(value);

            if (_currentHP < 0) _currentHP = 0;
            if (_currentHP > Stats.HP) _currentHP = Stats.HP;
        }
    }

    public float Mana
    {
        get
        {
            return _currentMana;
        }
        set
        {
            _currentMana = value;
            ManaBar.SetValue(value);

            if (_currentMana < 0) _currentMana = 0;
            if (_currentMana > Stats.Mana) _currentMana = Stats.Mana;
        }
    }

    public float Stamina
    {
        get
        {
            return _currentStamina;
        }
        set
        {
            _currentStamina = value;
            StaminaBar.SetValue(value);

            if (_currentStamina < 0) _currentStamina = 0;
            if (_currentStamina > Stats.Stamina) _currentStamina = Stats.Stamina;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetMaxValue(Stats.HP);
        ManaBar.SetMaxValue(Stats.Mana);
        StaminaBar.SetMaxValue(Stats.Stamina);
        HealthBar.SetValue(Stats.HP);
        ManaBar.SetValue(Stats.Mana);
        StaminaBar.SetValue(Stats.Stamina);

        _currentHP = Stats.HP;
        _currentMana = Stats.Mana;
        _currentStamina = Stats.Stamina;
    }
}
