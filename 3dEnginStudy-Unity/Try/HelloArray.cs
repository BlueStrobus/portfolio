using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloArray : MonoBehaviour  //배열; 
{
    // Start is called before the first frame update
    void Start()
    {
        int score1 = 90;
        int score2 = 45;
        int score3 = 60;

        Debug.Log(score1);
        Debug.Log(score2);
        Debug.Log(score3);
        
        //여러개의 값을 하나의 변수로 다루게 해준다.
        int[] scores = new int[10];// 방이 0~9까지 10개
        scores[0] = 90;
        scores[1] = 45;
        scores[2] = 60;
        scores[3] = 70;
        scores[4] = 56;
        scores[5] = 80;
        scores[6] = 90;
        scores[7] = 100;
        scores[8] = 45;
        scores[9] = 14;

        //배열은 for문 쓰기 좋음

        for(int i = 0; i <10; i++){
            Debug.Log( i + "번째 학생의 점수" + scores[i]);
        }


        //같은 배열 이름으로 자리 늘리기(기존 정보 사라짐)
        scores = new int[30];
        for(int i = 0; i <10; i++){
            Debug.Log( i + "번째 학생의 점수" + scores[i]);
        }


        
    }

}
