using UnityEngine;

namespace Assets.Scripts.SkillScripts
{
    public class WindObject : MonoBehaviour
    {
        [SerializeField]
        private SkillData _skillData;
        [SerializeField]
        private float lifeTime;
        private Collider _arrowCollider;
        [SerializeField]
        private float _windAttackDistance = 0;
        private float _distanceToTarget;

        private void Start()
        {
            _arrowCollider = GetComponent<Collider>();
        }

        private void FixedUpdate()
        {
            if(_windAttackDistance >= _distanceToTarget)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
            {
                target.Damage(_skillData.Damage);
                Destroy(gameObject);
            }
        }
    }
}
