using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

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

        enemy_anim.SetFloat("speed",Mathf.Abs(rb.velocity.y)+ Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z));
        //Debug.Log(rb.velocity.z);

    }


    private IEnumerator Move()
    {
        // Play the animation for firing

        while (true)
        {
            agent.SetDestination(player.transform.position);
            yield return new WaitForSeconds(0.45f);

        }
    }
}