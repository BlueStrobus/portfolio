using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloMath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 5;
        int b = 7;
        int sum = a + b;
        Debug.Log(sum);
        sum = a-b;
        Debug.Log(sum);       

        int i = 5;
        Debug.Log(i++); 
        Debug.Log(i);
        Debug.Log(++i);  
    }

}
