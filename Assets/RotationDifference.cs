using UnityEngine;

public class RotationDifference : MonoBehaviour
{
    public Transform object1;
    public Transform object2;

    private void Update()
    {
        // Получаем разницу в повороте объектов относительно мирового пространства
        Quaternion rotationDifference = Quaternion.Inverse(object1.rotation) * object2.rotation;

        // Получаем углы Эйлера из разницы в повороте
        Vector3 eulerDifference = rotationDifference.eulerAngles;

        // Приводим углы Эйлера к диапазону [-180, 180]
        eulerDifference.x = Mathf.Repeat(eulerDifference.x + 180f, 360f) - 180f;
        eulerDifference.y = Mathf.Repeat(eulerDifference.y + 180f, 360f) - 180f;
        eulerDifference.z = Mathf.Repeat(eulerDifference.z + 180f, 360f) - 180f;

        // Выводим разницу в повороте в консоль
        Debug.Log("Разница в повороте: " + eulerDifference);
    }
}
