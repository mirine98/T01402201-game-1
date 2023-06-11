using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    private bool isAppeared = true;
    public Transform chatTr;
    public string[] sentences;
    public GameObject chatBoxPrefab;

    [SerializeField] private Transform playerTransform; // 플레이어의 Transform 컴포넌트
    [SerializeField] private float detectionRadius = 3f; // 플레이어를 감지하는 거리

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.GetComponent<ChatSystem>().Ondialogue(sentences, chatTr);
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어와의 거리 계산
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        // 플레이어가 일정 거리 이내로 다가왔을 때 말풍선을 표시
        if ((distanceToPlayer <= detectionRadius) & (isAppeared))
        {
            Debug.Log("Talk");
            TalkNpc();
            isAppeared = false;
        }
        if (!(distanceToPlayer <= detectionRadius + 2))
        {
            isAppeared = true;
        }

    }
}