using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMoving : MonoBehaviour
{
    public float Speed = 10f;
    public float RotationSpeed = 3f;

    //���������� ���������� ��� ���� �����
    public float RunBackReductionCoef = 2f;

    private Rigidbody _rb;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float accelaration = Input.GetAxis("Acceleration") == 0 ? 1 : Input.GetAxis("Acceleration");


        Rotation(moveHorizontal);
        Move(moveVertical, accelaration);
        Animation(moveVertical);
    }

    private void Rotation(float moveHorizontal)
    {
        Quaternion quaternion =
            Quaternion.Euler(new Vector3(0, moveHorizontal * RotationSpeed, 0) + _rb.rotation.eulerAngles);

        _rb.MoveRotation(quaternion);
    }

    private void Move(float moveVertical, float accelaration)
    {
        moveVertical = moveVertical > 0 ? moveVertical : moveVertical / RunBackReductionCoef;

        Vector3 movement = new Vector3(0f, 0f, moveVertical);

        _rb.AddRelativeForce(movement * Speed * accelaration);
    }

    private void Animation( float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
