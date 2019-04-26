using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour { 

    Animator player_anim;
    bool firing_start;
    public GameObject projectile;
    public GameObject projectile2;
    public GameObject Player;
   //private GameObject tempProjectile;
    public List<GameObject> pooledObjects;
    public List<GameObject> pooledObjects2;
    public int amountToPool = 20;
    //private Vector3 mousePos;
    private AudioSource audiosrc;
    public AudioClip  spellAudio;
    public bool fireupgraded;
    public bool roundbreak;

    void Start()
    {
        // Debug.Log("hello 1");

        roundbreak = false;
        player_anim = GetComponent<Animator>();
        firing_start = false;
        audiosrc = GetComponent<AudioSource>();
        fireupgraded = false;

        pooledObjects = new List<GameObject>();
        pooledObjects2 = new List<GameObject>();
        amountToPool = 15;
        for (int i = 0; i < amountToPool; i++)
        {
            //Debug.Log("hello ; player shooting script");
            GameObject obj = (GameObject)Instantiate(projectile);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        for (int i = 0; i < amountToPool; i++)
        {
            //Debug.Log("hello ; player shooting script");
            GameObject obj = (GameObject)Instantiate(projectile2);
            obj.SetActive(false);
            pooledObjects2.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !roundbreak)
        {
            if (!firing_start)
            {
                firing_start = true;
                /*tempProjectile = GameObject.Instantiate(projectile, transform);
                tempProjectile.transform.SetParent(null);
                tempProjectile.GetComponent<Rigidbody>().AddForce(Player.transform.forward * 15, ForceMode.Impulse);*/
                GameObject tempProjectile;
                //Debug.Log("upgraded fire? : " + fireupgraded);
                if (!fireupgraded)
                {
                    //Debug.Log("purple");
                    tempProjectile = GetPooledObject();
                }
                else
                {
                    Debug.Log("blue");
                    tempProjectile = GetPooledObject2();
                }
              //  Debug.Log("Player shooting script; pooledObjects length"+ pooledObjects.Count);
                if (tempProjectile != null)
                {
                    tempProjectile.transform.position = this.transform.position + new Vector3(0.129f, 0.991f, -0.027f);
                    tempProjectile.transform.rotation = this.transform.rotation;
                    tempProjectile.SetActive(true);
                    tempProjectile.transform.SetParent(null);
                    tempProjectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    tempProjectile.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    tempProjectile.GetComponent<Rigidbody>().AddForce(Player.transform.forward * 15, ForceMode.Impulse);
                }
                StartCoroutine("Fire");
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("dance");
        }


    }


    private IEnumerator dance()
    {
        // Play the animation for dancing


        player_anim.SetBool("dance", true);

        yield return new WaitForSeconds(2f);

        player_anim.SetBool("dance", false);
    }

    private IEnumerator Fire()
    {
        // Play the animation for firing


        player_anim.SetBool("isFiring", true);

        yield return new WaitForSeconds(0.45f);

        player_anim.SetBool("isFiring", false);

        firing_start = false;
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
        GameObject obj = (GameObject)Instantiate(projectile);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

    public GameObject GetPooledObject2()
    {
        //1
        for (int i = 0; i < pooledObjects2.Count; i++)
        {
            //2
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }
        //3
        GameObject obj = (GameObject)Instantiate(projectile2);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

    public void PlaySpell()
    {
        audiosrc.clip = spellAudio;
        audiosrc.Play();
    }
}
