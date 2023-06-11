using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private GameObject player;
    public float lifetime = 10f;
    public float speed = 3.5f;

    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Vector3 velocity = direction.normalized * speed;
            transform.position += velocity * Time.deltaTime;
        }

    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}