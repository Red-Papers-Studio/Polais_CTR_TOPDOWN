using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private LongRangeWeaponData weaponData;
    [SerializeField]
    private float lifeTime;
    private Collider _arrowCollider;
    private Rigidbody _arrowRigidbody;

    private void Start()
    {
        _arrowRigidbody = GetComponent<Rigidbody>();
        _arrowCollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //IDamageable target = collision.gameObject.GetComponent<IDamageable>();
        //target?.Damage(weaponData.Damage);
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            Debug.Log(weaponData.name + " damage");
            target.Damage(weaponData.Damage);
        }
        _arrowRigidbody.Sleep();
        _arrowCollider.enabled = false;
        transform.parent = collision.gameObject.transform;
        
    }
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
