using UnityEngine;

public interface IHealSolider
{
    public float CurHealth { get; set; }
    public void MakeDamage(float damage);
    public void ExecuteDeath();
}
public class Solider : MonoBehaviour , IHealSolider
{
    [SerializeField]
    private float curHealth = 100;
    public float MaxHealth = 100;
    public float MinHealth = 0;

    void Start() {
        SoldiersPositions.SolidersPositionsUpdate?.Invoke();
    }

    public float CurHealth
    {
        get { return curHealth; }
        set{ curHealth = value;}
    }

    public void MakeDamage(float damage)
    {
       
    }

    public void ExecuteDeath() { 
    
    
    }

    private void OnDestroy()
    {
        SoldiersPositions.SolidersPositionsUpdate.Invoke();
    }


}
