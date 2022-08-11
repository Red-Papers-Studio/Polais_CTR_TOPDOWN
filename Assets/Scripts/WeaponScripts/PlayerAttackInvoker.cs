using System;
using UnityEngine;

public class PlayerAttackInvoker : AttackInvoker
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

}
