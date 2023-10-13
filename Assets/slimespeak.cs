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
    public Transform chickposition;
    public Transform oldcampos;
    public GameObject arrowshootplayer; 

    // Start is called before the first frame update
    void Start()
    {
        arrowshootplayer.SetActive(false);
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
                player.GetComponent<CharacterController>().enabled = false;
                Camera.main.transform.SetParent(cameraloc);
                Camera.main.transform.localPosition = Vector3.zero;
                Camera.main.transform.localEulerAngles = Vector3.zero;
                chat.gameObject.SetActive(true);
                player.transform.position = chickposition.position;
                player.transform.rotation = chickposition.rotation;

            }

           

        }
        if(chatting) 
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                endchat();
                
            }
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
            if (chatnum == 4)
            {
                chat.text = "Are you ready? Yes(Y)/No(E/B)";
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    Camera.main.gameObject.SetActive(false);
                    player.gameObject.SetActive(false);
                    arrowshootplayer.SetActive(true);

                }
            }
            if (chatnum == 5)
            {
                
                endchat();
            }
        }
        

    }

    
    void endchat()
    {
        chatting = false;
        canchat = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        Camera.main.transform.SetParent(oldcampos);
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localEulerAngles = Vector3.zero;
        chat.text = "...";
        chatnum = 0;
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
