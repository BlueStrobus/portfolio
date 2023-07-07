using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;    // 화살 프리팹을 저장하는 변수
    public GameObject redArrowPrefab; // 빨간 화살 프리팹을 저장하는 변수
    float span = 0.1f;                // 화살 생성 주기
    float delta = 0;                  // 시간 측정 변수
    float span1 = 1f;                 // 빨간 화살 생성 주기
    float delta1 = 0;                 // 빨간 화살 시간 측정 변수
    float deltaGravity = 0;           // 중력 조절 시간 측정 변수
    float gravityScale = 1;           // 중력 크기 조절 변수
    int arrowCount = 0;               // 생성된 화살 개수

    void Update()
    {
        this.delta += Time.deltaTime;  // 경과한 시간을 delta에 더함
        deltaGravity += Time.deltaTime; // 경과한 시간을 deltaGravity에 더함

        // 중력 조절 시간이 5초 이상 경과한 경우
        if (deltaGravity > 5)
        {
            deltaGravity = 0;   // 중력 조절 시간 초기화
            gravityScale = 3;    // 중력 크기를 3으로 조절
        }

        // 화살 생성 주기마다 실행
        if (this.delta > this.span)
        {
            this.delta = 0;    // 시간 초기화
            GameObject go = Instantiate(arrowPrefab);  // 화살 프리팹을 복제하여 게임 오브젝트 생성
            int px = Random.Range(-6, 7);  // -6부터 6 사이의 랜덤한 값을 가로 좌표로 설정
            go.transform.position = new Vector3(px, 7, 0);   // 생성된 게임 오브젝트의 위치 설정
            go.GetComponent<Rigidbody2D>().gravityScale = this.gravityScale;  // 생성된 화살의 중력 크기 조절
            arrowCount++;  // 생성된 화살 개수 증가

            if (arrowCount >= 10)
            {
                arrowCount = 0;  // 화살 개수 초기화
                // 빨간 화살 생성
                GameObject redGo = Instantiate(redArrowPrefab);  // 빨간 화살 프리팹을 복제하여 게임 오브젝트 생성
                int redPx = Random.Range(-6, 7);  // -6부터 6 사이의 랜덤한 값을 가로 좌표로 설정
                redGo.transform.position = new Vector3(redPx, 7, 0);  // 생성된 게임 오브젝트의 위치 설정
                redGo.GetComponent<Rigidbody2D>().gravityScale = this.gravityScale;  // 생성된 빨간 화살의 중력 크기 조절
            }
        }
    }
}
