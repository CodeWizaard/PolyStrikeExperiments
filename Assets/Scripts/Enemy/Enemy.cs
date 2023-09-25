using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100;
    public Canvas HealthCanvas;
    public float MaxHealth = 100;
    public float MinHealth = 0;
    public VisualizationDamage Skinned;
    public Animator Animator;

    public void Start()
    {
        if (gameObject.GetComponent<Animator>()) { Animator = gameObject.GetComponent<Animator>(); }
    }
    public void ReduceHealth(float Quantity) {
        Health -= Quantity;
        float RemainingHealthPercentage = CalculationRemainingHealthPercentage(Health, Quantity);
        gameObject.GetComponent<VisualizationDamage>().SetDamage(RemainingHealthPercentage);

    }
    public void AddHealth(float Quantity) {
        Health += Quantity;
    }


    public float CalculationRemainingHealthPercentage(float Health, float Quantity) {
         return( (Health - Quantity)/MaxHealth);
    }
}
