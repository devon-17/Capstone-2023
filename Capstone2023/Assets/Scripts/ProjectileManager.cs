using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private Transform player;

    public GameObject projectile;

    public float projectileSpeed;

    public float attackSpeed = 1f;

    private float canAttack;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponentInParent<Enemy>();
        player = GameObject.FindWithTag("Player").transform;
    }

    public void Shoot()
    {
        Instantiate(projectile,
        new Vector2(gameObject.transform.position.x,
            gameObject.transform.position.y),
        Quaternion.identity);

        projectile.GetComponent<Rigidbody2D>().velocity =
            (player.position - projectile.transform.position) * projectileSpeed;
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
