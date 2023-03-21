using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Vector3 targetDir = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDir);
        transform.Rotate(0, 0, transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
