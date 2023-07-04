using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HelloUnity");
        StartCoroutine("HiCSharp");
        Debug.Log("End");
        // 문장넣기 or 함수 자체로 넣기
    }

    IEnumerator HelloUnity(){
        while(true){

            yield return new WaitForSeconds(3f);
            Debug.Log("Hello Unity");
        }
    }

    IEnumerator HiCSharp(){
        Debug.Log("Hi");
        yield return new WaitForSeconds(5f);
        Debug.Log("CSharo");
    }

}
