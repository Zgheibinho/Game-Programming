using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private float radius = 2.5f;
    private NavMeshAgent agent;
    private GameObject player;
    private bool isAttacking;
    Animator enemy_anim;
    Rigidbody rb;
    public bool dead;
    // Use this for initialization
    void Start()
    {
        dead = false;
        player = GameObject.FindWithTag("player");
        agent = GetComponent<NavMeshAgent>();
        enemy_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.SetDestination(player.transform.position);
        StartCoroutine("Move");
        isAttacking = false;
        StartCoroutine("Damage");
    }
    void OnEnable()
    {
        Debug.Log("Enabled");
        player = GameObject.FindWithTag("player");
        dead = false;
        agent = GetComponent<NavMeshAgent>();
        enemy_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.SetDestination(player.transform.position);
        StartCoroutine("Move");
        isAttacking = false;
        StartCoroutine("Damage");
        
    } 

    // Update is called once per frame
    void Update()
    {

        //enemy_anim.SetFloat("speed",Mathf.Abs(rb.velocity.y)+ Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z));
        //Debug.Log(rb.velocity.z);

    }

    void FixedUpdate()
    {
        if (!dead)
        {
            

                    if (Mathf.Sqrt((player.transform.position - transform.position).sqrMagnitude) < radius)
                    {

                        enemy_anim.SetBool("attack", true);
                        
                        isAttacking = true;
                        
                    }
                    else
                    {
                        enemy_anim.SetBool("attack", false);
                        isAttacking = false;
            }
            Debug.DrawRay(transform.position, player.transform.position - this.transform.position);
            enemy_anim.SetFloat("speed", Mathf.Sqrt((agent.velocity.sqrMagnitude)));
        }
    }

    


    private IEnumerator Move()
    {
        // Play the animation for firing
        Debug.Log("yooo1");
        while (!dead)
        {
            Debug.Log("yooo");
                agent.SetDestination(player.transform.position);
                transform.LookAt(player.transform);
                yield return new WaitForSeconds(1.5f);
            
        }
    }

    private IEnumerator Damage()
    {
        // Play the animation for firing

        while (!dead)
        {
            
                if (isAttacking)
                    player.GetComponent<PlayerStats>().TakeDamage(2);
                yield return new WaitForSeconds(1f);
            
        }
    }

}