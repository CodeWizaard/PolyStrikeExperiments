using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    public Vector3 MaxSize;
    void Awake()
    {
        GetComponent<Transform>().localScale = new Vector3(Random.Range(0, MaxSize.x), Random.Range(0, MaxSize.y), Random.Range(0, MaxSize.z));
        GetComponent<Transform>().rotation = new Quaternion(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360),0);
    }
}
