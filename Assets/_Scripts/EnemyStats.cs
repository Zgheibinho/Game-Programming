using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int maxHealth ;
    public int moneyWorth;
    Animator enemy_anim;
    bool dead = false;
    GameObject player;
    GameObject spawner;
    private AudioSource audiosrc;
    void Start()
    {
        enemy_anim = GetComponent<Animator>();
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("player");
        spawner = GameObject.FindGameObjectWithTag("spawner");
        audiosrc = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audiosrc = GetComponent<AudioSource>();
        enemy_anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player");
        spawner = GameObject.FindGameObjectWithTag("spawner");
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
        Debug.Log("health :"+ health);
        if (!dead)
        {
            health -= damage;
            Debug.Log("health ==" + health);
            //Debug.Log("health ==" + health);
            if (health <= 0)
            {
                dead = true;
                Die();
            }
        }
        else
        {
            Debug.Log("what");
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile1")
        {
            //Debug.Log("hello enemystats; projectile collide");
            TakeDamage(1);
            other.gameObject.SetActive(false);
        }
        if (other.tag == "projectile2")
        {
            // Debug.Log("hello enemystats; projectile collide");
            TakeDamage(2);
            other.gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        //Debug.Log("enemystats; "+this.GetComponent<EnemyMovement>());
        this.GetComponent<EnemyMovement>().dead = true;
        //this.GetComponent<NavMeshAgent>().enabled = false;
        // Debug.Log("enemystats; " + this.GetComponent<EnemyMovement>().enabled);
         Debug.Log("Enemy Stats script ; enemy died");
        spawner.GetComponent<EnemySpawnController>().totalenemycount--;
        dead = true;
        player.GetComponent<PlayerStats>().IncreaseCoins(moneyWorth);
        enemy_anim.SetBool("attack", false);
        enemy_anim.SetBool("dead", true);
        StartCoroutine("disable");
        audiosrc.Play();
    }

    private IEnumerator disable()
    {
        yield return new WaitForSeconds(3f);
        dead = false;
        gameObject.SetActive(false);
    }

}
