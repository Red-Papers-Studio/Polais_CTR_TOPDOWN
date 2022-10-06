using UnityEngine;

namespace Assets.Scripts.SkillScripts
{
    public class BladeOfWindSkill : Skill
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private GameObject _windObject;
        [SerializeField] private float _windSpeed;

        protected override void AttackAction(SkillData skillData)
        {
            var wind = Instantiate(_windObject, _spawnTransform.position, _spawnTransform.rotation);
            wind.GetComponent<Rigidbody>().velocity = _spawnTransform.transform.forward * _windSpeed;
        }
    }
}
