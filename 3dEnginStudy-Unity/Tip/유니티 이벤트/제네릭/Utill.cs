using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        Container<string> container = new Container<string>();
        // 제네릭 사용할 때 는 입력할 때 타입 써줘야함 (리스트 처럼)
        container.messages = new string[3];

        container.messages[0] = "Hello";
        container.messages[1] = "World";
        container.messages[2] = "Generic";

        for(int i = 0; i < container.messages.Length; i++){
            Debug.Log(container.messages[i]);
        }

        Container<int> container2 = new Container<int>();
        container2.messages = new int[3];

        container2.messages[0] = 0;
        container2.messages[1] = 1;
        container2.messages[2] = 100;

        for(int i = 0; i < container.messages.Length; i++){
            Debug.Log(container2.messages[i]);
        }
    }

    // // 제네릭은 <>안에 가상의 타입을 만듦 -> 타입 상관없이 사용 가능
    // public void Print<T>(T inputMessage){
    //     Debug.Log(inputMessage);

    // }

    public class Container<T>{
        public T[] messages;
    }


    public void Print(string inputMessage){
        Debug.Log(inputMessage);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
