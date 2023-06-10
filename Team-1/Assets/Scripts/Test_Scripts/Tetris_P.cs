using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_P : MonoBehaviour
{
    public float dropInterval = 0.5f; // 떨어지는 간격 (초 단위)
    public float tileSize = 2f; // 타일 크기 (y축으로 이동할 거리)

    private float timer; // 타이머 변수

    private void Start()
    {
        timer = dropInterval;
    }

    private void Update()
    {
        // 타이머 업데이트
        timer -= Time.deltaTime;

        // 타이머가 0 이하일 때, 타일을 아래로 이동
        if (timer <= 0f)
        {
            transform.Translate(Vector3.down * tileSize);

            // 다음 이동 간격 설정
            timer = dropInterval;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("vanish"))
        {
            DestroyWithDelay(gameObject, 1.5f); // 1초 후에 객체 삭제
        }
    }

    private void DestroyWithDelay(GameObject obj, float delay)
    {
        Destroy(obj, delay);
    }
}