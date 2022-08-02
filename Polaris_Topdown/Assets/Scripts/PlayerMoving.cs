using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMoving : MonoBehaviour
{
    public float Speed = 10f;
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

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _animator.SetFloat("VerticalSpeed", moveVertical);
        _animator.SetFloat("HorisontalSpeed", -moveHorizontal);
        _animator.SetFloat("Acceleration", accelaration);

        _rb.AddForce(movement * Speed * accelaration);
    }
}
