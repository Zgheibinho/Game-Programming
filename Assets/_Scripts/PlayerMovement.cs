using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

   
    Rigidbody rb;
    public float speed;
    Animator player_anim;
    private Vector3 mousePos;
    bool firing_start;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        player_anim = GetComponent<Animator>();
        firing_start = false;
    }
	
	
	void Update ()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(h * speed, rb.velocity.y, rb.velocity.z);


        float v = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, v * speed);

      
 

        animate(h, v);

        
    }

    

        public void animate(float h, float v)
    {
      
            float pos = transform.rotation.eulerAngles.y ;
            //Debug.Log(pos);
            if (pos <= 45f || pos >= 315f)
            {
                //Debug.Log("hello1");
                player_anim.SetBool("walk_left", h < 0);
                player_anim.SetBool("walk_right", h > 0);
                player_anim.SetBool("walk_back", v < 0);
                player_anim.SetBool("walk_forward", v > 0);

            }

            else if (pos > 45f && pos <= 135f)
            {
               // Debug.Log("hello2");
                player_anim.SetBool("walk_back", h < 0);
                player_anim.SetBool("walk_forward", h > 0);
                player_anim.SetBool("walk_right", v < 0);
                player_anim.SetBool("walk_left", v > 0);
            }

            else if (pos > 135f&& pos <= 225f)
            {
                //Debug.Log("hello3");
                player_anim.SetBool("walk_right", h < 0);
                player_anim.SetBool("walk_left", h > 0);
                player_anim.SetBool("walk_forward", v < 0);
                player_anim.SetBool("walk_back", v > 0);

            }

            else
            {
                //Debug.Log("hello4");
                player_anim.SetBool("walk_forward", h < 0);
                player_anim.SetBool("walk_back", h > 0);
                player_anim.SetBool("walk_left", v < 0);
                player_anim.SetBool("walk_right", v > 0);
            }

 
    }
}
