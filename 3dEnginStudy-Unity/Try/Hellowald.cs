using System.Collections; //using은 import처럼 미리 가져와 사용함
using System.Collections.Generic;
using UnityEngine;

public class Hellowald : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()// Start에서 모든 코드가 먼저 시작
    {
        //콘솔출력
        Debug.Log("안녕");

        //숫자형 변수

        // int 정수
        int age = 23;
        int money = 1000000;

        Debug.Log(age);
        Debug.Log(money);

        // flot 실수' 32bit; 소숫점아래 7자리 까지만 정확; 값 끝에 'f' 붙이기
        float height = 199.1234567f;

        // double : flote의 두배 메모리 사용(64bit); 소숫점 아래 15자리까지 정확
        double pi = 3.14159265359;

        //참, 거짓
        bool isBoy = false;
        bool isGal = true;

        // char : 한 문자
        char grade = 'A';

        //string은 문장
        string movieTitle = "러브라이브!";
        Debug.Log("내 나이는!: " + age); // +로 잊기
        Debug.Log("내가 가진 돈은!: " + money);
        Debug.Log("내 키는!: " + height);
        Debug.Log("원주율은!: " + pi);
        Debug.Log("내 성적은!: " + grade);
        Debug.Log("명작 영화!: " + movieTitle);
        Debug.Log("나는 여자인가?" + isGal);
        
        //var : 할당하는 값을 기준으로 타입을 결정
        var myName = "I_Yewon";
        // string myName  = "I_Yewon";
        var myAge = 23;
        // int myAge = 23;
        Debug.Log("지구인 이름은!: " + myName);
        Debug.Log("지구인 나이는!: " + myAge);







    }

}
