using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class SoldiersPositions : MonoBehaviour
{
    public static List<GameObject> Soliders = new List<GameObject>();

    public static Action SolidersPositionsUpdate;

    void Start()
    {
        UpdatePosition();
        SoldiersPositions.SolidersPositionsUpdate += UpdatePosition;
    }


    private void UpdatePosition()
    {
        IHealSolider[] soliders = FindObjectsOfType<MonoBehaviour>().OfType<IHealSolider>().ToArray();
        List<IHealSolider> _soliders = new List<IHealSolider>(soliders);
        Soliders.Clear();
        foreach (var solider in _soliders)
        {

            GameObject soliderGameObject = (solider as MonoBehaviour).gameObject;

            Soliders.Add(soliderGameObject);
        }
        foreach (var solider in Soliders)
        {
            Debug.Log(solider);
        }
    }
    public static GameObject IdentifyTheNearestTarget(Vector3 CurrentCoordinateObj) {
        float minDistance = 1000;
        GameObject minDistanceObj = null;
        foreach (var solider in Soliders)
        {
            float curDistance = Vector3.Distance(solider.transform.position, CurrentCoordinateObj);
            if (minDistance > curDistance) {
                minDistance = curDistance;
                minDistanceObj = solider; 
            }
        }

        return minDistanceObj;
    }
   
}
