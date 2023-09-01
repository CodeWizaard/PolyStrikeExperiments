using System;
using UnityEngine;

public class GenerateExit : MonoBehaviour
{
    void Awake()
    {

        bool randomBool = UnityEngine.Random.value > 0.5f;
        gameObject.SetActive(randomBool);       
    }

}
