using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotator : MonoBehaviour
{
    private enum RotateState
    {
        Idle, Vertical, Horizontal, Ready
    }

    private RotateState state = RotateState.Idle; // 1. 처음 시작은 Idle로
    public float verticalRotateSpeed = 360f; // 2. 수직방향 회전값 초기값 360도
    public float horizontalRotateSpeed = 360f; // 3. 수직방향 회전값 초기값 360도

    void Update()
    {
        if (state == RotateState.Idle)
        {
            if (Input.GetButtonDown("Fire1")) // 누르는 순간
            {
                state = RotateState.Horizontal; //  Horizontal 상태로 바꾸기
            }
        }
        else if (state == RotateState.Horizontal)
        {
            if (Input.GetButton("Fire1")) // 누르는 동안
            {
                transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0));// 수평 방향으로 `회전시키기`
            }
            else if (Input.GetButtonUp("Fire1")) // 떼는 순간
            {
                state = RotateState.Vertical; // Vertical 상태로 바꾸기
            }
        }
        else if (state == RotateState.Vertical)
        {
            if (Input.GetButton("Fire1")) // 누르는 동안
            {
                transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0));// 수직 방향으로 `회전시키기`. 뒤로 넘어지는 것처럼 회전 (마이너스)
            }
            else if (Input.GetButtonUp("Fire1")) // 떼는 순간
            {
                state = RotateState.Ready; // Ready 상태로 바꾸기
            }
        }
    }
}
