using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 형변환 캐스팅
        int height = 170;
        float heightDetail = 170.3f;

        // 자동 형변환 (잃어버리는 정보가 없으면)
        heightDetail = height;

        // 직접 명시해야 하는 경우 ( 잃어버리는 정보가 있으면)
        height = (int)heightDetail;

        //조건문 if문
        bool isboy = true;
        if(isboy != true){
            Debug.Log("나는 여자다");            
        }
        else
        {
            Debug.Log("나는 남자다");            
        }        

        // ==  !=  <  >  <=  >=   '='은 부호 오른쪽


        // switch 분기문
        int year = 2017;
        switch(year){ // switch(변수){캐이스}
            case 2012:
                Debug.Log("레미제라블");
                break;
            case 2015:
                Debug.Log("러브라이브");
                break;
            case 2016:
                Debug.Log("곡성");
                break;
            case 2017:
                Debug.Log("트랜스포머5");
                break;

            default:
                Debug.Log("년도가 해당사항 없음");
                break;
        }

        // 루프문 Loop 반복문들

        //for 문
        // for(초기화; 조건; 업데이트){}
        for(int i = 0; i<10; i++){
            Debug.Log("현재 순번: " + i);            
        }
        Debug.Log("루프 끗");

        bool isShot = false;
        int index = 0;
        int luckynumber =4;

        while (isShot == false)
        {
            index +=1;
            Debug.Log("현재 시도: "+ index);
            if(index == luckynumber){
                Debug.Log("총알에 맞았다!");
            }
            else{
                Debug.Log("총알에 맞지 않았다.");
            }
            
        }

        do{
            Debug.Log("Do-While");
        }while(isShot==false);



    }
}
