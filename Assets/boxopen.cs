using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxopen : MonoBehaviour
{
    public GameObject chesthint;
    public GameObject gemhint;
    public Animator chest;
    public bool isplayernear;

    // Start is called before the first frame update
    void Start()
    {
       chesthint.SetActive(false);
        gemhint.SetActive(false);
        chest.SetBool("open", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isplayernear)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                chest.SetBool("open", true);
                GetComponent<AudioSource>().Play();
                chesthint.SetActive(false);
                gemhint.SetActive(true);

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(GameObject.FindObjectOfType<desert_manager>().cactushit<5) { return; }
        if (other.gameObject.tag == "Player"){
            chesthint.SetActive(true);
            isplayernear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chesthint.SetActive(false);
            isplayernear = false;
        }
    }
}
