using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desert_manager : MonoBehaviour
{
    public int cactushit;
    public GameObject Shovel;
    public GameObject mound;
    public GameObject treasurechest;
    public GameObject emerald;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cactushit >= 5) {
            StartCoroutine(ShovelAnimation());
        }
    }


    IEnumerator ShovelAnimation()
    {
        Shovel.SetActive(true);
        yield return new WaitForSeconds(6);
        Shovel.SetActive(false);
        mound.SetActive(false);
        treasurechest.SetActive(true);


    }
}
