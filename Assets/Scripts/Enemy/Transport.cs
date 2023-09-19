using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Transport : MonoBehaviour
{
    public NavMeshAgent _agent;
    public Transform Target;

    public void Start()
    {
        Target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _agent.SetDestination(Target.position);
    }
}
