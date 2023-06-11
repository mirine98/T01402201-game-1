using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    private bool isAppeared = true;
    public Transform chatTr;
    public string[] sentences;
    public GameObject chatBoxPrefab;

    [SerializeField] private Transform playerTransform; // �÷��̾��� Transform ������Ʈ
    [SerializeField] private float detectionRadius = 3f; // �÷��̾ �����ϴ� �Ÿ�

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
        // �÷��̾���� �Ÿ� ���
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        // �÷��̾ ���� �Ÿ� �̳��� �ٰ����� �� ��ǳ���� ǥ��
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