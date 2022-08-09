using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private LongRangeWeaponData weaponData;
    [SerializeField]
    private float lifeTime;
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        target?.Damage(weaponData.Damage);
    }
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
