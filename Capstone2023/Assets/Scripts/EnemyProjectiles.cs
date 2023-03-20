using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    public GameObject projectile;
    public float attackSpeed = 1f;
    private float canAttack;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void Shoot()
    {
        Instantiate(projectile, new Vector2(gameObject.transform.position.x * 5, gameObject.transform.position.y), Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                Shoot();
                enemy.canMove = false;
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.canMove = true;
        }
    }
}
