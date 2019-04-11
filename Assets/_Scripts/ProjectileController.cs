using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public float power;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*power, ForceMode.Impulse);
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
