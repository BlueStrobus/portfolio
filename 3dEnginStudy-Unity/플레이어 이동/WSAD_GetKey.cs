using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 프레임당 한번 실행
    // Update is called once per frame
    void Update()
    {
        //유저입력
        if(Input.GetKey(KeyCode.W)){
            playerRigidbody.AddForce(0,0,speed);
        }
        if(Input.GetKey(KeyCode.S)){
            playerRigidbody.AddForce(0,0,-speed);
        }
        if(Input.GetKey(KeyCode.D)){
            playerRigidbody.AddForce(speed,0,0);
        }
        if(Input.GetKey(KeyCode.A)){
            playerRigidbody.AddForce(-speed,0,0);
        }
        
    }
}


