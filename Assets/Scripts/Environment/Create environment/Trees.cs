using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Trees : MonoBehaviour
{
    public GameObject[] TreesObject;

    public void Start()
    {

        OnTrees(TreesObject.Length);
    }
    [Serializable]    
    private class Environment {
        public GameObject[] Object;
        public int CountInclude;

    }
    [SerializeField]
    private Environment[] Categories;
    public void OnTrees(int CountInclude) {
        int CountIncluded = 0;
        for (int i = 0; i < TreesObject.Length; i++) {
            if (CountIncluded < CountInclude) {
                RandomlyEnable(TreesObject[i]);
            }
        }
    }
    private void RandomlyEnable(GameObject Object) {
      
        Object.active = GetRandomBool();

    }
    bool GetRandomBool()
    {
        int randomNumber = Random.Range(0, 100);
        return (randomNumber % 2 == 0) ? true : false;
    }

    public void OnAllTrees()
    {


    }


}

