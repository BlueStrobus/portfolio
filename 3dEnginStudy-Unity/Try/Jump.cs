using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.AddForce(0,500,0);
        // myRigidbody에 큐브의 Rigidbody 끌어다 놓고 재생
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
