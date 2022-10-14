using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Assets.Scripts.SkillScripts
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent (typeof(Collider))]
    public class FireBallObject : MonoBehaviour
    {
        [SerializeField]
        private SkillData _skillData;
        [SerializeField]
        private float _attackDistance = 10;

        [SerializeField] private float _destoyAfterPassedTime = 1;
        [SerializeField] private VisualEffect _visualEffect;
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
            StartCoroutine(DestroyObjectCoroutine());
        }

        private IEnumerator DestroyObjectCoroutine()
        {
            
            _visualEffect.SetFloat("SizeMultiplier", 1f);
            yield return new WaitForSeconds(_destoyAfterPassedTime - 1);
            for (int i = 0; i < 10; ++i)
            {
                _visualEffect.SetFloat("SizeMultiplier", _visualEffect.GetFloat("SizeMultiplier") - 0.1f);
                yield return new WaitForSeconds(0.1f);
            }
            _visualEffect.SetFloat("SizeMultiplier", 0f);
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            if(_attackDistance <= Vector3.Distance(_startPosition, transform.position))
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
            {
                target.Damage(_skillData.Damage);
            }
            Destroy(gameObject);
        }
    }
}
