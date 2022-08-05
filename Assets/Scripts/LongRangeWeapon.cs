using UnityEngine;

public class LongRangeWeapon : MonoBehaviour
{
    [SerializeField]
    private LongRangeWeaponData weaponData;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAttack.Attack += Attack;
        PlayerBlock.Block += Block;
    }

    private void Attack()
    {
        Debug.Log(weaponData.Name + " attackted in long range with damage " + weaponData.Damage);
    }

    private void Block()
    {
        Debug.Log(weaponData.Name + " blocked in short range with damage " + weaponData.Block);
    }
}
