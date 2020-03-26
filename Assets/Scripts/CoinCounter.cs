using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public GameObject coins;
    private int numCoins;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        numCoins = coins.transform.childCount;
    }

    public int getNumCoins()
    {
        return numCoins;
    }
}
