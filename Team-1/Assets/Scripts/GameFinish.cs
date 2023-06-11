using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFinish : MonoBehaviour
{
    [SerializeField]
    private NumCoin numCoin;
    private TextMeshProUGUI textMessage;

    // Start is called before the first frame update
    void Start()
    {
        textMessage = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (numCoin.getAllCoins)
        {
            textMessage.text = "GameFinish";
        }
    }
}
