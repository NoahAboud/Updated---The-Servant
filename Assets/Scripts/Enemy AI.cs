using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;

    private Animator anim;
    private NavMeshAgent agent;
    private float lastAttackTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= attackRange)
        {
            // Attack
            agent.isStopped = true;
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", true);

            // Attack cooldown
            if (Time.time - lastAttackTime > attackCooldown)
            {
                lastAttackTime = Time.time;
                // You can add damage code here
                Debug.Log("Enemy attacks!");
            }
        }
        else if (distance <= chaseRange)
        {
            // Chase
            agent.isStopped = false;
            agent.SetDestination(player.position);
            anim.SetBool("isRunning", true);
            anim.SetBool("isAttacking", false);
        }
        else
        {
            // Idle
            agent.isStopped = true;
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
        }
    }
}

