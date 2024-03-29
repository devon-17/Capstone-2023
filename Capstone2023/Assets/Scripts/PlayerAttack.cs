using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    private GameObject attackArea = default;

    private Animator anim;

    public bool attacking = false;

    private float timeToAttack = 0.25f;

    private float timer = 0f;

    public AudioClip attackSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        attackArea = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            StartCoroutine(TimedAttack(timeToAttack));
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                attacking = false;
                timer = 0;
                attackArea.SetActive (attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        anim.SetBool("isAttacking", true);
        attackArea.SetActive (attacking);
        audioSource.PlayOneShot(attackSound);
    }

    private void EndAttack()
    {
        anim.SetBool("isAttacking", false);
        attackArea.SetActive(false);
    }

    public IEnumerator TimedAttack(float timeToWait)
    {
        Attack();
        yield return new WaitForSeconds(timeToWait);
        EndAttack();
    }
}
