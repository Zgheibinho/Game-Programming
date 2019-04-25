using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    bool buyhealth, buyspeed, buydamage, buyair, buywolf;
    public GameObject wolf;
    void Start()
    {
        buyhealth = false;
        buyspeed = false;
        buydamage = false;
        buyair = false;
        buywolf = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseMaxHealth()
    {
        if (player.GetComponent<PlayerStats>().coins >= 30 && ! buyhealth)
        {
            buyhealth = true;
            player.GetComponent<PlayerStats>().coins -= 30;
            player.GetComponent<PlayerStats>().maxHealth += 30;
            player.GetComponent<PlayerStats>().heal();
        }
    }

    public void increaseSpeed()
    {
        if (player.GetComponent<PlayerStats>().coins >= 30 && !buyspeed)
        {
            buyspeed = true;
            player.GetComponent<PlayerStats>().coins -= 30;
            player.GetComponent<PlayerMovement>().speed = 4.5f;
        }
    }

    public void increaseDamage()
    {
        if (player.GetComponent<PlayerStats>().coins >= 60 && !buydamage)
        {
            buydamage = true;
            player.GetComponent<PlayerStats>().coins -= 60;
            player.GetComponent<PlayerShooting>().fireupgraded = true;
        }
    }

    public void buyWolf()
    {
        if (player.GetComponent<PlayerStats>().coins >= 100 && !buywolf)
        {
            buywolf = true;
            player.GetComponent<PlayerStats>().coins -= 100;
            GameObject.Instantiate(wolf);
        }
    }
}
