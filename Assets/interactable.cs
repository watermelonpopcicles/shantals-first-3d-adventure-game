using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public GameObject mcamera;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rollyball") && Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<ballcontrol>().possessed = true;
            Player.SetActive(false);
            mcamera.transform.SetParent(null);
            mcamera.GetComponent<followplayer>().enabled = true;
            mcamera.GetComponent<followplayer>().Player = other.transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("rollyball") && Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<ballcontrol>().possessed = true;
            Player.SetActive(false);
            mcamera.transform.SetParent(null);
            mcamera.GetComponent<orbit>().enabled = true;
            mcamera.GetComponent<orbit>().focus = other.transform;
        }
    }
}
