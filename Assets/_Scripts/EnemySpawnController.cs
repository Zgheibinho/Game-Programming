using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] spawnPoints;
    public GameObject enemy;
    public List<GameObject> pooledObjects;
    public int amountToPool = 20;
    void Start()
    {
        spawnPoints= GameObject.FindGameObjectsWithTag("spawn");

        StartCoroutine("spawning");
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            //Debug.Log("hello ; player shooting script");
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawning()
    {

        while (true)
        {

            //Debug.Log("spawning enemies spawnPoints Length:" + spawnPoints.Length);
            int currentSpawn = Random.Range(1, spawnPoints.Length);
            //Debug.Log("current spawn" + currentSpawn + "current sspawn transform" + spawnPoints[currentSpawn].transform.position );
            GameObject tempenemy = GetPooledObject();
            Debug.Log("number of pooled objects"+ pooledObjects.Capacity);
            tempenemy.transform.SetParent(null);
            tempenemy.transform.position = spawnPoints[currentSpawn].transform.position;
            tempenemy.SetActive(true);
            yield return new WaitForSeconds(10f);
        }
    }

    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3
        GameObject obj = (GameObject)Instantiate(enemy);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

}
