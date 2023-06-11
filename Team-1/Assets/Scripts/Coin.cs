using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private NumCoin numCoin;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        numCoin.GetCoin();
        gameObject.SetActive(false);
    }
}
