using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 게임 끝나면 플레이어 못움직이게
    public GaimeManiger gaimeManiger;
    public float speed = 10f;
    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //게임 종료 후 플레이어 못움짓임
        if (gaimeManiger.isGaimeOver == true){
            return;
        }


        float inputX = Input.GetAxis("Horizontal");

        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = playerRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX,0,inputZ);
        
        velocity = velocity * speed;

        playerRigidbody.velocity = velocity;






        // if(Input.GetKey(KeyCode.W)){
        //     playerRigidbody.AddForce(0,0,speed);
        // }
        // if(Input.GetKey(KeyCode.S)){
        //     playerRigidbody.AddForce(0,0,-speed);
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     playerRigidbody.AddForce(speed,0,0);
        // }
        // if(Input.GetKey(KeyCode.A)){
        //     playerRigidbody.AddForce(-speed,0,0);
        // }
    }
}
