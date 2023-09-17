using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstpersonshoot : MonoBehaviour
{
    public float speedX = 270;
    public float speedY = 270;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X") * speedX;
        float v = Input.GetAxis("Mouse Y") * -speedY;


        Vector3 mov = new Vector3(v, h, 0);
        transform.Rotate(mov * Time.deltaTime);

        Vector3 temp = transform.eulerAngles;
        temp.z = 0;
        transform.eulerAngles = temp;
    }
}
