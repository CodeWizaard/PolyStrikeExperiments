using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy options")]
    public float Health = 100;
    public Canvas HealthCanvas;
    public float MaxHealth = 100;
    public float MinHealth = 0;
    public float timeDisappearanceAfterDeath = 10;

}
