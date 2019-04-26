using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] spawnPoints;
    public GameObject enemy;
    public GameObject mercenary;
    public GameObject troll;
    private List<GameObject> pooledZolriks; //public??
    private List<GameObject> pooledMercs;
    private List<GameObject> pooledTrolls;
    public int amountToPoolZolrik;
    public int amountToPoolMercenary;
    public int amountToPoolTroll;
    private int currentround;
    private bool roundStarted;
    private GameObject roundText;
    private GameObject player;
    public GameObject shopcam;
    public int totalenemycount;
    void Start()
    {
        totalenemycount = 0;
        shopcam = GameObject.FindGameObjectWithTag("shopCam");
        shopcam.SetActive(false);
        spawnPoints = GameObject.FindGameObjectsWithTag("spawn");
        currentround = 1;
        roundStarted = false;
        roundText = GameObject.FindGameObjectWithTag("roundtext");
        player = GameObject.FindGameObjectWithTag("player");
        pooledZolriks = new List<GameObject>();
        pooledMercs = new List<GameObject>();
        pooledTrolls = new List<GameObject>();
        for (int i = 0; i < amountToPoolZolrik; i++)
        {
           // Debug.Log("bbbbbbb");
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.SetActive(false);
            pooledZolriks.Add(obj);
        }

        for (int i = 0; i < amountToPoolMercenary; i++)
        {
            //Debug.Log("aaaaaaaa");
            GameObject obj2 = (GameObject)Instantiate(mercenary);
            obj2.SetActive(false);
           // Debug.Log("object is :" + obj2);
            pooledMercs.Add(obj2);
        }
        for (int i = 0; i < amountToPoolTroll; i++)
        {
            //Debug.Log("aaaaaaaa");
            GameObject obj3 = (GameObject)Instantiate(troll);
            obj3.SetActive(false);
            // Debug.Log("object is :" + obj2);
            pooledTrolls.Add(obj3);
        }
        // Debug.Log("shouuu :" + pooledZolriks.Count);
        //Debug.Log("shouuu :" + pooledMercs.Count);

    }

    // Update is called once per frame
    void Update()
    {
        if(!roundStarted && totalenemycount <=0)
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
            GameObject tempenemy = GetPooledObject(pooledZolriks,enemy);
            tempenemy.transform.SetParent(null);
            tempenemy.transform.position = spawnPoints[currentSpawn].transform.position;
            tempenemy.SetActive(true);
            totalenemycount++;
            yield return new WaitForSeconds(10f);
        }
    }

    private IEnumerator spawningZolrikRound1()
    {

        while (true)
        {

            //Debug.Log("spawning enemies spawnPoints Length:" + spawnPoints.Length);
            int currentSpawn = Random.Range(1, spawnPoints.Length);
            //Debug.Log("current spawn" + currentSpawn + "current sspawn transform" + spawnPoints[currentSpawn].transform.position );
            GameObject tempenemy = GetPooledObject(pooledZolriks, enemy);
            tempenemy.transform.SetParent(null);
            tempenemy.transform.position = spawnPoints[currentSpawn].transform.position;
            tempenemy.SetActive(true);
            totalenemycount++;
            yield return new WaitForSeconds(7f);
        }
    }

    private IEnumerator spawningMercenary()
    {
        while (true)
        {
            int currentSpawn = Random.Range(1, spawnPoints.Length);
            GameObject tempmerc = GetPooledObject(pooledMercs,mercenary);
            tempmerc.transform.SetParent(null);
            tempmerc.transform.position = spawnPoints[currentSpawn].transform.position;
            tempmerc.SetActive(true);
            totalenemycount++;
            yield return new WaitForSeconds(13f);
        }
    }

    private IEnumerator spawningTrolls()
    {
        while (true)
        {
            int currentSpawn = Random.Range(1, spawnPoints.Length);
            GameObject temptroll = GetPooledObject(pooledTrolls, troll);
            temptroll.transform.SetParent(null);
            temptroll.transform.position = spawnPoints[currentSpawn].transform.position;
            temptroll.SetActive(true);
            totalenemycount++;
            yield return new WaitForSeconds(15f);
        }
    }

    private IEnumerator round1()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrikRound1");
        yield return new WaitForSeconds(75f);
        StopCoroutine("spawningZolrikRound1");
        StartCoroutine("roundEnded");
        currentround++;
        player.GetComponent<PlayerStats>().heal();
        roundStarted = false;
    }

    private IEnumerator round2()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        StartCoroutine("spawningMercenary");
        yield return new WaitForSeconds(90f);
        StopCoroutine("spawningZolrik");
        StopCoroutine("spawningMercenary");
        StartCoroutine("roundEnded");
        currentround++;
        player.GetComponent<PlayerStats>().heal();
        roundStarted = false;
    }

    private IEnumerator round3()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        StartCoroutine("spawningTrolls");
        yield return new WaitForSeconds(90f);
        StopCoroutine("spawningZolrik");
        StopCoroutine("spawningTrolls");
        StartCoroutine("roundEnded");
        currentround++;
        player.GetComponent<PlayerStats>().heal();
        roundStarted = false;
    }

    private IEnumerator round4()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningMercenary");
        StartCoroutine("spawningTrolls");
        yield return new WaitForSeconds(90f);
        StartCoroutine("spawningMercenary");
        StopCoroutine("spawningTrolls");
        StartCoroutine("roundEnded");
        currentround++;
        player.GetComponent<PlayerStats>().heal();
        roundStarted = false;
    }

    private IEnumerator round5()
    {
        StartCoroutine("displayRound");
        yield return new WaitForSeconds(30f);
        StartCoroutine("spawningZolrik");
        StartCoroutine("spawningMercenary");
        StartCoroutine("spawningTrolls");
        yield return new WaitForSeconds(120f);
        StopCoroutine("spawningZolrik");
        StartCoroutine("spawningMercenary");
        StopCoroutine("spawningTrolls");
        StartCoroutine("roundEnded");
        currentround++;
        player.GetComponent<PlayerStats>().heal();
        roundStarted = false;
    }
    private IEnumerator displayRound()
    {
        roundText.GetComponent<UnityEngine.UI.Text>().text = "Round will start in 30 seconds";
        yield return new WaitForSeconds(5f);
        roundText.GetComponent<UnityEngine.UI.Text>().text = "";
        StartCoroutine("displayShop");
        yield return new WaitForSeconds(20f);
        roundText.GetComponent<UnityEngine.UI.Text>().text = "Round" + currentround;
        yield return new WaitForSeconds(5f);
        roundText.GetComponent<UnityEngine.UI.Text>().text = "";
    }
    private IEnumerator displayShop()
    {
        shopcam.SetActive(true);
        yield return new WaitForSeconds(20f);
        shopcam.SetActive(false);
    }

    public GameObject GetPooledObject(List<GameObject> pooledObjects , GameObject enemytype)
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
        
        GameObject obj = (GameObject)Instantiate(enemytype);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }


}
