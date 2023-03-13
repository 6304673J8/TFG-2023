using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    [Header("NavMesh variables")]
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    protected NavMeshAgent agent;

    [Header("Player detection variables")]
    [SerializeField] protected LayerMask playerMask;
    protected GameObject player;
    protected DangerManager dangerManager;

    [Header("AI Variables")]
    [SerializeField] protected float attackRadius;
    [SerializeField] protected float detectionRadius;
    [SerializeField] protected float timeBetweenAttacks;
    protected bool playerInSightRange, playerInAttackRange, canAttack, isAttacking;
    protected virtual void Start()
    {
        isAttacking = false;
        player = GameObject.FindGameObjectWithTag("Player");
        dangerManager = player.GetComponent<DangerManager>();
        agent = GetComponent<NavMeshAgent>();
        canAttack = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!playerInSightRange)
        {
            if (dangerManager.enemyList.Contains(gameObject))
            {
                dangerManager.enemyList.Remove(gameObject);
            }

            Idle();
        }

        if (playerInSightRange)
        {
            if (!dangerManager.enemyList.Contains(gameObject))
            {
                dangerManager.enemyList.Add(gameObject);
            }
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }

        if (playerInSightRange && !playerInAttackRange && !isAttacking)
        {
            ChasePlayer();
        }

        if (playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    protected virtual void FixedUpdate()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, detectionRadius, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRadius, playerMask);
    }

    protected virtual void Idle()
    {
        agent.SetDestination(transform.position);
    }
    protected virtual void ChasePlayer()
    {
        agent.destination = player.transform.position;
        ExtraFunctionality();
    }

    protected virtual void ExtraFunctionality() { }
    protected virtual void AttackPlayer()
    {
        if (canAttack)
        {
            isAttacking = true;
            AttackAction();
            canAttack = false;
            StartCoroutine(ResetAttack());
        }
    }

    public virtual void AttackAction()
    {

    }

    protected IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
