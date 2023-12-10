using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grasslandmanager : MonoBehaviour
{
    public GameObject Targets;
    public float targettimer = 20;
    private float ctime;
    public bool targetgamestart;
    public TMP_Text timer;
    public TMP_Text timer2;
    public bool ArcherGameWon;
    public slimespeak SlimeSpeakScript;
    public shooting shootingscript;
    public GameObject yellowslime;

    // Start is called before the first frame update
    void Start()
    {
        timer.gameObject.SetActive(false);
        timer2.gameObject.SetActive(false);
        yellowslime.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (targetgamestart)
        {
            timer.gameObject.SetActive(true);
            timer2.gameObject.SetActive(true);
            if (ctime < targettimer)
            {
                ctime += Time.deltaTime;
                timer.text = "time: " + Mathf.RoundToInt(targettimer - ctime).ToString();
                timer2.text = "time: " + Mathf.RoundToInt(targettimer - ctime).ToString();

                int liveTargets = 0;
                foreach (Transform target in Targets.transform)
                {
                    if (target.gameObject.activeSelf) {
                        liveTargets++;
                    }
                }
                if (liveTargets == 0) {
                    ArcherGameWon = true;
                    ctime = targettimer;
                    yellowslime.SetActive(true);

                }
                



            }
            else 
            {
                targetgamestart = false;
                ctime = 0;
                foreach (Transform target in Targets.transform) 
                {
                    target.gameObject.SetActive(true);
                }
                timer.gameObject.SetActive(false);
                timer2.gameObject.SetActive(false);
                shootingscript.unzoom();
                SlimeSpeakScript.ResumeChat(ArcherGameWon);

            }
        }
    }
}
