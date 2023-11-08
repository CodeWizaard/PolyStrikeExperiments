using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class SearchAndMovementTowardsTheNearestGoal : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform target;

    void Start()
    {
        EnemyTargetPositionUpdater.EnemyPositionUpdate += ResetPositionTarget;
    }
    void ResetPositionTarget() {
        Debug.Log("Обновил позицию игрока");
        target = SoldiersPositions.IdentifyTheNearestTarget(gameObject.transform.position).transform;
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _agent.SetDestination(target.position);
        
    }
   
   

    private void OnDisable()
    {
        EnemyTargetPositionUpdater.EnemyPositionUpdate -= ResetPositionTarget;
    }

}
