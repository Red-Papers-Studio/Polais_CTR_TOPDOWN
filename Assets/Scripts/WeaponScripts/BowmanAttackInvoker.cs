
public class BowmanAttackInvoker : AttackInvoker
{
    public override void Attack()
    {
        _animator.SetBool("Shoot", true);
    }

    protected override void EndAttackAnimation()
    {
        _animator.SetBool("Shoot", false);
        base.EndAttackAnimation();
    }
}
