using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTarget : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private Transform _playerTransform;
    // Update is called once per frame
    void Update()
    {
        float zOffset = _playerTarget.position.z - _playerTransform.position.z;
        float xOffset = _playerTarget.position.x - _playerTransform.position.x;
        transform.position = new Vector3(_playerTransform.position.x + zOffset, _playerTarget.position.y, _playerTransform.position.z - xOffset);
    }
}
