using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SimpleTagAgent : MonoBehaviour
{

    public GameObject targetAgent;
    public BoxCollider environmentBounds;
    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(targetAgent.transform.position);
    }
}
