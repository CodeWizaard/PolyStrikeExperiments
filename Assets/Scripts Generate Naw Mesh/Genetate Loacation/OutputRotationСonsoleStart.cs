using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputRotationСonsoleStart : MonoBehaviour
{

    void Start()
    {
        RotationMeasurement(gameObject);
    }
    private void RotationMeasurement(GameObject Object)
    {
        Quaternion Q_Rotation = Object.transform.rotation;
        float Rotation = Q_Rotation.eulerAngles.y;
        if (CheckingRange(0, Rotation, 90)) Debug.Log("Локация повернута Прямо");
        if (CheckingRange(90, Rotation, 180)) Debug.Log("Локация повернута Вправо");
        if (CheckingRange(180, Rotation, 270)) Debug.Log("Локация повернута Влево");
        if (CheckingRange(270, Rotation, 360)) Debug.Log("Локация повернута Назад");

    }
    private bool CheckingRange(float StartNumber, float Rotation, float EndNumber)
    {
        if (StartNumber <= Rotation && Rotation < EndNumber)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
