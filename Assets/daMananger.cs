using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class daMananger : MonoBehaviour
{
    public static daMananger instance;
    public TMP_Text gemTextWhite;
    public TMP_Text gemTextBlack;


    public int GemsCollected;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void collectGem() {
        GemsCollected += 1;
        gemTextBlack.text = "Gem Count: " + GemsCollected.ToString();
        gemTextWhite.text = "Gem Count: " + GemsCollected.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        gemTextBlack.text = "Gem Count: " + GemsCollected.ToString();
        gemTextWhite.text = "Gem Count: " + GemsCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
