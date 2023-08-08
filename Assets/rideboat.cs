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
    public Transform Cameraboat;

    public Transform chickcamera;

    public void trip1arrived()
    {
        Debug.Log("arrived");
        Player.transform.SetParent(null);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<CharacterController>().enabled = true; 
        Player.GetComponent<Rigidbody>().isKinematic = false;
        Camera.main.transform.SetParent(chickcamera);
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localEulerAngles = Vector3.zero;
        GetComponent<AudioSource>().Pause();
    }
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
                Player.GetComponentInChildren<Animator>().SetBool("Walk", false);
                Player.GetComponentInChildren<Animator>().SetBool("Run", false);
                Player.GetComponentInChildren<Animator>().SetBool("Eat", false);
                Player.GetComponentInChildren<Animator>().ResetTrigger("Jump");
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<Rigidbody>().isKinematic = true;

                Camera.main.transform.SetParent(Cameraboat);
                Camera.main.transform.localPosition = Vector3.zero;
                Camera.main.transform.localEulerAngles = Vector3.zero;

                
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
