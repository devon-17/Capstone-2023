using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;
    public float projectileSpeed;
    public float projectileDamage = 10f;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.UpdateHealth(-projectileDamage);
                Debug.Log(PlayerHealth.instance.health);
            }

            Destroy(gameObject);
        }
           
    }
}
