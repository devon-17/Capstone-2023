using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float attackDamage = 10f;
    public float attackSpeed = 1f;
    private float canAttack;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        while(other.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
              //  enemy.anim.SetBool("inRange", true);
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            enemy.anim.SetBool("inRange", false);
        }
    }
}
