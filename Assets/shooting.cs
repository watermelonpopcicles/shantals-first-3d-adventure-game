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
    public Transform zoom;
    public Transform notzoom;
    public Transform Bow;
    public Camera firstCamera;

    public void unzoom() 
    {
        crosshair.SetActive(false);
        Bow.SetParent(notzoom);
        Bow.localPosition = Vector3.zero;
        if (firstCamera != null)
        {
            firstCamera.fieldOfView = Mathf.MoveTowards(firstCamera.fieldOfView, FOV, lerpspeed * Time.deltaTime);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        FOV = firstCamera.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(false);
        Bow.SetParent(notzoom);
        Bow.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            firstCamera.fieldOfView = Mathf.MoveTowards(firstCamera.fieldOfView, FOV_Aim, lerpspeed * Time.deltaTime);
            crosshair.SetActive(true);
            Bow.SetParent(zoom);
            Bow.localPosition = Vector3.zero;
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
            Bow.SetParent(notzoom);
            Bow.localPosition = Vector3.zero;
            if (firstCamera != null)
            {
                firstCamera.fieldOfView = Mathf.MoveTowards(firstCamera.fieldOfView, FOV, lerpspeed * Time.deltaTime);
            }
        }
    }
}
