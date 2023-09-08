using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBots : MonoBehaviour
{
    public GameObject Bot;

    void Start()
    {
        GameObject newLocation = Instantiate(Bot,transform.position, Quaternion.identity); ;
    }


}
