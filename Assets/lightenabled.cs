using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightenabled : MonoBehaviour
{
    public Light Cactuslight;
    public AudioSource cactusbing;
    private bool alreadyhit;
    // Start is called before the first frame update
    void Start()
    {
        Cactuslight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("rollyball") && !alreadyhit)
        {
            Cactuslight.enabled = true;
            cactusbing.Play();
            alreadyhit = true;
            GetComponentInParent<desert_manager>().cactushit += 1;
        }
    }
}
