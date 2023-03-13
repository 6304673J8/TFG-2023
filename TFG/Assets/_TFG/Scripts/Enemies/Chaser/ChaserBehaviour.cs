using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
public class ChaserBehaviour : EnemyBehaviour
{
    [Header("Lunge variables")]
    private float _lungeDistance;
    [SerializeField] float lungeSpeed;
    [SerializeField] float timeBeforeAttacking;

    private int _currentDamage;
    [SerializeField] int normalDamage;
    [SerializeField] int lungeDamage;
    private float _initSpeed;
    private float _initYPos;
    Animator animator;

    NavMeshPath lungePath;

    private bool isLunging;

    Vector3 attackPos;

    protected override void Start()
    {
        base.Start();
        isLunging = false;
        agent.autoTraverseOffMeshLink = false;
        animator = GetComponentInChildren<Animator>();
        _initSpeed = agent.speed;
        _currentDamage = normalDamage;
        _initYPos = transform.position.y;
        attackPos = transform.GetChild(2).transform.position;
    }

    protected override void Update()
    {
        base.Update();

        if (isLunging && agent.remainingDistance <= agent.stoppingDistance + 0.25f)
        {
            isAttacking = false;
            isLunging = false;
            _currentDamage = normalDamage;
            agent.speed = _initSpeed;
            animator.SetBool("Charge", false);
        }
    }

    public override void AttackAction()
    {
        StartCoroutine(LungeTowards());
    }

    private IEnumerator LungeTowards()
    {

        agent.speed = 0f;
        agent.destination = transform.position;

        animator.SetTrigger("Attack");
        //AkSoundEngine.PostEvent("Preparing_Lunge_Chaser", gameObject);

        yield return new WaitForSeconds(timeBeforeAttacking);

        animator.SetBool("Charge", true);
        //AkSoundEngine.PostEvent("Charging_Chaser", gameObject);

        _currentDamage = lungeDamage;

        _lungeDistance = Vector3.Distance(transform.position, player.transform.position);

        agent.speed = lungeSpeed;
        agent.destination = attackPos = transform.GetChild(2).position;
        lungePath = agent.path;
        isLunging = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
    }

    public void SetBigRadius()
    {
        detectionRadius = 500;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out Tinted health))
        {
            //playerHealth.GetComponent<CharacterController>().Move(transform.forward * impulseForce * Time.deltaTime);

            health.DoDamage(_currentDamage);
        }
    }
}
