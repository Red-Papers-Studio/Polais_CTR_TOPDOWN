using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private GameObject test;
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float RotationSpeed = 3f;
    [SerializeField] private float RunBackReductionCoef = 2f;
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
        Move(moveVertical, moveHorizontal, accelaration);
    }

    private void Rotation(float moveHorizontal)
    {
        //Quaternion quaternion =
        //    Quaternion.Euler(new Vector3(0, moveHorizontal * RotationSpeed, 0) + _rb.rotation.eulerAngles);

        //_rb.MoveRotation(quaternion);

        Vector3 Mpos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(Mpos);
        RaycastHit hit;
        Physics.Raycast(mouseRay, out hit);

        Vector3 pos = hit.point;
        pos.y = transform.position.y;
        Vector3 coordinate = pos;

        test.transform.position = coordinate;
        transform.LookAt(coordinate);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(coordinate), RotationSpeed * Time.deltaTime);
    }

    private void Move(float moveVertical, float moveHorizontal, float accelaration)
    {
        moveVertical = moveVertical > 0 ? moveVertical : moveVertical / RunBackReductionCoef;
        moveHorizontal = moveHorizontal / RunBackReductionCoef;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (accelaration < 1)
        {
            accelaration = 1;
            //������������� ������� ������ ���� ��� ����
            Stats.Stamina += StaminaCostPerFrame / 10;
        }
        else
        {
            if (Stats.Stamina > 0)
            {
                Stats.Stamina -= StaminaCostPerFrame;
                accelaration *= AccelarationMultiplyCoef;
            }
        }

        _rb.AddForce(movement * Speed * accelaration);

        Animation(Speed * accelaration * moveVertical, moveHorizontal);
    }

    private void Animation(float speed, float horizontalSpeed)
    {
        float angle = transform.rotation.y;
        float LeftUpEdge = -0.25f;
        float RigthUpEdge = 0.25f;
        float LeftDownEdge = -0.9f;
        float RigthDownEdge = 0.9f;

        if (angle > LeftUpEdge && angle < RigthUpEdge)
        {
            _animator.SetFloat("Speed", speed);
            _animator.SetFloat("HorizontalSpeed", horizontalSpeed);
            Debug.Log($"{transform.rotation.y} Up");
        }
        else if (angle > RigthUpEdge && angle < RigthDownEdge)
        {
            _animator.SetFloat("Speed", horizontalSpeed * 10);
            _animator.SetFloat("HorizontalSpeed", -speed);
            Debug.Log($"{transform.rotation.y} Rigth");
        }
        else if (angle > RigthDownEdge && angle < 1 || angle < LeftDownEdge)
        {
            _animator.SetFloat("Speed", -speed);
            _animator.SetFloat("HorizontalSpeed", -horizontalSpeed);
            Debug.Log($"{transform.rotation.y} Down");
        }
        else if (angle > LeftDownEdge && angle < LeftUpEdge)
        {
            _animator.SetFloat("Speed", -horizontalSpeed *10);
            _animator.SetFloat("HorizontalSpeed", speed);
            Debug.Log($"{transform.rotation.y} Left");
        }
    }
}
