using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class slimespeak : MonoBehaviour
{
    bool canchat = false;
    public Transform cameraloc;
    int chatnum;
    bool chatting;
    public TMP_Text chat;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canchat)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                chatting = true;
                canchat = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                Camera.main.transform.SetParent(cameraloc);
                Camera.main.transform.localPosition = Vector3.zero;
                Camera.main.transform.localEulerAngles = Vector3.zero;
                chat.gameObject.SetActive(true);

            }

        }
        if(chatting) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                chatnum++;
            }

            if (chatnum == 0)
            {
                chat.text = "...";
            }
            if (chatnum == 1)
            {
                chat.text = "Hello and welcome to the first island! I'm glad you made it.";
            }
            if (chatnum == 2)
            {
                chat.text = "The next challenge we have for you is archery.";
            }
            if (chatnum == 3)
            {
                chat.text = "Use this bow and arrow to shoot all the targets in 1 minute!";
            }
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            canchat = true;
            player = other.gameObject;
        }
    }
}
