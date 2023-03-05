using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reversegravity : MonoBehaviour
{
    public bool reversed;
    private bool original;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        original = reversed;
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    public void Resetgravity()
    {
        reversed = original;

            
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (reversed)
            {
                Physics2D.gravity = -Physics2D.gravity;
                collision.transform.localScale = new Vector3(1.5f, -1.5f, 1.5f);
                collision.GetComponent<Platformer>().jumpForce *= -1;
            }
            else
            {
                Physics2D.gravity = -Physics2D.gravity;
                collision.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                collision.GetComponent<Platformer>().jumpForce *= -1;
            }
        }
    }

}
