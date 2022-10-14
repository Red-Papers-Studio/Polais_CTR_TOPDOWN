using Assets.Scripts.SkillScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkill : ImpulseSkill
{
    [SerializeField] private string _boolParameterForSkill = "IsFireBallAttack";
    [SerializeField] private string _createObjectValue = "CreateFireBall";
    [SerializeField] private string _endAnimationValue = "EndFireBallCastAnimation";

    protected override void Initialize(out string boolParameterForSkill, out string createObjectValue, out string endAnimationValue)
    {
        boolParameterForSkill = _boolParameterForSkill;
        createObjectValue = _createObjectValue;
        endAnimationValue = _endAnimationValue;
    }
}
