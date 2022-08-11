using System;
using UnityEngine;

public abstract class AttackInvoker : MonoBehaviour
{
    public event Action OnAttack;

    public virtual void Attack()
    {
        OnAttack?.Invoke();
    }
}
