using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public PointManiger pointManiger;
    public MonsterManager monsterManager;
    // void Start(){
    //     pointManiger.SetPoint(100);
    //     int myPoint = pointManiger.GetPoint();
    //     Debug.Log("현재 포인트: " + myPoint);

    //     pointManiger.SetPoint(-1000);
    //     myPoint = pointManiger.GetPoint();
    //     Debug.Log("현재 포인트: " + myPoint);
    //}

    
    void Start(){
        // pointManiger.point = 100;
        // Debug.Log("현재 점수" + pointManiger.point);

        // pointManiger.point = -100;
        // Debug.Log("현재 점수" + pointManiger.point);

        Debug.Log(monsterManager.count);
        //monsterManager.count = 0;


    }
}
