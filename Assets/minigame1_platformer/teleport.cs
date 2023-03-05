using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform destination;
    public AudioClip teleportnoise;
    private AudioSource audioplayer;

    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = destination.position;
        audioplayer.clip = teleportnoise;
        audioplayer.Play();

    }
}
