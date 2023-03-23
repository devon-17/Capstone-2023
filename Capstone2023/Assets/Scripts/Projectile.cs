using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;
    public float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Vector3 direction = player.position - transform.position;
        direction.z = 0f; // lock x and y axis
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation =
                Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));
        }

        gameObject.GetComponent<Rigidbody2D>().velocity =
            (player.position - gameObject.transform.position) * projectileSpeed;

        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.UpdateHealth(-10f);
            }

            Destroy(gameObject);
        }
           
    }
}
