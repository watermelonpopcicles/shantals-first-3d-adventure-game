using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimetextbubbleappear : MonoBehaviour
{
    public GameObject slimebubble;
    bool playernearslime;
    // Start is called before the first frame update
    void Start()
    {
        slimebubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            slimebubble.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            slimebubble.SetActive(false);
        }
    }
}
