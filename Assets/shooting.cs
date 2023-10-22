using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject arrow;
    public float FOV_Aim = 20;
    public float lerpspeed;
    private float FOV;
    public GameObject crosshair;
    public Transform arrowspawn;
    public float allowedshotspersec;
    public float strength;
    private float ctime;
    public Transform CameraForward;
    // Start is called before the first frame update
    void Start()
    {
        FOV = Camera.main.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, FOV_Aim, lerpspeed * Time.deltaTime);
            crosshair.SetActive(true);
            if (ctime >= allowedshotspersec)
            {

                if (Input.GetMouseButton(0))
                {
                    GameObject clone = Instantiate(arrow, arrowspawn.position, arrowspawn.rotation);
                    //clone.transform.forward = arrowspawn.transform.forward - arrowspawn.TransformDirection(new Vector3(0, 0, -62));
                    clone.transform.LookAt(CameraForward);
                    ctime = 0;
                    Rigidbody rb = clone.GetComponent<Rigidbody>();
                    rb.AddForce(clone.transform.forward * strength, ForceMode.Impulse);

                }
            }
            else
            {
                ctime += Time.deltaTime;
            }
        }

        else
        {
            crosshair.SetActive(false);
            Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, FOV, lerpspeed * Time.deltaTime);
        }
    }
}
