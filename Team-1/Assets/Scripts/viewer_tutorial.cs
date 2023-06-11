using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class viewer_tutorial : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float x_maximum = 15f;
    [SerializeField] private float y_maximum = 8f;
    [SerializeField] private float x_movement = 20f;
    [SerializeField] private float y_movement = 15f;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    void Update()
    {
        if (player.transform.position.x > transform.position.x + x_maximum)
        {
            transform.position = new Vector3(transform.position.x + x_movement, transform.position.y, -10);
        }
        if (player.transform.position.x < transform.position.x - x_maximum)
        {
            transform.position = new Vector3(transform.position.x - x_movement, transform.position.y, -10);
        }
        if (player.transform.position.y > transform.position.y + y_maximum)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + y_movement, -10);
        }
        if (player.transform.position.y < transform.position.y - y_maximum)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - y_movement, -10);
        }
    }
}