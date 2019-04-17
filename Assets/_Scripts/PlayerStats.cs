using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int coins;
    void Start()
    {
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("playerstats; health :" + health);
        if (health <= 0)
            Die();
    }

    public void IncreaseCoins(int amount)
    {
        coins += amount;
    }

    public void Die()
    {
        GameObject hud = GameObject.FindGameObjectWithTag("HUD");
        //Debug.Log("hud is" + hud);
        hud.GetComponent<HUDController>().GameOver();
        gameObject.GetComponent<PlayerMovement>().Die();
        gameObject.GetComponent<PlayerShooting>().enabled = false;
        gameObject.GetComponent<LookTowardMouse>().enabled = false;
    }
}
