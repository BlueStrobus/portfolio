using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // 왼쪽 화살표가 눌렸거나 눌린 상태인 경우
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0); // 왼쪽으로 이동
        }

        // 오른쪽 화살표가 눌렸거나 눌린 상태인 경우
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0); // 오른쪽으로 이동
        }
    }
}
