using UnityEngine;

namespace Assets.Scripts.SkillScripts
{
    public class BladeOfWindSkill : Skill
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private GameObject _windObject;
        [SerializeField] private float _windSpeed;
        [SerializeField] private Animator _animator;

        protected override void AttackAction(SkillData skillData)
        {
            _animator.SetBool("IsWindBladeAttack", true);
            
        }

        public void CreateWind()
        {
            var wind = Instantiate(_windObject, _spawnTransform.position, _spawnTransform.rotation);
            wind.GetComponent<Rigidbody>().velocity = _spawnTransform.transform.forward * _windSpeed;
        }

        public void EndAnimation()
        {
            _animator.SetBool("IsWindBladeAttack", false);
            _isSkillActive = false;
        }
    }
}
