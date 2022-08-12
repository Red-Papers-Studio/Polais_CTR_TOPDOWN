using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AttackInvoker : MonoBehaviour
{
    public event Action OnAttack;
    protected Animator _animator;
    public event Action EndAttack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void Attack()
    {
        CompliteAttack();
    }

    public void AnimationConfiguration(WeaponData weaponData)
    {
        _animator.SetFloat("ReloadingTime", 1/weaponData.ReloadingTime);
    }

    protected void CompliteAttack()
    {
        OnAttack?.Invoke();
    }

    protected virtual void EndAttackAnimation()
    {
        EndAttack?.Invoke();
    }
}
