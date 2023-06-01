using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tetris_Behavior : MonoBehaviour
{
    [SerializeField] private float fallInterval;
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
            // 아래로 이동
            Vector3 newPosition = transform.position;
            newPosition.y -= fallInterval;
            transform.position = newPosition;

            if (transform.position.y < y_max)
            {
                break;
            }

            yield return new WaitForSeconds(fall_timer); //fall_timer만큼 대기
        }
    }

    private void Update()
    {
    }

}