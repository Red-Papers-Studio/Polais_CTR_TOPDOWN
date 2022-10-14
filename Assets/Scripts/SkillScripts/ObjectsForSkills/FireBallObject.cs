﻿using UnityEngine;

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
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
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
