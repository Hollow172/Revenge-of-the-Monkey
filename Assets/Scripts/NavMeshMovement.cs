using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private Transform target;

    void Start()
    {
        target = GameObject.Find("Base").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent
            .SetDestination(new Vector3(target.position.x,
                target.position.y,
                transform.position.z));
    }
}
