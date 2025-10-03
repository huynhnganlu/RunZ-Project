using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
   
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(PlayerController.Instance.transform.position);
    }
}
