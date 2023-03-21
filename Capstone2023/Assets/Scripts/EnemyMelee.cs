using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float attackDamage = 10f;
    public float attackSpeed = 1f;
    private float canAttack;

     Enemy enemy;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponentInParent<Enemy>();
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= canAttack)
            {
                enemy.canMove = false;
                enemy.anim.SetBool("inRange", true);

                if (playerHealth == null)
                {
                    playerHealth = other.GetComponent<PlayerHealth>();
                }

                if (playerHealth != null)
                {
                    playerHealth.UpdateHealth(-attackDamage);
                }

                canAttack = Time.time + attackSpeed;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.canMove = true;
            enemy.anim.SetBool("inRange", false);
        }
    }
}

