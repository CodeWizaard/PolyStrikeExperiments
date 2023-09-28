using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    public Vector3 maxSize;
    void Awake()
    {
        GetComponent<Transform>().localScale = new Vector3(Random.Range(0, maxSize.x), Random.Range(0, maxSize.y), Random.Range(0, maxSize.z));
        GetComponent<Transform>().rotation = new Quaternion(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360),0);
    }
}
