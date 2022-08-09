using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static Action Attack;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack?.Invoke();
        }
    }

}
