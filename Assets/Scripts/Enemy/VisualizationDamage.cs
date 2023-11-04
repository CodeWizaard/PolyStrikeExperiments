using UnityEngine;

public class VisualizationDamage : MonoBehaviour
{
    [SerializeField] Material damageMaterial;
    private float healthPercentages;
    private float minThresholdTransperent;
    private SkinnedMeshRenderer renderer;
    public void Awake()
    {
        
        renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        SetMaterial();
    }
    private void SetMaterial()
    {

        renderer.materials = new Material[] {renderer.material, damageMaterial };   
    }
    public void SetDamage(float healthPercentages)
    {
        
        renderer.materials[1].color = new Color(1,0,0, SetLimitRangeVariable((1- healthPercentages),0,0.7f));
    }
    
    public float SetLimitRangeVariable(float value, float min, float max)
    {
        return Mathf.Clamp(value, min,max);

    }


}