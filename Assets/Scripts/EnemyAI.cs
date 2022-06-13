using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] Transform player;

    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    [SerializeField] float health;

    Animator animatorRef;

    //Patroling
    [SerializeField] Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;
    [SerializeField] bool shouldMove=true;

    //Attacking
    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    [SerializeField] float sightRange, attackRange;
    [SerializeField] bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
        animatorRef = GetComponent<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && shouldMove) Patroling();
        if (playerInSightRange && !playerInAttackRange && shouldMove) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!shouldMove) return;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            animatorRef.SetBool("IsMoving", true);
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            animatorRef.SetBool("IsMoving", false);
            StartCoroutine(aguardarMovimento());
            walkPointSet = false;
            Debug.Log("Chegada");
            
        }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            animatorRef.SetBool("IsMoving", true);
            walkPointSet = true;
            
        }

    }

    private void ChasePlayer()
    {
        if (!shouldMove) return;
        animatorRef.SetBool("IsMoving", true);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

        if (!alreadyAttacked)
        {
            animatorRef.SetBool("IsMoving", false);
            ///Attack code here
            //animatorRef.SetTrigger("Attack");
            animatorRef.Play("standHit");
            Debug.Log("Ataque");

            player.GetComponent<PlayerHealth>().TakeDamage(10);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        StartCoroutine(aguardarMovimento());
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator aguardarMovimento()
    {
        shouldMove = false;
        agent.isStopped=true;
        yield return new WaitForSeconds(0.7f);
        shouldMove = true;
        agent.isStopped = false;

    }
    
}
