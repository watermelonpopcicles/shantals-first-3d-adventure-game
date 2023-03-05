using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engame : MonoBehaviour
{


    public AudioClip flagnoise;
    private AudioSource audioplayer;
    public moneypouch mp;
    public GameObject losescreen;

    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
        mp = FindObjectOfType<moneypouch>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (mp.amountofmoney>= 5) {
                StartCoroutine(scenedelay());
            }
            else
            {
                StartCoroutine(notenoughcoins());
            }
            
        }
    }

    IEnumerator notenoughcoins()
    {
        GameObject collision = GameObject.FindGameObjectWithTag("Player");
        float t1 = collision.GetComponent<Platformer>().speed;
        float t2 = collision.GetComponent<Platformer>().jumpForce;
        float t3 = collision.GetComponent<Platformer>().lowJumpMultiplier;
        collision.gameObject.GetComponent<Platformer>().speed = 0;
        collision.gameObject.GetComponent<Platformer>().jumpForce = 0;
        collision.gameObject.GetComponent<Platformer>().lowJumpMultiplier = 0;
        yield return new WaitForSeconds(3);
        losescreen.SetActive(true);
        yield return new WaitForSeconds(1);
        losescreen.SetActive(false);
        GameObject.FindObjectOfType<kill>().respawns();
        collision.GetComponent<Platformer>().speed = t1;
        collision.GetComponent<Platformer>().jumpForce = t2;
        collision.GetComponent<Platformer>().lowJumpMultiplier = t3;

        //SceneManager.LoadScene(0);
    }

    IEnumerator scenedelay()
    {
        GameObject collision = GameObject.FindGameObjectWithTag("Player");
        collision.GetComponent<Platformer>().speed = 0;
        collision.GetComponent<Platformer>().jumpForce = 0;
        collision.GetComponent<Platformer>().lowJumpMultiplier = 0;
        yield return new WaitForSeconds(3);
        audioplayer.clip = flagnoise;
        audioplayer.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Win screen");
    }
}
