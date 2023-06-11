using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_Behavior : MonoBehaviour
{
    public Transform Player;

    private float fall_dist;
    private float rotate_dist;

    [SerializeField] private float fallInterval;
    [SerializeField] private float RotateInterval = 2;
    [SerializeField] private float y_max;
    [SerializeField] private float fall_timer;
    private void Start()
    {
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        while (true)
        {
            fall_dist = Mathf.Abs(transform.position.y - Player.position.y);
            rotate_dist = Mathf.Abs(transform.position.x - Player.position.x);
            if ((fall_dist < fallInterval * 3) & (rotate_dist <= RotateInterval))
            {
                if (rotate_dist >= RotateInterval)
                {
                    transform.Rotate(0f, 0f, -90);
                }
                yield return new WaitForSeconds(fall_timer);
                continue;
            }

            // �Ʒ��� �̵�
            Vector3 newPosition = transform.position;
            newPosition.y -= fallInterval;
            transform.position = newPosition;

            if (transform.position.y < y_max)
            {
                Destroy(gameObject);
                break;
            }
            yield return new WaitForSeconds(fall_timer); //fall_timer��ŭ ���
        }
    }

    IEnumerator RandomRotate()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f)); // ������ �ð� �������� ��ٸ��ϴ�.

            fall_dist = Mathf.Abs(transform.position.y - Player.position.y);
            if (fall_dist >= fallInterval * 3)
            {
                transform.Rotate(Vector3.forward * 90f);
            }
            // ��Ʈ���� ����� ȸ����ŵ�ϴ�.
        }
    }
    private void Update()
    {
    }

}