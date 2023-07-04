using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<playerRigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = inputX.GetAxis("Horizontal");

        float inputZ = inputX.GetAxis("Vertical");

        float fallSpeed = playerRigidbody.velocity.y;

        Vertor3 velocity = new Vertor3(inputX,0,inputZ);
        
        velocity = velocity * speed;

        PlayerRigidbody.velocity = velocity;






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
