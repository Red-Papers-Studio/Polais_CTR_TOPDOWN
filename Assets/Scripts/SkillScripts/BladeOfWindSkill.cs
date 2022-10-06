using UnityEngine;

namespace Assets.Scripts.SkillScripts
{
    public class BladeOfWindSkill : Skill
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private GameObject _windObject;
        [SerializeField] private float _windSpeed;
        [SerializeField] private GeneralAnimationController _animationController;

        protected override void AttackAction(SkillData skillData)
        {
            _animationController.Animator.SetBool("IsWindBladeAttack", true);
            _animationController.OnAnimatorInvoke += AnimatorInvokeHandler;
        }

        public void CreateWind()
        {
            var wind = Instantiate(_windObject, _spawnTransform.position, _spawnTransform.rotation);
            wind.GetComponent<Rigidbody>().velocity = _spawnTransform.transform.forward * _windSpeed;
        }

        public void EndAnimation()
        {
            _animationController.Animator.SetBool("IsWindBladeAttack", false);
            _animationController.OnAnimatorInvoke -= AnimatorInvokeHandler;
            _isSkillActive = false;
        }

        private void AnimatorInvokeHandler(Animator animator, string value)
        {
            if(value == "CreateWind")
            {
                CreateWind();
            }
            else if(value == "EndWindBladeCastAnimationAnimation")
            {
                EndAnimation();
            }
        }
    }
}
