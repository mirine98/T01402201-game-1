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
        float playerX = player.transform.position.x;
        Debug.Log(playerY);
        Debug.Log(playerX);


        if (playerY < 11.2f)
        {
            Vector3 newPosition = new Vector3(-4f, 1.5f, transform.position.z);
            transform.position = newPosition;

        }
        else if (playerY < 22f)
        {
            Vector3 newPosition = new Vector3(-4f, 11.2f, transform.position.z);
            transform.position = newPosition;
        }
        else if (playerY < 31.5f)

        {
            Debug.Log(playerX);
            if (playerX < 0)
            {
                Vector3 newPosition = new Vector3(-12f, 22f, transform.position.z);
                transform.position = newPosition;
            }
            else if (playerX < 20)
            {
                Vector3 newPosition = new Vector3(-4f, 22f, transform.position.z);
                transform.position = newPosition;
            }

        }
        else if (playerY < 42f)
        {
                
            if (playerX < 0)
            {
                Vector3 newPosition = new Vector3(-12f, 31.5f, transform.position.z);
                transform.position = newPosition;
            }
            else if (playerX < 15)
            {
                Vector3 newPosition = new Vector3(-4f, 31.5f, transform.position.z);
                transform.position = newPosition;
            }
            else if (playerX < 40)
            {
                Vector3 newPosition = new Vector3(8f, 40f, transform.position.z);
                transform.position = newPosition;
            }

        }
        else if (playerY < 50f)
        {

            if (playerX < 0)
            {
                Vector3 newPosition = new Vector3(-12f, 42f, transform.position.z);
                transform.position = newPosition;
            }
            else if (playerX < 15)
            {
                Vector3 newPosition = new Vector3(-4f, 42f, transform.position.z);
                transform.position = newPosition;
            }
            else if (playerX < 40)
            {
                Vector3 newPosition = new Vector3(8f, 52f, transform.position.z);
                transform.position = newPosition;
            }
        }
        else if (playerY < 64f)
        {

            if (playerX < -11)
            {
                Vector3 newPosition = new Vector3(-12f, 48f, transform.position.z);
                transform.position = newPosition;
            }

            else if (playerX < 15)
            {
                Vector3 newPosition = new Vector3(0f, 56f, transform.position.z);
                transform.position = newPosition;
            }
            else if (playerX < 40)
            {
                Vector3 newPosition = new Vector3(8f, 56f, transform.position.z);
                transform.position = newPosition;
            }

        }



    }
}