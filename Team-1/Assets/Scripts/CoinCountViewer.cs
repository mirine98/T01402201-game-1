using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountViewer : MonoBehaviour
{
    [SerializeField]
    private NumCoin numCoin;
    private TextMeshProUGUI textCoinCount;

    // Start is called before the first frame update
    void Awake()
    {
        textCoinCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textCoinCount.text = numCoin.CurrentCoinCount + "/" + numCoin.MaxCoinCount;
    }
}
