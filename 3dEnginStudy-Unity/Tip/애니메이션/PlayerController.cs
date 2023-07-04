using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public Animator anim;    
    
    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("jump");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            anim.SetTrigger("Jump");
        }

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        anim.SetFloat("Speed", verticalInput);
        anim.SetFloat("Horizontal", horizontalInput);
    }

    void OnAnimatorIK(){
        // OnAnimatorIK 함수 - 에니메이터가 부착이 되있는 게임 오브젝트에만 동작을 함
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.5f); //1.0f는 100% 의미; 낮을수록 동작이 자연스럽게 이어짐
        // SteIK ~ Weight 함수 -IK에 우선순위를 결정해줌
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.5f); //1.0f는 100% 의미
        
        //손 타겟에 고정
        anim.SetIKPosition(AvatarIKGoal.LeftHand,target.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand,target.rotation);

        //시선처리
        anim.SetLookAtWeight(1.0f);
        anim.SetLookAtPosition(target.position);
    }
}
