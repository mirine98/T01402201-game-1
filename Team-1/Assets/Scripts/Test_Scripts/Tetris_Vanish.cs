using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_Vanish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tetris"))
        {
            Debug.Log("�浹!! �浹!!");
            Destroy(other.gameObject);
        }
    }
}
