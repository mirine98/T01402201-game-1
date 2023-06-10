using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class viewer_tutorial : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    void Update()
    {
        if (player.transform.position.x > transform.position.x + 15f)
        {
            transform.position = new Vector3(transform.position.x + 15f, transform.position.y, -10);
        }
        if (player.transform.position.x < transform.position.x - 15f)
        {
            transform.position = new Vector3(transform.position.x - 15f, transform.position.y, -10);
        }
        if (player.transform.position.y > transform.position.y + 10f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10f, -10);
        }
        if (player.transform.position.y < transform.position.y - 10f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10f, -10);
        }
    }
}