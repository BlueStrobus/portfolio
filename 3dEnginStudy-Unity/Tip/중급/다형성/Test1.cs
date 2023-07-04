using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Cat nate = new Cat(); // 고양이 객체
        nate.name = "Nate";
        nate.weight = 1.5f;
        nate.year = 3;

        Dog jack = new Dog(); // 강아지 객체
        jack.name = "Jack";
        jack.weight = 5f;
        jack.year = 2;

        // nate.Stealth();
        // nate.Print();  // 부모인 Animal로부터 물려받은 기능 

        // jack.Hunt();
        // jack.Print();  // 부모인 Animal로부터 물려받은 기능

        // Animal someAnimal = jack;
        // someAnimal.Print(); 
        // Dog myDog = (Dog)someAnimal;
        // myDog.Hunt();

        Animal[] animals = new Animal[2];

        animals[0] = nate;
        animals[1] = jack;

        for(int i 0; i<animals.Length; i++){
            animals[i].Print();
        }


    }
}