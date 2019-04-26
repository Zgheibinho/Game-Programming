using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<Rigidbody>().AddForce(Vector3.up * 0.5f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
       // GetComponent<Rigidbody>().AddForce(Vector3.down * 2, ForceMode.Impulse);
    }
}
