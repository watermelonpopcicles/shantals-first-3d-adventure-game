using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimetextbubbleappear : MonoBehaviour
{
    public GameObject slimebubble;
    public bool playernearslime;
    // Start is called before the first frame update
    void Start()
    {
        slimebubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playernearslime) 
        {
            slimebubble.SetActive(true);

        }
        


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.comparetag)
        playernearslime = false
    }
}
