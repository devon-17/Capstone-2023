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

    private bool stopGeneration;

    public float minX;

    public float maxX;

    public float minY;

    public LayerMask room;

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
        if (timeBetweenRoom <= 0 && !stopGeneration)
        {
            Move();
            timeBetweenRoom = startTimeBetweenRoom;
        }
        else
        {
            timeBetweenRoom -= Time.deltaTime;
        }
    }

    void Move()
    {
        // move right
        if (direction == 1 || direction == 2)
        {
            if (transform.position.x < maxX)
            {
                Vector2 newPos =
                    new Vector2(transform.position.x + moveAmount,
                        transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand],
                transform.position,
                Quaternion.identity); // spawning the room

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 1;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        } // move left
        else if (direction == 3 || direction == 4)
        {
            if (transform.position.x > minX)
            {
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
        } // move down
        else if (direction == 5)
        {
            if (transform.position.y > minY)
            {
                Collider2D roomDetection =
                    Physics2D.OverlapCircle(transform.position, 1, room);

                if (
                    roomDetection.GetComponent<RoomType>().type != 1 &&
                    roomDetection.GetComponent<RoomType>().type != 3
                )
                {
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
