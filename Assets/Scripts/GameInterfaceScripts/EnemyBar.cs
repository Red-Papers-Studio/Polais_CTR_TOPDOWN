using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBar : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    void LateUpdate()
    {
        transform.LookAt(_camera);
    }
}
