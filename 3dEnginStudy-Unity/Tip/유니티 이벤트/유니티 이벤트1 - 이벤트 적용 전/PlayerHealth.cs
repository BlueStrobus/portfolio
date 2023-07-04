using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public UIManager uiManager;

    public AchivementSystem achivementSystem;

    public GameManager gameManager;



    private void Dead(){

        uiManager.OnPlayerDead();
        achivementSystem.UnLockAchivement("뉴턴의 법칙");
        gameManager.OnPlayerDead();


        Debug.Log("죽었다!");
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other){ // 트리거에 접촉하면
        Dead();
    }
}
