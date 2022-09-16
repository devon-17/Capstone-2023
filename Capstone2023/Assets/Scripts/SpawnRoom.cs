using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public LevelGeneration levelGen;

    // Update is called once per frame
    void Update()
    {
        // using the box collider on each one
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);

        // if there is no room and we stopped generating levels
        if(!roomDetection && levelGen.stopGeneration){
            int rand = Random.Range(0, levelGen.rooms.Length); // getting a random room
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity); // placing random room
            Destroy(gameObject); // destroying so we dont continoursly spawn
        }
    }
}
