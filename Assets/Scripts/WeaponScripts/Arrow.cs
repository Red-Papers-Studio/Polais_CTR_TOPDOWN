using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private LongRangeWeaponData weaponData;
    [SerializeField]
    private float lifeTime;
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable target = collision.gameObject.GetComponent<IDamageable>();
        target?.Damage(weaponData.Damage);
    }
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
