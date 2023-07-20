using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public Animator birdAnimator; // Animator 컴포넌트를 참조하기 위한 변수

    private void Start()
    {
        // Animator 컴포넌트 가져오기
        birdAnimator = GetComponent<Animator>();
    }

    public void FlyAway()
    {
        // "Fly"라는 이름의 애니메이션을 재생합니다.
        birdAnimator.SetTrigger("Fly");
    }
}

