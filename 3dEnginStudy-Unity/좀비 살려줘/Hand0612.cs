using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand0612 : MonoBehaviour
{
    public string handName; 
    public float range; // 공격 범위
    public int damage; // 공격력
    public float workSpeed; // 작업 속도
    public float attakDelay; // 공격 딜레이
    public float attakDelayA; // 공격 활성화 시점
    public float attakDelayB; // 공격 비활성화 시점

    public Animator anim; // 애니메이션
}
