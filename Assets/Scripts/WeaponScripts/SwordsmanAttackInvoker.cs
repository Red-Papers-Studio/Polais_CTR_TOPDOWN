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
