using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;

    const float maxHealth = 100f;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0f;
            Debug.Log("Player Dead");
            Destroy (gameObject);
        }
    }

    public bool
    IsAlive() //allows other scripts to check if the player is alive without relying on the debug.log
    {
        return health > 0f;
    }
}
