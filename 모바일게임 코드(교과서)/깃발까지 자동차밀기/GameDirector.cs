using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Textmeshpro를 사용하는데 필요함

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;

    // Start is called before the first frame update
    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        if(length > 0.5){
            this.distance.GetComponent<TextMeshProUGUI>().text = "남은 거리: " + length.ToString("F2") + "m";
        }
        else if(length <= 0.5 && length >= -0.5){
            this.distance.GetComponent<TextMeshProUGUI>().text = "이겼다!";
        }
        else{
            this.distance.GetComponent<TextMeshProUGUI>().text = "게임 끝";
        }
    }
}
