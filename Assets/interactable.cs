using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public GameObject mcamera;
    public GameObject Player;
    public GameObject possedobject;
    private Vector3 offset;
    private Vector3 rotationOffset;
    public GameObject hinttext1;
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        offset = mcamera.transform.localPosition;
        rotationOffset = mcamera.transform.localEulerAngles;
        hinttext1.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

            possedobject.GetComponent<ballcontrol>().possessed = true;
            possedobject.GetComponent<ballcontrol>().Player = gameObject;

            Player.SetActive(false);
            mcamera.transform.SetParent(null);
            mcamera.GetComponent<orbit>().enabled = true;
            hinttext1.SetActive(false);
            // mcamera.GetComponent<followplayer>().Player = other.transform;
        }
    }

    public void resetplayer()
    {
        if (possedobject == null)
        {
            return;
        }

            possedobject.GetComponent<ballcontrol>().possessed = false;
            Player.SetActive(true);
            mcamera.transform.SetParent(Player.transform);
            mcamera.transform.localPosition = offset;
            mcamera.GetComponent<orbit>().enabled = false;
        mcamera.transform.localEulerAngles = rotationOffset;
        //mcamera.GetComponent<followplayer>().Player = null;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rollyball"))
        {
            hinttext1.SetActive(true);
            triggered = true;
            possedobject = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("rollyball"))
        {
            hinttext1.SetActive(true);
            triggered = true;
            possedobject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("rollyball"))
        {
            hinttext1.SetActive(false);
            triggered = false;
            possedobject = null;
        }
    }
}
