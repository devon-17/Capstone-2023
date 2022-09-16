using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;

    public GameObject[] rooms; // index 0 --> LR, index 1 --> LRB, index 2 --> LRT, index 3 --> LRTB

    int direction;

    public float moveAmount;

    float timeBetweenRoom;

    public float startTimeBetweenRoom = 0.25f;

    public bool stopGeneration;

    public float minX;

    public float maxX;

    public float minY;

    public LayerMask room;
    public int downCounter;

    // Start is called before the first frame update
    void Start()
    {
        // getting a random spawn point
        int randStartingPos = Random.Range(0, startingPositions.Length); 
        transform.position = startingPositions[randStartingPos].position;

        // placing a LR to start
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6); // getting a random way to continue
    }

    // Update is called once per frame
    void Update()
    {
        // when the timer is still playing and we are still generating (havent reached the bottom)
        if (timeBetweenRoom <= 0 && !stopGeneration)
        {
            Move();
            timeBetweenRoom = startTimeBetweenRoom;
        }
        else
        {
            timeBetweenRoom -= Time.deltaTime; // starting timer
        }
    }

    void Move()
    {
        // move  position right
        if (direction == 1 || direction == 2)
        {
            // checking if we are within bounds
            if (transform.position.x < maxX)
            {
                downCounter = 0;

                // adding amount to x value (moving right)
                Vector2 newPos =
                    new Vector2(transform.position.x + moveAmount,
                        transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand],
                transform.position,
                Quaternion.identity); // spawning the room

                direction = Random.Range(1, 6); // resetting direction

                // not allowing you to go left after you've gone right
                if (direction == 3)
                {
                    direction = 1;
                }
                else if (direction == 4) // making you go down
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        } // move position left
        else if (direction == 3 || direction == 4)
        {
            if (transform.position.x > minX)
            {
                downCounter = 0;

                // subtracting amount to x value (moving left)
                Vector2 newPos =
                    new Vector2(transform.position.x - moveAmount,
                        transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand],
                transform.position,
                Quaternion.identity); // spawning the room

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }
        } // move position down
        else if (direction == 5)
        {
            downCounter++;
            
            // checking if we're in bounds
            if (transform.position.y > minY)
            {
                Collider2D roomDetection =
                    Physics2D.OverlapCircle(transform.position, 1, room);

                //if room isnt LRB or LRTB
                if (
                    roomDetection.GetComponent<RoomType>().type != 1 &&
                    roomDetection.GetComponent<RoomType>().type != 3
                )
                {
                    if(downCounter >= 2){
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3],
                    transform.position,
                    Quaternion.identity);
                    }else{
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                    int randBottomRoom = Random.Range(1, 4);
                    if (randBottomRoom == 2)
                    {
                        randBottomRoom = 1;
                    }
                    Instantiate(rooms[randBottomRoom],
                    transform.position,
                    Quaternion.identity);
                    }             
                }

                Vector2 newPos =
                    new Vector2(transform.position.x,
                        transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand],
                transform.position,
                Quaternion.identity); // spawning the room

                direction = Random.Range(1, 6);
            }
            else
            {
                stopGeneration = true;
            }
        }
    }
}
