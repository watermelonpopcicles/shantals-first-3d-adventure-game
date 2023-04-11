using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dierespawn : MonoBehaviour
{

    public Transform spawn;
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player")) 
        {
            
            collision.transform.position = spawn.position;
            Player = collision.gameObject.transform;
            StartCoroutine(collisionStuff());
// collision.gameObject.transform.position=spawn.position;
        }
    }

    IEnumerator collisionStuff() {
        Player.gameObject.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(.8f);
        Player.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
