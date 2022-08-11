using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private GameObject test;
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float RotationSpeed = 3f;
    //Понижающий коэфициент при беге назад
    [SerializeField] private float RunBackReductionCoef = 2f;
    //Коэфициент ускорения
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
        Vector3 Mpos = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenPointToRay(Mpos).direction * 12;
        pos.y = transform.position.y;
        Vector3 coordinate = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z) + pos;
        test.transform.position = coordinate;
        transform.LookAt(coordinate);
    }

    private void Move(float moveVertical, float moveHorizontal, float accelaration)
    {
        moveVertical = moveVertical > 0 ? moveVertical : moveVertical / RunBackReductionCoef;
        moveHorizontal = moveHorizontal / RunBackReductionCoef;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (accelaration < 1 || movement.x != 0 || movement.z <= 0)
        {
            accelaration = 1;
            //Востановление стамины каждый кадр без бега
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

        _rb.AddRelativeForce(movement * Speed * accelaration);

        Animation(Speed * accelaration * moveVertical);
    }

    private void Animation(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
