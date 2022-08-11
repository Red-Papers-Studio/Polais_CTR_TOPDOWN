using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator _animator;

    [SerializeField] private EnemyAttackInvoker _attackInvoker;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float viewRange;
    [SerializeField] private float attackRange;

    public GameObject Target;

    //States
    private bool playerInViewRange = false;
    private bool playerInAttackRange = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movingSpeed;
        navMeshAgent.updateRotation = false;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float r = Vector3.Distance(transform.position, Target.transform.position);
        playerInViewRange = r <  viewRange;
        playerInAttackRange = r < attackRange;

        Debug.Log($"v - {playerInViewRange}  A - {playerInAttackRange}");
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
        _attackInvoker.Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRange);
    }
}
