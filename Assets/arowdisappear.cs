using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arowdisappear : MonoBehaviour
{
    IEnumerator targetdissapears(GameObject target) 
    {
        yield return new WaitForSecondsRealtime(1);
        Debug.Log(target.tag);
        target.SetActive(false);
        Destroy(gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        if (collision.gameObject.CompareTag("Target")) 
        {
            StartCoroutine("targetdissapears", collision.gameObject);

        }
        
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        else {
            Destroy(gameObject, 1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
