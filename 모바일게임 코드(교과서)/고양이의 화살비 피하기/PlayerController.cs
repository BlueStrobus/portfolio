using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public void LButtonDown(){
        transform.Translate(-3,0,0);
    }
    
    public void RButtonDown(){
        transform.Translate(3,0,0);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }


    // // Update is called once per frame
    // void Update()
    // {
    //     // 왼쪽 화살표가 눌렸을 때
    //     if (Input.GetKeyDown(KeyCode.LeftArrow)){
    //         transform.Translate(-3,0,0); // 왼쪽으로 '3' 움직임
    //     }
    //     else if (Input.GetKeyDown(KeyCode.RightArrow)){
    //         transform.Translate(3,0,0); // 오른쪽으로 '3' 움직임
    //     }
    // }
}
