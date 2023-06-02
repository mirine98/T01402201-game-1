using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tetris_Spawner_Behavior : MonoBehaviour
{
    public Transform Player; // player 오브젝트의 Transform 컴포넌트를 참조하는 변수
    public float yThreshold; // player의 y 높이 이상을 기준으로 설정하는 변수
    public float disableHeight; // 비활성화할 y 높이를 설정하는 변수

    private Vector2 pos;
    private float dist;
    private bool isActive = true; // tetris_spawner의 활성화 여부를 나타내는 변수
    private void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        dist = transform.position.y - Player.position.y;
        //플레이어보다 항상 높게 spawner 유지
        if (dist <= yThreshold)
        {
            transform.position += new Vector3(0, 5f, 0);
        }

        // 플레이어가 일정 높이에 도달하기 전까지 tetris_spawner 비활성화 유지
        if (Player.position.y >= disableHeight)
        {
            gameObject.SetActive(true);
        }
    }
}