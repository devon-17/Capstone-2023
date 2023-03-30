using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Damage and Speed")]
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    [Header("Movement")]
    [HideInInspector]
    public Animator anim;

    public Transform target;

    public Transform homePos;

    public float maxRange;

    public float minRange;

    public bool canMove = true;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        data.hp = data.maxHp;
        SetEnemyVales();

        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(target.position, transform.position);
        if (distance <= maxRange && distance >= minRange)
        {
            if (canMove == true)
            {
                FollowPlayer();
            }
        }
        else if (distance >= maxRange)
        {
            GoHome();
        }
    }

    private void SetEnemyVales()
    {
        GetComponent<EnemyHealth>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    public void FollowPlayer()
    {
        anim.SetBool("isMoving", true);
        Debug.Log("IsMoving is " + anim.GetBool("isMoving"));
        anim.SetFloat("Horizontal", (target.position.x - transform.position.x));
        anim.SetFloat("Vertical", (target.position.y - transform.position.y));
        transform.position =
            Vector3
                .MoveTowards(transform.position,
                target.transform.position,
                data.speed * Time.deltaTime);
    }

    public void GoHome()
    {
        var distance = Vector3.Distance(transform.position, homePos.position);

        anim
            .SetFloat("Horizontal",
            (homePos.position.x - transform.position.x));
        anim.SetFloat("Vertical", (homePos.position.y - transform.position.y));
        transform.position =
            Vector3
                .MoveTowards(transform.position,
                homePos.position,
                data.speed * Time.deltaTime);

        if (distance == 0)
        {
            anim.SetBool("isMoving", false);
            anim
                .SetFloat("Last Horizontal",
                (target.position.x - transform.position.x)); // setting the last horizontal param to which way we are facing
            anim
                .SetFloat("Last Vertical",
                (target.position.y - transform.position.y)); // setting the last vertical param to which way we are facing
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<EnemyHealth>() != null)
            {
                collider.GetComponent<EnemyHealth>().Damage(damage);
                this.GetComponent<EnemyHealth>().Damage(5);
                
            }
        }
    }
}
