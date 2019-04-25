using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] cointexts;
    GameObject healthtext;
    GameObject player;
    public GameObject gameOverText;
    void Start()
    {
        cointexts = GameObject.FindGameObjectsWithTag("coinText");
        healthtext = GameObject.FindGameObjectWithTag("healthText");
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject cointext in cointexts)
        cointext.GetComponent<UnityEngine.UI.Text>().text = ""+ player.GetComponent<PlayerStats>().coins;

        healthtext.GetComponent<UnityEngine.UI.Text>().text = "" + player.GetComponent<PlayerStats>().health;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
