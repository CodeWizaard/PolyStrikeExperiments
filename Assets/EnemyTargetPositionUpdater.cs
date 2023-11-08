using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPositionUpdater : MonoBehaviour
{
    [SerializeField]
    private  float TimeUpdate = 1f;
    public static Action EnemyPositionUpdate;
    void Start()
    {
        StartCoroutine(WaitAndPrint());
    }
 
     IEnumerator WaitAndPrint()
    {
        while (true)
        {
            EnemyPositionUpdate?.Invoke();
            yield return new WaitForSeconds(TimeUpdate);
        }
    }
}
