using UnityEngine;

public class DealingDamage: MonoBehaviour
{
    public float damage;
    public void Update()
    {
        gameObject.GetComponent<SimpleZombie>().DealDamage(damage);
    }
}
