using UnityEngine;

namespace Assets.Scripts.SkillScripts
{
    public class BladeOfWindSkill : Skill
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private GameObject _windObject;
        [SerializeField] private SkillData _skillData;
        [SerializeField] private float _windSpeed;

        private void Start()
        {
            _windObject.SetActive(false);
        }

        protected override void AttackAction(SkillData skillData)
        {
            _windObject.SetActive(true);
            _windObject.transform.position = _target.position;
            _windObject.transform.rotation = _target.rotation;
            var wind = Instantiate(_windObject, _spawnTransform.position, _spawnTransform.rotation);
            wind.GetComponent<Rigidbody>().velocity = _spawnTransform.transform.forward * _windSpeed;
        }
    }
}
