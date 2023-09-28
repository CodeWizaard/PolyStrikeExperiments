using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class SimpleZombie: Enemy
{
    [Header("Extra options")]
    [SerializeField] VisualizationDamage skinned;
    [SerializeField] Animator animator;

    public void Start()
    {
        if (gameObject.GetComponent<Animator>()) { animator = gameObject.GetComponent<Animator>(); }
    }
    public void DealDamage(float quantity) {
        Health -= quantity;
        float remainingHealthPercentage = CalculationRemainingHealthPercentage(Health, quantity);
        if (HealthIsOver(Health, MinHealth))
        {
            
            gameObject.GetComponent<VisualizationDamage>().SetDamage(remainingHealthPercentage);
        }
        else {
            ExecuteDeath();
        }
    }
    private float CalculationRemainingHealthPercentage(float _health, float quantity)
    {
        return ((_health - quantity) / MaxHealth);
    }

    public void AddHealth(float quantity) {
        Health += quantity;
    }
    private bool HealthIsOver(float _health, float _minHealth)
    {
        return _health > _minHealth;
    }
    private void ExecuteDeath() {
        gameObject.GetComponent<Transport>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        SetAnimation("Dying");
        Destroy(gameObject, timeDisappearanceAfterDeath);
    }
    public void SetAnimation(string trigger) {
        gameObject.GetComponent<Animator>().SetTrigger(trigger);
    }
}
