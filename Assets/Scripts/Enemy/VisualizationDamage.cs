using UnityEngine;

public class VisualizationDamage : MonoBehaviour
{

    private Material MainMaterial;
    [SerializeField] Material DamageMaterial;
    private float HealthPercentages;
    private float MinThresholdTransperent;
    public SkinnedMeshRenderer Renderer;
    public void Awake()
    {
        SetMaterial();
        SkinnedMeshRenderer Renderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    private void SetMaterial()
    {
        
        Renderer.materials = new Material[] {Renderer.material, DamageMaterial };   
    }
    public void SetDamage(float HealthPercentages)
    {
        Renderer.materials[1].color = new Color(1,0,0, (1- HealthPercentages)*1.2f);
    }

}