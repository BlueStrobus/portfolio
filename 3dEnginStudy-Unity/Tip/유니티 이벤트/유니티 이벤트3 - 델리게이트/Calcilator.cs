using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcilator : MonoBehaviour
{   // 델리게이트 
    delegate float Calculate(float a, float b); //타입

    Calculate onCalculate;

    void Start(){
        onCalculate = Sum;
        onCalculate += Subtract;
        onCalculate += Multiply;
    }



    public float Sum(float a, float b){
        Debug.Log(a + b);
        return a + b;
    }
    public float Subtract(float a, float b){
        Debug.Log(a - b);
        return a - b;
    }
    public float Multiply(float a, float b){
        Debug.Log(a * b);
        return a * b;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){// 누를 떄 마다 실행
            //계산

            //onCalculate(1,10); // Sum 
            // 여러개 하면 마지막꺼만 가져옴 왜???
            Debug.Log("결과값" + onCalculate(1,10));
            
        }

    }


}
