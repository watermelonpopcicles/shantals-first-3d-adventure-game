using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontrol : MonoBehaviour
{
    public float speed = 3;
    Rigidbody rb;
    public bool possessed;
    public float rotationspeed = 90.0f;
    public GameObject balllight;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        balllight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (possessed)
        { 
            //float z = Input.GetAxis("Horizontal");

        
            float x = Input.GetAxis("Vertical");
            float z = 0;
            Vector3 movement = new Vector3(x, 0, -z);
            movement = Camera.main.transform.TransformDirection(movement);
            rb.AddTorque(movement * 1000, ForceMode.Acceleration);
            balllight.SetActive(true);

            if (Input.GetKeyDown(KeyCode.B))
            {
                Player.SetActive(true);
                Player.GetComponent<interactable>().resetplayer(transform.position);
                possessed = false;
                balllight.SetActive(false);
            }
        }
        
    }
}
