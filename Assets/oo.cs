using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oo : MonoBehaviour
{
    
    void Awake()
    {
        EnemyTargetPositionUpdater.PositionUpdate += Debus;
    }

    public void Debus()
    {
        Debug.Log("Вызван метод обновления позиции");
        
    }
}
