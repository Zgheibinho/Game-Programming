using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    Animator enemy_anim;
    bool dead = false;
    void Start()
    {
        enemy_anim = GetComponent<Animator>();
        health = 2;
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

    public void Die()
    {
        //Debug.Log("enemystats; "+this.GetComponent<EnemyMovement>());
        this.GetComponent<EnemyMovement>().enabled = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
       // Debug.Log("enemystats; " + this.GetComponent<EnemyMovement>().enabled);
        // Debug.Log("Enemy Stats script ; enemy died");
        dead = true;
        enemy_anim.SetBool("dead", true);

    }

}
