using UnityEngine;
using UnityEngine.Events;

public class CreationTrigger: MonoBehaviour
{
    public UnityEvent m_MyEvent;


    public void Start()
    {
        Invoke("CreateStartLocation", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            m_MyEvent.Invoke();
        }
    }
    void CreateStartLocation() {

        m_MyEvent.Invoke();
    }
}
