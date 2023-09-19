using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixrotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.eulerAngles;
        temp.x = 0;
        temp.z = 0;
        transform.eulerAngles = temp;

    }
}
