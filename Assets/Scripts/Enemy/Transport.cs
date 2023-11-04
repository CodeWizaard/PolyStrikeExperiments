using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Transport : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform target;

    public void Start()
    {   
        target = GameObject.Find("Player").transform;
        EnemyTargetPositionUpdater.PositionUpdate += ResetPositionTarget;
    }
    void ResetPositionTarget() {
        Debug.Log("Обновил позицию игрока");
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _agent.SetDestination(target.position);
    }
    private void OnDisable()
    {
        EnemyTargetPositionUpdater.PositionUpdate -= ResetPositionTarget;
    }

}
