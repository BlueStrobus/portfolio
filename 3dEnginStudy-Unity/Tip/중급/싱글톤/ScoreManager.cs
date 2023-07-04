using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 이게 싱글톤(모두 접근)
    public static ScoreManager GetInstance(){
        if(instance ==null){
            instance = FindObjectOfType<ScoreManager>();
            
            //나 여기이해못함
            if(instance == null){
                GameObject containaer = new GameObject("Score Manager");
                // 빈 프로젝트 "ScoreManager" 만들기

                instance = containaer.AddComponent<ScoreManager>();
                //AddComponent<타입> - 컴파운드를 새로 만들어 붙임 




            }
        }
        return instance;
    }

    private static ScoreManager instance;

    private int score =0;

    // void Awake(){ // Awake는 Start보다 빠름; 한번 실행 
    //     instance = this;
    // }

    void Start(){ // 여기도 모르겠음, 빈 게임오브젝트가 여러개면 하나만 남기고 삭제한데
        if(instance != null){
            if(instance != this){
                Destroy(gameObject);
            }

        }
    }

    public int GetScore(){
        return score;
    }

    public void AddScore(int newScore){
        score +=newScore;
    }


}
