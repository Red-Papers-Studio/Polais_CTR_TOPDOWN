using UnityEngine;

namespace Assets.Scripts.SkillScripts
{
    public class BladeOfWindSkill : ImpulseSkill
    {
        [SerializeField] private string _boolParameterForSkill = "IsWindBladeAttack";
        [SerializeField] private string _createObjectValue = "CreateWind";
        [SerializeField] private string _endAnimationValue = "EndWindBladeCastAnimationAnimation";

        protected override void Initialize(out string boolParameterForSkill, out string createObjectValue, out string endAnimationValue)
        {
            boolParameterForSkill = _boolParameterForSkill;
            createObjectValue = _createObjectValue;
            endAnimationValue = _endAnimationValue;
        }
    }
}
