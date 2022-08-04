using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stats Stats = new Stats(100, 100, 100);
    public float CurrentHP;
    public float CurrentMana;
    public float CurrentStamina;

    public Bar HealthBar;
    public Bar ManaBar;
    public Bar StaminaBar;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetMaxValue(Stats.HP);
        ManaBar.SetMaxValue(Stats.Mana);
        StaminaBar.SetMaxValue(Stats.Stamina);
        HealthBar.SetValue(Stats.HP);
        ManaBar.SetValue(Stats.Mana);
        StaminaBar.SetValue(Stats.Stamina);

        CurrentHP = Stats.HP;
        CurrentMana = Stats.Mana;
        CurrentStamina = Stats.Stamina;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeMana();
            TakeDamage();
        }
        if(CurrentHP < 0) CurrentHP = 0;
        
        if(CurrentHP > Stats.HP) CurrentHP = Stats.HP;

        if(CurrentMana < 0) CurrentMana = 0;

        if(CurrentMana > Stats.Mana) CurrentMana = Stats.Mana;

        if(CurrentStamina < 0) CurrentStamina = 0;

        if (CurrentStamina > Stats.Stamina) CurrentStamina = Stats.Stamina;

        HealthBar.SetValue(CurrentHP);
    }

    void TakeDamage()
    {
        CurrentHP -= 5f;
        HealthBar.SetValue(CurrentHP);
    }

    void TakeMana()
    {
        CurrentMana -= 5f;
        ManaBar.SetValue(CurrentMana);
    }
}
