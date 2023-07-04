using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloFunction : MonoBehaviour
{
    //변수명은 함수 내에 중복되지 않게 사용, 
    // Start is called before the first frame update
    void Start()
    {
        float sizeOfCircle = 30f;
        float radius = GetRadius(sizeOfCircle);
        Debug.Log("원의 사이즈 : " + sizeOfCircle + ", 원의 반지름 : " + radius);
        
    }

    /*Scope : 중괄호가 시작~끝 부분을 스코프라 함;
    밖에서 안이 안보임 = 변수명이 다른 스코프의 변수랑 겹쳐도 에러X, return사용해야 다른데서 사용가능


    */


    float GetRadius(float size){
        float pi = 3.14f;
        float tmp = size/pi;
        float radius = Mathf.Sqrt(tmp);
        // Mathf : 수학 관련 함수
        // Mathf.Sqrt() : 지정된 숫자의 제곱근을 반환합니다.
        return radius;
        // return 안쓰면 함수 밖에서 접근 불가.

    }
}
