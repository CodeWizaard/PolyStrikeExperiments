using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColor : MonoBehaviour
{
    public float Damage;
    public void Start()
    {
        gameObject.GetComponent<Enemy>().ReduceHealth(Damage);
    }



   
}
