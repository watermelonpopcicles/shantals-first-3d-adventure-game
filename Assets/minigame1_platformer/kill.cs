using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    public Transform respawnpoint;
    private GameObject Player;
    public AudioClip respawn_noise;
    private AudioSource audioplayer;
    // Start is called before the first frame update
    void Start()
    {
        respawnpoint = GameObject.Find("respawn point").transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        audioplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void respawns()
    {
        Player.transform.position = respawnpoint.position;
        audioplayer.clip = respawn_noise;
        audioplayer.Play();

        Vector2 posGrav = new Vector2(Mathf.Abs(Physics2D.gravity.x), Mathf.Abs(Physics2D.gravity.y));
        Physics2D.gravity = -posGrav;
        Player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Player.GetComponent<Platformer>().jumpForce = Mathf.Abs(Player.GetComponent<Platformer>().jumpForce);



        reversegravity[] objs = GameObject.FindObjectsOfType<reversegravity>();
        foreach (reversegravity rg in objs)
        {
            rg.Resetgravity();

        }

        coincollect[] coins = GameObject.FindObjectsOfType<coincollect>();

        foreach (coincollect cc in coins)
        {
            cc.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        Player.GetComponent<moneypouch>().amountofmoney = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            respawns();
        }

    }
}
