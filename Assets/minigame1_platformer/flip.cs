using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Jellybeans;
    public Sprite[] madJelly;
    private int countjelly;
    private int countmad;
    private SpriteRenderer r;
    private bool touchground;
    private bool smiley;
    public AudioClip plopnoise;
    private AudioSource audioplayer;

    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        countjelly = -1;
        //r.sprite = Jellybeans[countjelly % Jellybeans.Length];
        smiley = false;
        audioplayer = GetComponent<AudioSource>();
    }
    void flippy() {

        if (smiley)
        {
            countmad++;
            r.sprite = madJelly[countmad % madJelly.Length];
        }
        else
        {
            countjelly++;
            r.sprite = Jellybeans[countjelly % Jellybeans.Length];
        }
        smiley = !smiley;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            touchground = false;
        }
        if (audioplayer == null) {
            audioplayer = GetComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!touchground && audioplayer) {
            audioplayer.clip = plopnoise;
            audioplayer.Play();

            touchground = true;
            flippy();
        }
        
    }
}
