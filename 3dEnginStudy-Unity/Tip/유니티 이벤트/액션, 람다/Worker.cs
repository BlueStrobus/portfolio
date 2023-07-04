using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    delegate void Work();

    Work work;

    void MoveBricks(){
        Debug.Log("벽돌을 옮겼다");
    }

    void DigIn(){
        Debug.Log("땅을 팠다");
    }

    void Start(){
        work += MoveBricks;
        work += DigIn;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            work();
        }
    }
}
