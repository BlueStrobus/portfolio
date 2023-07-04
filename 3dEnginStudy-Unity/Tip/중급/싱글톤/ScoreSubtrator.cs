using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSubtrator : MonoBehaviour
{   
    void Awake(){
        Debug.Log("Start Score "+ ScoreManager.GetInstance().GetScore());

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            // 0은 왼쪽, 1은 오른쪽 커서 클릭 
            ScoreManager.GetInstance().AddScore(-2);
            Debug.Log(ScoreManager.GetInstance().GetScore());
        }
    }
}
