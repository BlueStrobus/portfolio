using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI쓰려면 꼭 필요

public class GameDirectorA : MonoBehaviour
{
    GameObject hpGauge;
    

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge"); //this 없어도 됨
    }

    public void DecreaseHp(){
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
        // if(float hpGauge == 0.0f){
        //     Debug.Log("게임 끝!");
        // }
    }

}