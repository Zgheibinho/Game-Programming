using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private float radius = 4;
    private NavMeshAgent agent;
    private GameObject player;
    Animator enemy_anim;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("player");
        agent = GetComponent<NavMeshAgent>();
        enemy_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.SetDestination(player.transform.position);
        StartCoroutine("Move");

    }

    // Update is called once per frame
    void Update()
    {

        //enemy_anim.SetFloat("speed",Mathf.Abs(rb.velocity.y)+ Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z));
        //Debug.Log(rb.velocity.z);

    }

    void FixedUpdate()
    {
        if (enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position - this.transform.position, out hit, Mathf.Infinity))
            {
                // Debug.Log("hello tag:" + hit.collider);
                if (hit.collider.tag == "player")
                {
                    //Debug.Log("hello collider is player");

                    if (Mathf.Sqrt((player.transform.position - transform.position).sqrMagnitude) < radius)
                    {

                        enemy_anim.SetBool("attack", true);
                        Debug.Log("radius is smaller");
                    }
                    else
                    {
                        enemy_anim.SetBool("attack", false);
                        // Debug.Log("radius is bigger");
                    }
                }
            }
            Debug.DrawRay(transform.position, player.transform.position - this.transform.position);
            enemy_anim.SetFloat("speed", Mathf.Sqrt((agent.velocity.sqrMagnitude)));
        }
    }

    


    private IEnumerator Move()
    {
        // Play the animation for firing

        while (enabled)
        {
            agent.SetDestination(player.transform.position);
            transform.LookAt(player.transform);
            yield return new WaitForSeconds(1.5f);

        }
    }
}