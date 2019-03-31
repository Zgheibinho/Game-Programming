using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position+ new Vector3(0,6,-5);
	}
}
