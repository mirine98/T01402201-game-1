using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.ScenManagement;

public class NumCoin : MonoBehaviour
{
    private int maxCoinCount;
    private int currentcoinCount;
    public int MaxCoinCount => maxCoinCount;
    public int CurrentCoinCount => currentcoinCount;
    private GameObject finalCoin;

    //private GameObject PanelStageClear;
    public bool getAllCoins = false;
    public bool allBasicCoins = false;

    // Start is called before the first frame update
    public void Start()
    {
        Time.timeScale = 1.0f;
        //PanelStageClear.SetActive(false);
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        GameObject[] finalcoins = GameObject.FindGameObjectsWithTag("FinalCoin");
        maxCoinCount = coins.Length + finalcoins.Length;
        currentcoinCount = 0;
        finalCoin = GameObject.FindGameObjectWithTag("FinalCoin");
        finalCoin.SetActive(false);
    }

    // Update is called once per frame
    public void GetCoin()
    {
        currentcoinCount += 1;
        if (currentcoinCount == maxCoinCount - 1)
        {
            finalCoin.SetActive(true);
        }
        if (currentcoinCount == maxCoinCount)
        {
            getAllCoins = true;
            Time.timeScale = 0.0f;
            //PanelStageClear.SetActive(true);
        }
    }

    //¥Ÿ ∏‘¿∏∏È ≥°
    /*private void Update()
    {
        if (getAllCoins == true)
        {
            ScenManager.LoadScene(nextSceneName);
        }
    }*/
}
