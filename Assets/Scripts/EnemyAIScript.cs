using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float chaseRange;
    [SerializeField] private int enemyHealth;
    private bool isProvoked;


    private void Update()
    {

        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            isProvoked = true;
        }

        if (isProvoked)
        {
            EngageTarget();
        }
    }

    private void EngageTarget()
    {
        if (Vector3.Distance(transform.position, player.position) > agent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
        {
            Attack();
        }
    }

    private void ChaseTarget()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        Debug.Log("Attacking");
    }

    public void DealDamage(int damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        { 
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
