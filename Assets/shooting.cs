using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowspawn;
    public float allowedshotspersec;
    public float strength;
    private float ctime; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ctime >= allowedshotspersec)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject clone = Instantiate(arrow, arrowspawn.position, arrowspawn.rotation);
                ctime = 0;
                Rigidbody rb = clone.GetComponent<Rigidbody>();
                rb.AddForce(clone.transform.forward * strength, ForceMode.Impulse);
                
            }
        }
        else {
            ctime += Time.deltaTime;
        }
    }
}
