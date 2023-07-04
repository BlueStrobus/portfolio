// 플레이어 죽으면 5초뒤 재시작
 // 신 재시작해야함
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public void OnPlayerDead(){
        Invoke("Restart",5f); // Invoke("할일", 지연시간) -  지연시간만큼 시간이 흐른 뒤 실행
    }
    private void Restart(){
        SceneManager.LoadScene(0);
    }

}
