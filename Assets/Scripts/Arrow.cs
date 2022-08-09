using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private LongRangeWeaponData weaponData;
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        target?.Damage(weaponData.Damage);
    }
    private void Awake()
    {
        Destroy(gameObject, 4);
    }
}
