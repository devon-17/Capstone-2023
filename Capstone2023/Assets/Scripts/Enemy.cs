using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    public Transform target;
    public Transform homePos;
    public float speed;
    public float maxRange;
    public float minRange;
    public int healthPoints;
    public int maxHealthPoints;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        healthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(target.position, transform.position);
        if(distance <= maxRange && distance >= minRange)
        {
            FollowPlayer();
        }
        else if(distance >= maxRange)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {
        anim.SetBool("isMoving", true);
        Debug.Log("IsMoving is " + anim.GetBool("isMoving"));
        anim.SetFloat("Horizontal", (target.position.x - transform.position.x));
        anim.SetFloat("Vertical", (target.position.y - transform.position.y));
        Debug.Log(anim.GetFloat("Horizontal") + ", " + anim.GetFloat("Vertical"));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        var distance = Vector3.Distance(transform.position, homePos.position);

        anim.SetFloat("Horizontal", (homePos.position.x - transform.position.x));
        anim.SetFloat("Vertical", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if(distance == 0)
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("Last Horizontal", (target.position.x - transform.position.x)); // setting the last horizontal param to which way we are facing
            anim.SetFloat("Last Vertical", (target.position.y - transform.position.y)); // setting the last vertical param to which way we are facing
        }
    }

    public void Hit()
    {
        
    }
}
