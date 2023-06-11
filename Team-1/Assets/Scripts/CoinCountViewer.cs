using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountViewer : MonoBehaviour
{
    [SerializeField]
    private NumCoin numCoin;
    private TextMeshProUGUI textCoinCount;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        textCoinCount = GetComponent<TextMeshProUGUI>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.transform.position.y >= 158f)
        {
            textCoinCount.text = numCoin.CurrentCoinCount + "/" + numCoin.MaxCoinCount;
        }
        else
        {
            textCoinCount.text = string.Empty;
        }
    }
}