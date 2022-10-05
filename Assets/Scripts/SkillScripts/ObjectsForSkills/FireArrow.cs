using UnityEngine;

public class FireArrow : MonoBehaviour
{
    [SerializeField]
    private SkillData skillData;
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
            target.Damage(skillData.Damage);
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
