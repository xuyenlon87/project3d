using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BotMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Gọi coroutine để thay đổi điểm đích của bot sau mỗi khoảng thời gian
        StartCoroutine(ChangeDestination());
    }

    private IEnumerator ChangeDestination()
    {
        while (true)
        {
            Vector3 randomPoint = GetRandomPointOnNavMesh();
            agent.SetDestination(randomPoint);

            yield return new WaitForSeconds(Random.Range(0.1f, 2f));
        }
    }

    private Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10f;

        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return transform.position;
    }
}
