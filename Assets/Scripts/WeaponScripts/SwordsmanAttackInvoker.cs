using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanAttackInvoker : PlayerAttackInvoker
{
    public override void Attack()
    {
        _animator.SetBool("Attack", true);
    }
    protected override void EndAttackAnimation()
    {
        _animator.SetBool("Attack", false);
        base.EndAttackAnimation();
    }
}
