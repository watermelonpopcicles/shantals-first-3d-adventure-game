using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public bool ready;
    public GameObject gemhint;
    public GameObject dock;
    public GameObject boat;
    public GameObject signpost;
    public Transform spawnpoint;


    // Start is called before the first frame update
    void Start()
    {
        dock.SetActive(false);
        boat.SetActive(false);
        signpost.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            if (Input.GetKeyDown(KeyCode.C)) 
            { 
            GetComponent<AudioSource>().Play();

                GetComponent<MeshCollider>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                gemhint.SetActive(false);
                daMananger.instance.collectGem();
                dock.SetActive(true);
                boat.SetActive(true);
                signpost.SetActive(true);
                spawnpoint.position = boat.transform.position + new Vector3(0, 6, 0);
                spawnpoint.SetParent(boat.transform);

            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ready = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ready = false;
        }
    }
}
