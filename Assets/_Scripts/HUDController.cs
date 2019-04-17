using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cointext;
    GameObject healthtext;
    GameObject player;
    public GameObject gameOverText;
    void Start()
    {
        cointext = GameObject.FindGameObjectWithTag("coinText");
        healthtext = GameObject.FindGameObjectWithTag("healthText");
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        cointext.GetComponent<UnityEngine.UI.Text>().text = ""+ player.GetComponent<PlayerStats>().coins;
        healthtext.GetComponent<UnityEngine.UI.Text>().text = "" + player.GetComponent<PlayerStats>().health;
    }

    public void GameOver()
    {
        Debug.Log("aaaaaaaaaaaaaaa");
        gameOverText.SetActive(true);
    }
}
