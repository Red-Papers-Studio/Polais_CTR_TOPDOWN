
public class BowmanAttackInvoker : AttackInvoker
{
    public override void Attack()
    {
        //Костыль
        transform.Rotate(0, 90, 0);


        _animator.SetBool("Shoot", true);
    }

    protected override void EndAttackAnimation()
    {
        _animator.SetBool("Shoot", false);
        base.EndAttackAnimation();
    }
}
