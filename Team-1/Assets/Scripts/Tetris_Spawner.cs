using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_Spawner : MonoBehaviour
{
    public GameObject[] tetrisBlockPrefabs;
    public float spawnInterval = 1f;
    public float gravityInterval = 1f;

    private float spawnTimer = 0f;
    private float gravityTimer = 0f;
    private GameObject currentBlock;

    private void Start()
    {
        SpawnBlock();
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        gravityTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnBlock();
            spawnTimer = 0f;
        }
    }

    private void SpawnBlock()
    {
        int randomIndex = Random.Range(0, tetrisBlockPrefabs.Length);
        GameObject blockPrefab = tetrisBlockPrefabs[randomIndex];
        Vector3 spawnPosition = transform.position;

        currentBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
    }


}
