using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] spawnPoints;
    public GameObject enemy;
    void Start()
    {
        spawnPoints= GameObject.FindGameObjectsWithTag("spawn");

        StartCoroutine("spawning");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawning()
    {

        while (true)
        {

            Debug.Log("spawning enemies spawnPoints Length:" + spawnPoints.Length);
            int currentSpawn = Random.Range(1, spawnPoints.Length);
            Debug.Log("current spawn" + currentSpawn + "current sspawn transform" + spawnPoints[currentSpawn].transform.position );
            GameObject tempenemy = GameObject.Instantiate(enemy,spawnPoints[currentSpawn].transform);
            tempenemy.transform.SetParent(null);
            yield return new WaitForSeconds(10f);
        }
    }

}
