using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    void Awake(){
        Debug.Log("Start Score "+ ScoreManager.GetInstance().GetScore());

    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            // 마우스 클릭하면 점수 올라감 
            ScoreManager.GetInstance().AddScore(5);
            Debug.Log(ScoreManager.GetInstance().GetScore());
        }        
    }
}
