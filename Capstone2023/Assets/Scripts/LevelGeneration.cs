using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;

    int direction;
    public float moveAmount;
    float timeBetweenRoom;
    public float startTimeBetweenRoom = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6); // knowing which way to spawn

    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenRoom <= 0){
            Move();
            timeBetweenRoom = startTimeBetweenRoom;
        }else{
            timeBetweenRoom -= Time.deltaTime;
        }
    }

    void Move(){  
       if(direction == 1 || direction == 2){ // move right
        Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
        transform.position = newPos;
       } else if(direction == 3 || direction == 4){ // move left
        Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
        transform.position = newPos;
       }else if(direction == 5){ // move down
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
        transform.position = newPos;
       }

       Instantiate(rooms[0], transform.position, Quaternion.identity); // spawning the room
       direction = Random.Range(1, 6); // restarting proccess
    }
}
