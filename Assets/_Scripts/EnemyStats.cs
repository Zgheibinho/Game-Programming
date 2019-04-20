using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public const int maxHealth = 2;
    Animator enemy_anim;
    bool dead = false;
    GameObject player;
    void Start()
    {
        enemy_anim = GetComponent<Animator>();
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void OnEnable()
    {
        enemy_anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player");
        health = maxHealth;
        enemy_anim.SetBool("dead", false);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("health ==" + health);
    }

    public void TakeDamage(int damage)
    {
        if (!dead)
        {
            health -= damage;
            //Debug.Log("health ==" + health);
            if (health <= 0)
                Die();
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile1")
        {
           // Debug.Log("hello enemystats; projectile collide");
            TakeDamage(1);
            other.gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        //Debug.Log("enemystats; "+this.GetComponent<EnemyMovement>());
        this.GetComponent<EnemyMovement>().dead = true;
        //this.GetComponent<NavMeshAgent>().enabled = false;
       // Debug.Log("enemystats; " + this.GetComponent<EnemyMovement>().enabled);
        // Debug.Log("Enemy Stats script ; enemy died");
        dead = true;
        player.GetComponent<PlayerStats>().IncreaseCoins(5);
        enemy_anim.SetBool("attack", false);
        enemy_anim.SetBool("dead", true);
        StartCoroutine("disable");

    }

    private IEnumerator disable()
    {
        yield return new WaitForSeconds(1.5f);
        dead = false;
        gameObject.SetActive(false);
    }

}
