using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float viewRange;
    [SerializeField] private float attackRange;

    public Transform EnemyEye;
    public GameObject Target;

    //States
    private bool playerInViewRange;
    private bool playerInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movingSpeed;
        navMeshAgent.updateRotation = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerInViewRange = Physics.CheckSphere(transform.position, viewRange);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange);

        if (playerInViewRange && !playerInAttackRange) MoveToTarget();

        if (playerInAttackRange && playerInViewRange) AttackPlayer();
    }
    private void MoveToTarget() // устанвливает точку движения к цели
    {
        navMeshAgent.SetDestination(Target.transform.position);
        //animator.SetFloat("Speed", movingSpeed);
        transform.LookAt(Target.transform);
    }

    private void AttackPlayer()
    {
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(Target.transform);
        PlayerAttack.Attack?.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRange);
    }
}
