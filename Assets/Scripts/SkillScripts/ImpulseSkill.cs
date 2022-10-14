using UnityEngine;

namespace Assets.Scripts.SkillScripts
{
    public abstract class ImpulseSkill : Skill
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private GameObject _spawnObject;
        [SerializeField] private float _objectSpeed;
        [SerializeField] private GeneralAnimationController _animationController;

        [HideInInspector] private string _boolParameterForSkill;
        [HideInInspector] private string _createObjectValue;
        [HideInInspector] private string _endAnimationValue;

        protected abstract void Initialize(out string boolParameterForSkill, out string createObjectValue, out string endAnimationValue);
        protected override void AttackAction(SkillData skillData)
        {
            _animationController.Animator.SetBool(_boolParameterForSkill, true);
            _animationController.OnAnimatorInvoke += AnimatorInvokeHandler;
        }

        public void CreateObject()
        {
            var obj = Instantiate(_spawnObject, _spawnTransform.position, _spawnTransform.rotation);
            obj.GetComponent<Rigidbody>().velocity = _spawnTransform.transform.forward * _objectSpeed;
        }

        public void EndAnimation()
        {
            _animationController.Animator.SetBool(_boolParameterForSkill, false);
            _animationController.OnAnimatorInvoke -= AnimatorInvokeHandler;
            _isSkillActive = false;
        }

        private void AnimatorInvokeHandler(Animator animator, string value)
        {
            if (value == _createObjectValue)
            {
                CreateObject();
            }
            else if (value == _endAnimationValue)
            {
                EndAnimation();
            }
        }

        private void Start()
        {
            Initialize(out _boolParameterForSkill, out _createObjectValue, out _endAnimationValue);
        }
    }
}
