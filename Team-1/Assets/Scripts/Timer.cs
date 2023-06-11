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
        timer.enabled = false; // 타이머를 초기에는 비활성화 상태로 설정합니다.
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

        // 플레이어의 Y축 위치가 295 이상인 경우에만 타이머를 활성화합니다.
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
