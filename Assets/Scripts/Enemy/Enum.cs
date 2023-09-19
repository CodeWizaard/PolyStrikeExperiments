using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    enum Health { Max = 3, Average = 2, Min = 0, No = 0 };
    void Start()
    {
        SetStateDamge(Health.Max);
        SetStateDamge(Health.Min);
    }

    private void SetStateDamge(Health HP)
    {
        if (HP == Health.Max)
        {
            Debug.Log("MaxHealth");
        }
        if (HP == Health.Min)
        {
            Debug.Log("MinHealth");
        }


    }

}
