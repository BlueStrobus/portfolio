using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
// 이벤트는 함수들을 등록할 수 있는 명단

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent OnPlayerDead;
    // 이건 명단이고 그냥 들록만해놓고 떠남



    private void Dead(){
        // 플레이어가 죽었을 때 명단(이벤트)발동 (발동 = Invoke)
        OnPlayerDead.Invoke();

        Debug.Log("죽었다!");
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other){ // 트리거에 접촉하면
        Dead();
    }
}
