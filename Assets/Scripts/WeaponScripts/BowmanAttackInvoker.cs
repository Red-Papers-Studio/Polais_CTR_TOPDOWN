using UnityEngine;
using System;
public class BowmanAttackInvoker : AttackInvoker
{
    public event Action EndAttack;
    public override void Attack()
    {
        _animator.SetBool("Shoot", true);
    }

    private void EndAttackAnimation()
    {
        _animator.SetBool("Shoot", false);
        EndAttack?.Invoke();
    }
}
