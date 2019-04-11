using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour { 

    Animator player_anim;
    bool firing_start;
    public GameObject projectile;
    public GameObject RightHand;
    public GameObject Player;
    private GameObject tempProjectile;
    //private Vector3 mousePos;

    void Start()
    {

        player_anim = GetComponent<Animator>();
        firing_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!firing_start)
            {
                firing_start = true;
               // mousePos = Input.mousePosition;
               // mousePos.z = transform.position.z + 5;
               // mousePos.y = 1.549f;
               // mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                tempProjectile = GameObject.Instantiate(projectile, RightHand.transform);
                tempProjectile.transform.SetParent(null);
               // tempProjectile.transform.LookAt(mousePos);
                tempProjectile.GetComponent<Rigidbody>().AddForce(Player.transform.forward * 15, ForceMode.Impulse);
                StartCoroutine("Fire");
            }
        }
    }

    private IEnumerator Fire()
    {
        // Play the animation for firing

        Debug.Log("has fired");

        player_anim.SetBool("isFiring", true);

        yield return new WaitForSeconds(0.45f);

        player_anim.SetBool("isFiring", false);

        Debug.Log("Finished Firing");
        firing_start = false;
    }
}
