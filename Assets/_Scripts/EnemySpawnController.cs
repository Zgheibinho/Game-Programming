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
    private int currentround;
    private bool roundStarted;
    private GameObject roundText;
    void Start()
    {
        spawnPoints= GameObject.FindGameObjectsWithTag("spawn");
        currentround = 1;
        roundStarted = false;
        roundText = GameObject.FindGameObjectWithTag("roundtext");
        //StartCoroutine("spawning");
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
        if(!roundStarted)
        {
            if(currentround ==1)
            {
                StartCoroutine("round1");
                roundStarted = true;
            }
            if (currentround == 2)
            {
                StartCoroutine("round2");
                roundStarted = true;
            }
            if (currentround == 3)
            {
                StartCoroutine("round3");
                roundStarted = true;
            }
            if (currentround == 4)
            {
                StartCoroutine("round4");
                roundStarted = true;
            }
            if (currentround == 5)
            {
                StartCoroutine("round5");
                roundStarted = true;
            }
        }
    }

    private IEnumerator spawningZolrik()
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
            yield return new WaitForSeconds(15f);
        }
    }

    private IEnumerator round1()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        yield return new WaitForSeconds(120f);
        StopCoroutine("spawningZolrik");
        StartCoroutine("roundEnded");
        currentround++;
        roundStarted = false;
    }

    private IEnumerator round2()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        yield return new WaitForSeconds(120f);
        StopCoroutine("spawningZolrik");
        StartCoroutine("roundEnded");
        currentround++;
        roundStarted = false;
    }

    private IEnumerator round3()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        yield return new WaitForSeconds(120f);
        StopCoroutine("spawningZolrik");
        StartCoroutine("roundEnded");
        currentround++;
        roundStarted = false;
    }

    private IEnumerator round4()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        yield return new WaitForSeconds(120f);
        StopCoroutine("spawningZolrik");
        StartCoroutine("roundEnded");
        currentround++;
        roundStarted = false;
    }

    private IEnumerator round5()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        yield return new WaitForSeconds(120f);
        StopCoroutine("spawningZolrik");
        StartCoroutine("roundEnded");
        currentround++;
        roundStarted = false;
    }
    private IEnumerator displayRound()
    {
        roundText.GetComponent<UnityEngine.UI.Text>().text = "Round will start in 30 seconds";
        yield return new WaitForSeconds(5f);
        roundText.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(20f);
        roundText.GetComponent<UnityEngine.UI.Text>().text = "Round" + currentround;
        yield return new WaitForSeconds(5f);
        roundText.GetComponent<UnityEngine.UI.Text>().text = "";
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
