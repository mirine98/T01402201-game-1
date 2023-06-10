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
        // �÷��̾� ������Ʈ�� �浹�� ���
        if (other.CompareTag("Player"))
        {
            Debug.Log("Scene change!");
            // �÷��̾��� x,y ��ǥ ���� ����
            playerXCoordinate = other.transform.position.x;
            playerYCoordinate = other.transform.position.y;

            // �÷��̾��� velocity ���� ����
            Rigidbody2D playerrb = other.GetComponent<Rigidbody2D>();
            if (playerrb != null)
            {
                playerVelocity = playerrb.velocity;
            }

            // ���� ������ �̵�
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
            // �̵��� ������ �÷��̾��� x, y ��ǥ ����
            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;
                playerPosition.x = playerXCoordinate;
                playerPosition.y = playerYCoordinate;
                player.transform.position = playerPosition;
            }

            // �̵��� ������ �÷��̾��� rigidbody�� ������.
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