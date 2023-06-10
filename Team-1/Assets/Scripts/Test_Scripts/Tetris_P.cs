using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_P : MonoBehaviour
{
    public float dropInterval = 0.5f; // �������� ���� (�� ����)
    public float tileSize = 2f; // Ÿ�� ũ�� (y������ �̵��� �Ÿ�)

    private float timer; // Ÿ�̸� ����

    private void Start()
    {
        timer = dropInterval;
    }

    private void Update()
    {
        // Ÿ�̸� ������Ʈ
        timer -= Time.deltaTime;

        // Ÿ�̸Ӱ� 0 ������ ��, Ÿ���� �Ʒ��� �̵�
        if (timer <= 0f)
        {
            transform.Translate(Vector3.down * tileSize);

            // ���� �̵� ���� ����
            timer = dropInterval;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("vanish"))
        {
            DestroyWithDelay(gameObject, 1.5f); // 1�� �Ŀ� ��ü ����
        }
    }

    private void DestroyWithDelay(GameObject obj, float delay)
    {
        Destroy(obj, delay);
    }
}