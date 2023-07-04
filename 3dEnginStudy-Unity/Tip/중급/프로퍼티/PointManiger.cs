using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManiger : MonoBehaviour
{ // 외부에서 포인트조작 어렵게 만들기, 0~ 일정값 이내 유지
    // public int point = 0;
    // public void SetPoint(int newPoint){
    //     if(newPoint <0){
    //         point = 0;
    //     }
    //     else if(newPoint > 10000)
    //     {
    //         point = 10000;
    //     }else{
    //         point = newPoint;
    //     }
    // }

    // public int GetPoint(){
    //     Debug.Log(point);
    //     return point;
    // }


    // point 함수를 사용하면 get, set을 사용함 (밖에선 변수처럼 사용하면 됨)
    // int a = point; GET
    // point = 100; SET
    public int point{
        get{
            Debug.Log(m_point);
            return m_point;

        }
        set{
            if(value < 0){
                m_point = 0;                
            }
            else{
                m_point = value;
            }

        }
    }


    private int m_point = 0;
}
