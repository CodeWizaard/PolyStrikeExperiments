using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
[RequireComponent(typeof(Animator))]

public class SimpleZombie: Enemy
{
    [Header("Extra options")]
    [SerializeField] VisualizationDamage skinned;
    [SerializeField] Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void DealDamage(float quantity) {
        CurHealth -= quantity;
        float remainingHealthPercentage = CalculationRemainingHealthPercentage(CurHealth, quantity);
        if (HealthIsOver(CurHealth, MinHealth))
        {
            GetComponent<VisualizationDamage>().SetDamage(remainingHealthPercentage);
        }
        else {
            ExecuteDeath();
        }
    }
    float CalculationRemainingHealthPercentage(float _health, float quantity)
    {
        return ((_health - quantity) / MaxHealth);
    }

    public void AddHealth(float quantity) {
        CurHealth += quantity;
    }
    private bool HealthIsOver(float _health, float _minHealth)
    {
        return _health > _minHealth;
    }
    private void ExecuteDeath() {
        GetComponent<SearchAndMovementTowardsTheNearestGoal>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        SetAnimation("Dying");
        Destroy(gameObject, timeDisappearanceAfterDeath);
    }
    public void SetAnimation(string trigger) {
        gameObject.GetComponent<Animator>().SetTrigger(trigger);
    }
}
