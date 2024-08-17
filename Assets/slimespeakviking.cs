using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class slimespeakviking : MonoBehaviour
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
    public Camera mainCamera;
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
            if (Input.GetKeyDown(KeyCode.E))
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
        if (chatting)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                endchat();

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                chatnum++;
            }


            {
                if (chatnum == 0)
                {
                    chat.text = "hello";
                }
                if (chatnum == 1)
                {
                    chat.text = "they sent you?";
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
                    chat.text = "Here, take this gem";
                }
                if (chatnum == 5)
                {
                    chat.text = "hop on the boat to get to the next island";
                }
                if (chatnum == 6)
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
