using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnvironmentCreator: MonoBehaviour
{
    [Serializable]
    private class EnvironmentCategory
    {
        public GameObject[] Objects;
        public int CountInclude;
    }
    [SerializeField]
    private EnvironmentCategory[] Categories;

    public void OnAllCategory() {
        int CountCategory = Categories.Length;
        for (int i = 0; i < CountCategory; i++)
        {
            OnObjectsCategory(Categories[i].Objects, Categories[i].CountInclude);
        }
    }
    public void OnObjectsCategory(GameObject[] Objects, int CountInclude)
    {
        int CountIncluded = 0;
        for (int i = 0; i < Objects.Length; i++)
        {
            if (CountIncluded < CountInclude)
            {
                RandomlyEnable(Objects[i]);
            }
        }
    }
    private void RandomlyEnable(GameObject Object)
    {
        Object.active = GetRandomBool();
    }
    bool GetRandomBool()
    {
        int randomNumber = Random.Range(0, 100);
        return (randomNumber % 2 == 0) ? true : false;
    }


    public void Start()
    {

        OnAllCategory();
    }   

}
