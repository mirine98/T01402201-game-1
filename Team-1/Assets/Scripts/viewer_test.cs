using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class viewer_test : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        float playerY = player.transform.position.y;
        Debug.Log(playerY);

        if (playerY < 50f)
        {
            Vector3 newPosition = new Vector3(-4f, 22f, transform.position.z);
            transform.position = newPosition;
        }

        if (playerY < 22f)
        {
            Vector3 newPosition = new Vector3(-4f, 11.2f, transform.position.z);
            transform.position = newPosition;
        }

        if (playerY < 11.2f)
        {
            Vector3 newPosition = new Vector3(-4f, 1.5f, transform.position.z);
            transform.position = newPosition;

        }

    }
}