using System;
using UnityEngine;

public class SetAnimationSoliders : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    enum GlobalStateAnimation
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Update()        
    {
        Quaternion rotationDifference = Quaternion.Inverse(object1.rotation) * object2.rotation;
        Vector3 eulerDifference = rotationDifference.eulerAngles;
        eulerDifference.y = Mathf.Repeat(eulerDifference.y + 180f, 360f) - 180f;
        if (IsRange(-180, eulerDifference.y, -90)) Debug.Log("Animation 1");
        if (IsRange(-91 , eulerDifference.y, 0)) Debug.Log("Animation 2");
        if (IsRange(1, eulerDifference.y, 90)) Debug.Log("Animation 3");
        if (IsRange(91, eulerDifference.y, 180)) Debug.Log("Animation 4");
    }


    private bool IsRange(float startNumber, float rotation, float endNumber)
    {
        return (startNumber <= rotation && rotation < endNumber);
    }
}