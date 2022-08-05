using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float RotationSpeed = 3f;
    //���������� ���������� ��� ���� �����
    [SerializeField] private float RunBackReductionCoef = 2f;
    //���������� ���������
    [SerializeField] private float AccelarationMultiplyCoef = 2f;

    [SerializeField] private float StaminaCostPerFrame = 2f;
    [SerializeField] private PlayerStats Stats;

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
        float accelaration = Input.GetAxis("Acceleration");

        Rotation(moveHorizontal);
        Move(moveVertical, accelaration);
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

        if (accelaration < 1)
        {
            accelaration = 1;
            //������������� ������� ������ ���� ��� ����
            Stats.Stamina += StaminaCostPerFrame/10;
        }
        else
        {
            if (Stats.Stamina > 0)
            {
                Stats.Stamina -= StaminaCostPerFrame;
                accelaration *= AccelarationMultiplyCoef;
            }
        }

        _rb.AddRelativeForce(movement * Speed * accelaration);

        Animation(Speed * accelaration * moveVertical);
    }

    private void Animation(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
