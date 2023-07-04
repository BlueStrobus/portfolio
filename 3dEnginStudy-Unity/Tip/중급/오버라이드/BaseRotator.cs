using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotator : MonoBehaviour
{
    public float speed = 60f;

    void Update(){
        Rotate();
    }


    protected virtual void Rotate(){
        transform.Rotate(speed*Time.deltaTime,0,0);
    }
}
