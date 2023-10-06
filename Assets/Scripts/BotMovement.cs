using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BotMovement : MonoBehaviour
{
    private BotState botState;
    private NavMeshAgent agent;
    [SerializeField]
    private Transform playerFoot;
    [SerializeField]
    private float reachingRadius;


    private void Start()
    {
        botState = GetComponent<BotState>();
        agent = GetComponent<NavMeshAgent>();

        // Gọi coroutine để thay đổi điểm đích của bot sau mỗi khoảng thời gian
        StartCoroutine(ChangeDestination());
    }

    private IEnumerator ChangeDestination()
    {
        if (!botState.hasBomb)
        {
            while (true)
            {
                Vector3 randomPoint = GetRandomPointOnNavMesh();
                agent.SetDestination(randomPoint);

                yield return new WaitForSeconds(Random.Range(0.01f, 1f));
            }
        }
    }

    private Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10f;
        float randomRadius = Random.Range(5, 15);
        if (NavMesh.SamplePosition(randomPoint, out hit, randomRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return transform.position;
    }
    private void Update()
    {
        playerFoot = GameObject.FindGameObjectWithTag("PlayerFoot").transform; 
        if (botState.hasBomb)
        {
            float distance = Vector3.Distance(transform.position, playerFoot.position);
            if (distance > reachingRadius)
            {
                agent.isStopped = false;
                agent.SetDestination(playerFoot.position);
            }
            else
            {
                agent.isStopped = true;
            }
        }
    }
}
