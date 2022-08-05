using UnityEngine;

public class ShortRangeWeapon : MonoBehaviour
{
    [SerializeField]
    private ShortRangeWeaponData weaponData;

    void Start()
    {
        PlayerAttack.Attack += Attack;
        PlayerBlock.Block += Block;
    }
    
    private void Attack()
    {
        Debug.Log(weaponData.Name + " attacked in short range with damage " + weaponData.Damage);
    }

    private void Block()
    {
        Debug.Log(weaponData.Name + " blocked damage " + weaponData.Block);
    }
}
