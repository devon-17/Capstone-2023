using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    const float maxHealth = 100f;

    public event Action<float> OnHealthChanged; // it will be invoked when the plays health is updated, it allows scripts to make changes to the players health.

    void Start()
    {
        health = maxHealth;
    }
    
    public void UpdateHealth(float mod)
    {
        health += mod;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        else if (health <= 0)
        {
            health = 0f;
            Debug.Log("Player Dead");
        }
    }

    public bool IsAlive() //allows other scripts to check if the player is alive without relying on the debug.log
    {
        return health > 0f;
    }
}