using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal 
{
    public string name;
    public float weight;
    public int year;

    public void Print(){
        Debug.Log(name + "| 몸무게: " + weight + "| 나이: " + year);
    }

// prodected 접근자 - 자식이 사용 가능하지만 바깥에서 접근 불가
    protected float GetSpeed(){
        return CalcSpeed();
    }
    
    private float CalcSpeed(){
        return 100f/(weight*year);

    }

    public class Dog:Animal{ // Animal 관련한걸 다 깔아놓고 진행
        public void Hunt(){
            float speed = GetSpeed();
            Debug.Log(speed + "의 속도로 달려가서 사냥했다.");

            weight += 10f;
        }
    }

    public class Cat:Animal{
        public void Stealth(){
            Debug.Log("숨었다");
        }
    }
}
