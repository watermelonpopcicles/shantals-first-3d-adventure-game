using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grasslandmanager : MonoBehaviour
{
    private int targetshit;
    public float targettimer = 60;
    private float ctime;
    public bool targetgamestart;

    public void targetdestroyed() 
    {
        targetshit++;
        int numtarget = GameObject.FindGameObjectsWithTag("Target").Length;
        if (targetshit >= numtarget) 
        {
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetgamestart)
        {
            if (ctime < targettimer)
            {
                ctime += Time.deltaTime;

            }
            else 
            {
                targetgamestart = false;
                ctime = 0;
                GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
                foreach (GameObject target in targets) 
                {
                    target.SetActive(true);
                }
            }
        }
    }
}
