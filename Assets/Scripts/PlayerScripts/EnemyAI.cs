using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField][Range(0, 360)] private float viewAngle;
    [SerializeField] private float viewDistance = 20f;
    //[SerializeField] private float changePositionTime;
    //[SerializeField] private float enemyMovingDistance;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float detectionDistance;
    [SerializeField] private float rotationSpeed;
    public Transform EnemyEye;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movingSpeed;
        navMeshAgent.updateRotation = false;
        animator = GetComponent<Animator>();
        //InvokeRepeating(nameof(EnemyMove), changePositionTime, changePositionTime);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(Target.transform.position, navMeshAgent.transform.position);
        if (distanceToPlayer <= detectionDistance || IsInView())
        {
            RotateToTarget();
            MoveToTarget();
            //animator.SetFloat("Speed", movingSpeed);
        }
        DrawViewState();
        
    }

    private bool IsInView() // true если цель видна
    {
        float realAngle = Vector3.Angle(EnemyEye.forward, Target.transform.position - EnemyEye.position);
        RaycastHit hit;
        
        if (Physics.Raycast(EnemyEye.transform.position, Target.transform.position - EnemyEye.position, out hit, viewDistance))
        {
            if (realAngle < viewAngle / 2f && Vector3.Distance(EnemyEye.position, Target.transform.position) <= viewDistance)
            {
                return true;
            }
        }
        return false;
    }
    private void RotateToTarget() // поворачивает в сторону цели со скоростью rotationSpeed
    {
        Vector3 lookVector = Target.transform.position - navMeshAgent.transform.position;
        lookVector.y = 0;
        if (lookVector == Vector3.zero) return;
        navMeshAgent.transform.rotation = Quaternion.RotateTowards
        (
            navMeshAgent.transform.rotation,
            Quaternion.LookRotation(lookVector, Vector3.up),
            rotationSpeed * Time.deltaTime
        );
    }
    private void MoveToTarget() // устанвливает точку движения к цели
    {
        navMeshAgent.SetDestination(Target.transform.position);
    }

    private void DrawViewState()
    {
        Vector3 left = EnemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2f, 0)) * (EnemyEye.forward * viewDistance);
        Vector3 right = EnemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2f, 0)) * (EnemyEye.forward * viewDistance);
        Debug.DrawLine(EnemyEye.position, left, Color.yellow);
        Debug.DrawLine(EnemyEye.position, right, Color.yellow);
    }



    //public Vector3 RandomNavSphere(float distance)
    //{
    //    Vector3 randomDirection = Random.insideUnitSphere * distance;

    //    randomDirection += transform.position;

    //    NavMeshHit navMeshHit;

    //    NavMesh.SamplePosition(randomDirection, out navMeshHit, distance, -1);

    //    return navMeshHit.position;
    //}

    //private void EnemyMove()
    //{
    //    navMeshAgent.SetDestination(RandomNavSphere(enemyMovingDistance));
    //}
}
