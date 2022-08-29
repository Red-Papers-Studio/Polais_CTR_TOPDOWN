using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private GameObject test;
    [SerializeField] private Transform bowTarget;
    [SerializeField] private float RotationSpeed = 3f;

    [SerializeField] private float StaminaCostPerFrame = 2f;
    [SerializeField] private PlayerStats Stats;

    private CharacterController _characterController;
    private Animator _animator;

    public bool isArrowAttack;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _animator.applyRootMotion = true;
        isArrowAttack = false;
    }

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
        Vector3 Mpos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(Mpos);
        RaycastHit hit;
        Physics.Raycast(mouseRay, out hit);

        Vector3 pos = hit.point;
        pos.y = transform.position.y;

        Vector3 coordinate = pos;

        test.transform.position = coordinate;

        if (isArrowAttack)
        {
            Vector3 direction = bowTarget.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), RotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(coordinate - transform.position), RotationSpeed);
        }    
    }

    private void Move(float moveVertical, float moveHorizontal, float accelaration)
    {
        if (accelaration < 1)
        {
            accelaration = 1;
            Stats.Stamina += StaminaCostPerFrame;
        }
        else
        {
            if (Stats.Stamina > 0)
            {
                Stats.Stamina -= StaminaCostPerFrame;
                accelaration = 2;
            }
        }

        Animation(moveVertical * accelaration, moveHorizontal * accelaration);
    }

    private void OnAnimatorMove()
    {
        Vector3 velocity = _animator.deltaPosition;

        _characterController.Move(velocity);
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
        }
        else if (angle > RigthUpEdge && angle < RigthDownEdge)
        {
            _animator.SetFloat("Speed", horizontalSpeed);
            _animator.SetFloat("HorizontalSpeed", -speed);
        }
        else if (angle > RigthDownEdge && angle < 1 || angle < LeftDownEdge)
        {
            _animator.SetFloat("Speed", -speed);
            _animator.SetFloat("HorizontalSpeed", -horizontalSpeed);
        }
        else if (angle > LeftDownEdge && angle < LeftUpEdge)
        {
            _animator.SetFloat("Speed", -horizontalSpeed);
            _animator.SetFloat("HorizontalSpeed", speed);
        }
    }
}
