using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator _animator;

    [SerializeField] private AttackInvoker _attackInvoker;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float viewRange;
    [SerializeField] private float attackRange;

    public GameObject Target;

    //States
    private bool playerInViewRange = false;
    private bool playerInAttackRange = false;
    private bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movingSpeed;
        navMeshAgent.updateRotation = false;
        _animator = GetComponent<Animator>();
        

        _attackInvoker.EndAttack += () => isAttack = false;
    }

    private void Update()
    {
        if (!isAttack)
        {
            float r = Vector3.Distance(transform.position, Target.transform.position);
            playerInViewRange = r < viewRange;
            playerInAttackRange = r < attackRange;


            if (playerInViewRange && !playerInAttackRange) MoveToTarget();

            if (playerInAttackRange && playerInViewRange) AttackPlayer();

            _animator.SetFloat("Speed", Vector3.Distance(navMeshAgent.destination, transform.position));
        }
        else
        {
            //Костыль
            //transform.LookAt(Target.transform);
        }
    }
    private void MoveToTarget() // устанвливает точку движения к цели
    {
        navMeshAgent.SetDestination(Target.transform.position);
        transform.LookAt(Target.transform);
    }

    private void AttackPlayer()
    {
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(Target.transform);
        _attackInvoker.Attack();
        isAttack = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRange);
    }
}
