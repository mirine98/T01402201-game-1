using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class viewer_tutorial : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        float playerY = player.transform.position.y;
        Debug.Log(playerY);

        if (playerY < 80f)
        {
            Vector3 newPosition = new Vector3(-4f, 64f, transform.position.z);
            transform.position = newPosition;
        }
        if (playerY < 64f)
        {
            Vector3 newPosition = new Vector3(-4f, 55f, transform.position.z);
            transform.position = newPosition;
        }

        if (playerY < 55f)
        {
            Vector3 newPosition = new Vector3(-4f, 43f, transform.position.z);
            transform.position = newPosition;
        }
        if (playerY < 43f)
        {
            Vector3 newPosition = new Vector3(-4f, 33f, transform.position.z);
            transform.position = newPosition;
        }

        if (playerY < 33f)
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