using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moneypouch : MonoBehaviour
{
    public int amountofmoney;
    public Text cointext;
    // Start is called before the first frame update
    void Start()
    {
        cointext.text = "Coin Collected: " + amountofmoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = "Coin Collected: " + amountofmoney.ToString();
    }
}
