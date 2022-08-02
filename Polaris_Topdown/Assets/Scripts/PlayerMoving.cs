using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoving : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        float accelaration = Input.GetAxis("Accelaration");

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);

        _rb.AddForce(movement * Speed);
    }
}
