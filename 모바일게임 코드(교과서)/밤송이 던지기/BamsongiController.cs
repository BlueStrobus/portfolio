using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public void Shoot(Vector3 dir){
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void OnCollisionEnter(Collision other){  // OnCOllisionEnter - 충돌 감지
        GetComponent<Rigidbody>().isKinematic = true;
        // 관역에 부딪히면 멈추기 
        GetComponent<ParticleSystem>().Play();
        // 충돌 감지
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        // Shoot(new Vector3(0, 200, 2000));
    }

    // void Update(){
    //     if(transform.position.z > 4.5f){
    //         Destroy(gameObject);
    //     }
    // }

}
