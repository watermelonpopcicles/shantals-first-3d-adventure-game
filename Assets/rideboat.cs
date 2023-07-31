using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rideboat : MonoBehaviour
{
    public bool canride;
    public GameObject Player;
    public GameObject spawn;
    public Animator boatanim;
    public GameObject boathint;
    // Start is called before the first frame update
    void Start()
    {
        boathint.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canride)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.transform.position = spawn.transform.position;
                Player.transform.SetParent(transform);
                boatanim.SetTrigger("startboat1");
                boathint.SetActive(false);
                Player.GetComponent<PlayerMovement>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<Rigidbody>().isKinematic = true;
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canride = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canride = false;
        }
    }
}
