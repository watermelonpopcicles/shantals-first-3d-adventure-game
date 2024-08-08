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
    public grasslandmanager manager;
    public bool resultChat;
    bool afterPlaying;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        arrowshootplayer.SetActive(false);
    }

    public void ResumeChat(bool gameresult) {
        afterPlaying = true;
        mainCamera.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        arrowshootplayer.SetActive(false);
        manager.targetgamestart = false;

        chatting = true;
        canchat = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        mainCamera.transform.SetParent(cameraloc);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localEulerAngles = Vector3.zero;
        chat.gameObject.SetActive(true);
        player.transform.position = chickposition.position;
        player.transform.rotation = chickposition.rotation;
        resultChat = gameresult;
        chatnum = 0;
  

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
                mainCamera.transform.SetParent(cameraloc);
                mainCamera.transform.localPosition = Vector3.zero;
                mainCamera.transform.localEulerAngles = Vector3.zero;
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

            if (afterPlaying)
            {
                if (resultChat == true)
                {
                    if (chatnum == 0)
                    {
                        chat.text = "WOW! You did it!";
                    }
                    if (chatnum == 1)
                    {
                        chat.text = "You're the first to ever complete this challenge!";
                    }
                    if (chatnum == 2)
                    {
                        chat.text = "Hmmm....";
                    }
                    if (chatnum == 3)
                    {
                        chat.text = "You deserve a reward!";
                    }
                    if (chatnum == 4)
                    {
                        chat.text = "Talk to the slime on the top of the mountain.";
                    }
                    if (chatnum == 5)
                    {
                        chat.text = "He might just have something for you!";
                    }
                    if (chatnum == 6)
                    {

                        endchat();
                    }
                }
                else {
                    if (chatnum == 0)
                    {
                        chat.text = "Awwww you didn't complete the challenge in time :(";
                    }
                    if (chatnum == 1)
                    {
                        chat.text = "Come back and try again when ur ready!";
                    }
                    if (chatnum == 2)
                    {

                        endchat();
                    }

                }
            }
            else
            {
                

                if (chatnum == 0)
                {
                    chat.text = "...";
                }
                if (chatnum == 1)
                {
                    chat.text = "Hello and welcome to this island! I'm glad you made it.";
                }
                if (chatnum == 2)
                {
                    chat.text = "I have an archery challenge for you!";
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
                        mainCamera.gameObject.SetActive(false);
                        player.gameObject.SetActive(false);
                        arrowshootplayer.SetActive(true);
                        manager.targetgamestart = true;

                    }
                }
                if (chatnum == 5)
                {

                    endchat();
                }
            }
        }
        

    }

    
    void endchat()
    {
        if (mainCamera == null)
        {
            return;
        }
            chatting = false;
        canchat = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;

        mainCamera.transform.SetParent(oldcampos);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localEulerAngles = Vector3.zero;
        
        chat.text = "...";
        chatnum = 0;
        afterPlaying = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            canchat = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canchat = false;
            player = other.gameObject;
        }
    }
}
