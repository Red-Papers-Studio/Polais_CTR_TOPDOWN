using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private GameObject test;
    [SerializeField] private Transform bowTarget;
    [SerializeField] private float RotationSpeed = 3f;

    [Range(0, 1)]
    [SerializeField] private float MoveSpeedShangePerFrame = 0.05f;

    [SerializeField] private float StaminaCostPerFrame = 2f;
    [SerializeField] private PlayerStats Stats;

    private const float maxAccelaration = 2;
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

        Rotation();
        Move(moveVertical, moveHorizontal, accelaration);
    }

    private void Rotation()
    {
        Vector3 Mpos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(Mpos);
       
        var hits = Physics.RaycastAll(mouseRay, float.MaxValue, 3);

        RaycastHit hit = hits.LastOrDefault(x => x.collider.gameObject.tag == "ForRaycast");
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
        _characterController.Move(new Vector3(0, -0.1f, 0));
        if (accelaration < 1)
        {
            accelaration = 1;
            Stats.Stamina += StaminaCostPerFrame;
        }
        else
        {
            if (Stats.Stamina > 0)
            {
                accelaration = maxAccelaration;
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

        float vSpeed = 0;
        float hSpeed = 0;

        
        if (angle > LeftUpEdge && angle <= RigthUpEdge)
        {
            vSpeed = speed;
            hSpeed = horizontalSpeed;
        }
        else if (angle > RigthUpEdge && angle <= RigthDownEdge)
        {
            vSpeed = horizontalSpeed;
            hSpeed = -speed;
        }
        else if (angle > RigthDownEdge && angle < 1 || angle <= LeftDownEdge)
        {

            vSpeed = -speed;
            hSpeed = -horizontalSpeed;
        }
        else if (angle > LeftDownEdge && angle <= LeftUpEdge)
        {
            vSpeed = -horizontalSpeed;
            hSpeed = speed;
        }

        Vector2 currentSpeed = new Vector2(_animator.GetFloat("Speed"), _animator.GetFloat("HorizontalSpeed"));
        Vector2 targetSpeed = new Vector2(vSpeed, hSpeed);
        Vector2 movement = Vector2.MoveTowards(currentSpeed, targetSpeed, 0.05f);

        _animator.SetFloat("Speed", movement.x);
        _animator.SetFloat("HorizontalSpeed", movement.y);

        if(currentSpeed.x == maxAccelaration)
        {
            Stats.Stamina -= StaminaCostPerFrame;
        }
    }
}
