using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoombow : MonoBehaviour
{
    public GameObject bow;
    public Transform zoom;
    public Transform notzoom;
    // Start is called before the first frame update
    void Start()
    {
        bow.transform.position = notzoom.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) 
        { 
            bow.transform.position = zoom.position;
        }
        else
        {
            bow.transform.position = notzoom.position;
        }
    }
}
