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
    public bool shoveling;
    // Start is called before the first frame update
    void Start()
    {
        Shovel.SetActive(false);
        mound.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (cactushit >= 5 && !shoveling) {
            StartCoroutine(ShovelAnimation());
        shoveling = true;
        }
    }


    IEnumerator ShovelAnimation()
    {
        Shovel.SetActive(true);
        yield return new WaitForSeconds(10);
        Shovel.SetActive(false);
        mound.SetActive(false);
        treasurechest.SetActive(true);


    }
}
