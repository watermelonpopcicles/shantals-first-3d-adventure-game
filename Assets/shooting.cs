using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject arrow;
    public float FOV_Aim = 20;
    public float lerpspeed;
    private float FOV;

    public Transform arrowspawn;
    public float allowedshotspersec;
    public float strength;
    private float ctime;
    // Start is called before the first frame update
    void Start()
    {
        FOV = Camera.main.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView,FOV_Aim, lerpspeed * Time.deltaTime);
            if (ctime >= allowedshotspersec)
            {
                //if (Input.GetMouseButton(0))
                //{
                GameObject clone = Instantiate(arrow, Camera.main.transform.position, Camera.main.transform.rotation);
                ctime = 0;
                Rigidbody rb = clone.GetComponent<Rigidbody>();
                rb.AddForce(Camera.main.transform.forward * strength, ForceMode.Impulse);

                 //}
            }
            else
            {
                ctime += Time.deltaTime;
            }
        }

        else
        {
            Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, FOV, lerpspeed * Time.deltaTime);
        }
    }
}
