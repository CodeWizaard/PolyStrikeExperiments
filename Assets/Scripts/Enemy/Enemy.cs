using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHealEnemy{
    public float MaxHealth { get; set; }
    public float MinHealth { get; set; }
    public float CurHealth { get; set; }
}
public class Enemy : MonoBehaviour
{

    [Header("Enemy options")]
    public float CurHealth = 100;
    public Canvas HealthCanvas;
    protected float MaxHealth = 100;
    protected float MinHealth = 0;
    public float timeDisappearanceAfterDeath = 10;

}
