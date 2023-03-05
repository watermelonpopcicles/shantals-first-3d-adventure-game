using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform Player;
    private Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform ;
        offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position + offset;
    }
}
