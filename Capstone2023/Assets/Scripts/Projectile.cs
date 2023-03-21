using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;

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
    }
}
