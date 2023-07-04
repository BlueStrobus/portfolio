using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    //public Rigidbody playerRigidbody; // 리기드바디 끌어오기
    private Rigidbody playerRigidbody; // 밖에서 수정불가
    // Start is called before the first frame update
    void Start()
    { // 리기드바디 프라이빗으로 하면 코드로 플레이어의 리기드바디 넣어줘야함
        playerRigidbody = GetComponent<Rigidbody>();
        // GetComponent는 <>를 이용해서 찾고싶은 타입을 명시하면
        //  게임 오브젝트의 모든 컴포넌트를 뒤져서 여기에 집어넣음
        //
        // <> : 집어넣는거


    }

    // 프레임당 한번 실행
    // Update is called once per frame
    void Update()
    {        
        float inputX = Input.GetAxis("Horizontal");

        // 커스터마이징
        // 발사 기능 - "Fire" - 마우스 왼쪽 버튼
        // 앉는 기능 - "Crunch" - 키보드 C
        // 점프 기능 - "Jump" - 키보드 스페이스

        // "Horizontal" -> 키보드 수평방향에 대응되는 키가 맵핑되어 있음; 키보드, 조이스틱 자동 세팅됨
        // <- ->
        // A <-                 -> D
        // -1.0  -0.5  0  +0.5  +1.0  //조이스틱 때문에 숫자로 받음; 살짝밀기 가능
        // 유니티 Edit(수정) > Project SSettings > Input 
        // > Axes > Horizontal > 네거티브버튼, 포지티브버튼에 <- ->키 들어가있음


        // 코드부분
        // if(입력("Fire"))
        //   //총알을 발사       //좌측커서 클릭 바로 들어가는게 아님
        // if(입력("Jump"))
        //   //점프를 한다

        // S v                    ^W
        // -1.0  -0.5  0  +0.5  +1.0 
        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = playerRigidbody.velocity.y;

        // 힘을 주는 것
        // playerRigidbody.AddForce(inputX*speed,0,inputZ*speed);


        // velocity : 힘 말고 속도를 주기, 백터3개 주기; 관성 없음; 낙하 이상
        Vector3 velocity = new Vector3(inputX,0,inputZ); // y축 속도를 0으로 자꾸 덮어씌워서 느리게 떨어짐

        // (inputX*speed,0*speed,inputZ*speed)
        velocity = velocity * speed;

        velocity.y = fallSpeed;

        // (inputX * speed, fallSpeed, inputZ * speed)

        playerRigidbody.velocity = velocity;
    }
}