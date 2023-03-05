using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class coincollect : MonoBehaviour
{
    private GameObject player;
    public AudioClip coincollectnoise;
    private AudioSource audioplayer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioplayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<moneypouch>().amountofmoney++;
            audioplayer.clip = coincollectnoise;
            audioplayer.Play();

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
