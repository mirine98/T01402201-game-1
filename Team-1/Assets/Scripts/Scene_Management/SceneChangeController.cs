using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController : MonoBehaviour
{
    static private float playerXCoordinate;
    static private float playerYCoordinate;
    static private Rigidbody2D playerrb;
    static private Vector2 playerVelocity;

    [SerializeField]
    private int NextSceneIndex;
    private int CurrentSceneIndex;
    private int PreviousSceneIndex;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어 오브젝트와 충돌한 경우
        if (other.CompareTag("Player"))
        {
            Debug.Log("Scene change!");
            // 플레이어의 x,y 좌표 값을 저장
            playerXCoordinate = other.transform.position.x;
            playerYCoordinate = other.transform.position.y;

            // 플레이어의 velocity 값을 저장
            Rigidbody2D playerrb = other.GetComponent<Rigidbody2D>();
            if (playerrb != null)
            {
                playerVelocity = playerrb.velocity;
            }

            // 다음 씬으로 이동
            if (CurrentSceneIndex == 0)
            {
                SceneManager.LoadScene(CurrentSceneIndex + 1);
            }
        }
    }

    private void Start()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PreviousSceneIndex = CurrentSceneIndex - 1;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (CurrentSceneIndex > 0)
        {
            // 이동한 씬에서 플레이어의 x, y 좌표 설정
            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;
                playerPosition.x = playerXCoordinate;
                playerPosition.y = playerYCoordinate;
                player.transform.position = playerPosition;
            }

            // 이동한 씬에서 플레이어의 rigidbody를 가져옴.
            if (player != null)
            {
                Rigidbody2D playerrb = player.GetComponent<Rigidbody2D>();
                if (playerrb != null)
                {
                    playerrb.velocity = playerVelocity;
                    Debug.Log("player.velocity : " + playerrb.velocity);
                }
            }
        }
    }
}