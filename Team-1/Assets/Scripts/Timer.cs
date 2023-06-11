using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    public TextMeshProUGUI timer;
    private float initialTime = 10.3f;
    private float curTime;

    // Start is called before the first frame update
    void Start()
    {
        curTime = initialTime;
        timer = GetComponent<TextMeshProUGUI>();
        timer.enabled = false; // Ÿ�̸Ӹ� �ʱ⿡�� ��Ȱ��ȭ ���·� �����մϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.getCoin)
        {
            curTime = 10.3f;
            playerMovement.getCoin = false;
        }
        else
        {
            curTime -= Time.deltaTime;
            if (curTime <= 0)
            {
                curTime = 0;
            }
        }

        // �÷��̾��� Y�� ��ġ�� 295 �̻��� ��쿡�� Ÿ�̸Ӹ� Ȱ��ȭ�մϴ�.
        if (playerMovement.transform.position.y >= 158f)
        {
            timer.enabled = true;
            timer.text = "Timer: " + Mathf.FloorToInt(curTime).ToString();
        }
        else
        {
            timer.enabled = false;
        }
    }
}
