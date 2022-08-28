using UnityEngine;
using Random = System.Random;
public class GuardAttackInvoker : AttackInvoker
{
    // 0 - SimpleAttack, 1 - HightAttack
    private int _attackNumber;
    private Random _random = new Random(); // ебаный рондом выдает одно и то же число
    public override void Attack()
    {
        _attackNumber = _random.Next(0, 100);
        Debug.Log(_attackNumber);
        if (_attackNumber <= 70) _animator.SetBool("SimpleAttack", true);
        else _animator.SetBool("HightAttack", true);
    }

    protected override void EndAttackAnimation()
    {
        if (_attackNumber <= 70) _animator.SetBool("SimpleAttack", false);
        else _animator.SetBool("HightAttack", false);
        base.EndAttackAnimation();
    }

}
