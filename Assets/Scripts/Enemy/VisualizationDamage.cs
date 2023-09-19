using UnityEngine;
using UnityEngine.TestTools;

public class VisualizationDamage : MonoBehaviour
{

    [SerializeField] Material DefaultMaterial;
    [SerializeField] Material DamageMaterial;
    private float HealthPercentages;
    enum StateHealth { Max = 3, Average = 2, Min = 0, No = 0 };
    public void SetDamage(float HealthPercentages)
    {
        if (HealthPercentages <= 0.3f) { SetStateDamage(StateHealth.Min); }
        else if (HealthPercentages <= 0.7f) { SetStateDamage(StateHealth.Average); }
      
    }
    private void SetStateDamage(StateHealth HP)
    {
        SkinnedMeshRenderer EnemyRenderer = GetComponent<SkinnedMeshRenderer>();
        if (HP == StateHealth.Max) EnemyRenderer.materials = new Material[1] { DefaultMaterial };
        if (HP == StateHealth.Average) EnemyRenderer.materials = new Material[2] { DefaultMaterial, DamageMaterial };
        if (HP == StateHealth.Min) EnemyRenderer.materials = new Material[3] { DefaultMaterial, DamageMaterial, DamageMaterial };
    }



    //SkinnedMeshRenderer EnemyRenderer = GetComponent<SkinnedMeshRenderer>();
    //gameObject.GetComponent<SkinnedMeshRenderer>().materials= Materials;
    // EnemyRenderer.materials = new Material[2] { DefaultMaterial, DamageMaterial };
    //EnemyRenderer.materials.SetValue(DamageMaterial, 0);
    //EnemyRenderer.materials[1] = DamageMaterial; 
}