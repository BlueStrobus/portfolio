using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messanger : MonoBehaviour
{
    public delegate void Send(string reciever);

    Send onSend;

    void Start(){
        onSend += SendMail;
        onSend += SendMoney;
        // float a = 3.14f

        // 람다 함수(줄이기)
        onSend += man => Debug.Log("Assainate" + man);
        // 위랑 같은 내용
        // 바디안에 여러줄 들어갈 때는 ';'로 구분하고 {}로 묶어주기
        //onSend += (string man) => {Debug.Log("Assainate " + man); Debug.Log("Hide Body");};



    }



    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            onSend("Jemin");
        }
    }

    void SendMail(string reciever){
        Debug.Log("Mail sent to: " + reciever);
    }

    void SendMoney(string reciever){
        Debug.Log("Money sent to: " + reciever);
    }
}
