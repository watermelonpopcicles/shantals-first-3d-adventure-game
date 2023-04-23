using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontrol : MonoBehaviour
{
    public float speed = 3;
    Rigidbody rb;
    public bool possessed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (possessed)
        {
            float z = Input.GetAxis("Horizontal");
            float x = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(x, 0, -z);
            rb.AddTorque(movement * 1000, ForceMode.Acceleration);
        }
        
    }
}
