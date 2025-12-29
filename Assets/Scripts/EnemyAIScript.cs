using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float chaseRange;
    [SerializeField] private int enemyHealth;


    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
           agent.SetDestination(player.position);
        }
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
