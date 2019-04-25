using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfController : MonoBehaviour
{
    private float radius = 2.5f;
    private NavMeshAgent agent;
    private GameObject player;
    private bool isAttacking;
    Animator wolf_anim;
    Rigidbody rb;
    public int dmgAmount;
    public GameObject currentenemy;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("player");
        agent = GetComponent<NavMeshAgent>();
        wolf_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.SetDestination(player.transform.position);
        StartCoroutine("Move");
        StartCoroutine("Damage");
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {

        //enemy_anim.SetFloat("speed",Mathf.Abs(rb.velocity.y)+ Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z));
        //Debug.Log(rb.velocity.z);

    }

    void FixedUpdate()
    {


            if (currentenemy!= null && currentenemy.activeInHierarchy&& Mathf.Sqrt((currentenemy.transform.position - transform.position).sqrMagnitude) < radius)
            {

                wolf_anim.SetBool("attack", true);

                isAttacking = true;

            }
            else
            {
                wolf_anim.SetBool("attack", false);
                isAttacking = false;
            }
           // Debug.DrawRay(transform.position, player.transform.position - this.transform.position);
            wolf_anim.SetFloat("speed", Mathf.Sqrt((agent.velocity.sqrMagnitude)));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Debug.Log("0");
            currentenemy = other.gameObject;
            StartCoroutine("MoveEnemy");
            
        }
    }

    private IEnumerator MoveEnemy()
    {


        while (currentenemy.activeInHierarchy)
        {
            Debug.Log("1");

            agent.SetDestination(currentenemy.transform.position);
            transform.LookAt(currentenemy.transform);
            yield return new WaitForSeconds(1f);

        }
        //currentenemy = null;
        isAttacking = false;
        StartCoroutine("Move");
    }
    private IEnumerator Move()
    {


        while (!isAttacking)
        {
            Debug.Log("2");
            agent.SetDestination(player.transform.position - new Vector3(1, 1, 1));
            transform.LookAt(player.transform);
            yield return new WaitForSeconds(1f);

        }
    }

    private IEnumerator Damage()
    {


        while (true)
        {

            if (isAttacking)
                currentenemy.GetComponent<EnemyStats>().TakeDamage(dmgAmount);
            yield return new WaitForSeconds(1f);

        }
    }
}
