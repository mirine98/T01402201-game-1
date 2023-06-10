using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_drop_test : MonoBehaviour
{
    public GameObject[] tetrisPrefabs; // 7���� �������� �����ϴ� �迭
    public Transform spawnPosition; // ���� ��ġ

    private void Start()
    {
        InvokeRepeating("SpawnRandomTetris", 0f, 15f);
        spawnPosition = transform;
    }

    private void SpawnRandomTetris()
    {
        // ������ �ε����� ������ ����
        int randomIndex = Random.Range(0, tetrisPrefabs.Length);
        GameObject randomTetris = tetrisPrefabs[randomIndex];

        // ���� ��ġ ����
        Vector3 position = spawnPosition.position;
        position.y -= 3f; // ������ ������Ʈ���� 3 �Ʒ��� ����

        // �������� ���� ��ġ�� ����
        Instantiate(randomTetris, position, Quaternion.identity);
    }
}
