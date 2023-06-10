using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_drop_test : MonoBehaviour
{
    public GameObject[] tetrisPrefabs; // 7개의 프리팹을 저장하는 배열
    public Transform spawnPosition; // 생성 위치

    private void Start()
    {
        InvokeRepeating("SpawnRandomTetris", 0f, 15f);
        spawnPosition = transform;
    }

    private void SpawnRandomTetris()
    {
        // 랜덤한 인덱스로 프리팹 선택
        int randomIndex = Random.Range(0, tetrisPrefabs.Length);
        GameObject randomTetris = tetrisPrefabs[randomIndex];

        // 생성 위치 설정
        Vector3 position = spawnPosition.position;
        position.y -= 3f; // 생성기 오브젝트보다 3 아래로 설정

        // 프리팹을 생성 위치에 생성
        Instantiate(randomTetris, position, Quaternion.identity);
    }
}
