using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal jack = new Animal();
        jack.name = "JACK";
        jack.sound = "Bark";
        jack.weight = 4.5f;

        Animal nate = new Animal();
        nate.name = "NATE";
        nate.sound = "Nyaa";
        nate.weight = 1.2f;

        Animal annie = new Animal();
        annie.name = "ANNIE";
        annie.sound = "Wee";
        annie.weight = 0.8f; 

        nate = jack;
        nate.name = "JIMMY";
        // 잭과 내이트를 동일하게 만들어서
        // 네이트 정보를 변경하면 잭의 정보도 변함
        // = call by Reference

        Debug.Log(annie.sound);
        Debug.Log(nate.name);
        Debug.Log(jack.name);
        Debug.Log(nate.sound);


    }

   

public class Animal{
    public string name;
    //다른 {}안에서도 읽을 수 있으려면 public을 꼭 붙여야함
    public string sound;
    public float weight;
}

}
