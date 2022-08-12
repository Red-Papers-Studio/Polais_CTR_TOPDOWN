using System;
public class GuardAttackInvoker : AttackInvoker
{
    public override void Attack()
    {
        _animator.SetBool("SimpleAttack", true);
    }

    protected override void EndAttackAnimation()
    {
        _animator.SetBool("SimpleAttack", false);
        base.EndAttackAnimation();
    }
}
