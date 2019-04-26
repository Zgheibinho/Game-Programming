using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardMouse : MonoBehaviour
{

    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");

        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Turn the player to face the mouse cursor.
        Turning();
    }


    void Turning()
    {
        
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        
        RaycastHit floorHit;

     
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
           
            Vector3 playerToMouse = floorHit.point - transform.position;

            
            playerToMouse.y = 0f;

         
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

           
            playerRigidbody.MoveRotation(newRotation);

        }



    }
}