using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tetris_Spawner_Behavior : MonoBehaviour
{
    public Transform Player; // player ������Ʈ�� Transform ������Ʈ�� �����ϴ� ����
    public float yThreshold; // player�� y ���� �̻��� �������� �����ϴ� ����
    public float disableHeight; // ��Ȱ��ȭ�� y ���̸� �����ϴ� ����

    private Vector2 pos;
    private float dist;
    private bool isActive = true; // tetris_spawner�� Ȱ��ȭ ���θ� ��Ÿ���� ����
    private void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        dist = transform.position.y - Player.position.y;
        //�÷��̾�� �׻� ���� spawner ����
        if (dist <= yThreshold)
        {
            transform.position += new Vector3(0, 5f, 0);
        }

        // �÷��̾ ���� ���̿� �����ϱ� ������ tetris_spawner ��Ȱ��ȭ ����
        if (Player.position.y >= disableHeight)
        {
            gameObject.SetActive(true);
        }
    }
}