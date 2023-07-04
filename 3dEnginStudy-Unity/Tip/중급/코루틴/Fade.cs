using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 새로만들기 > UI> 이미지
public class Fade : MonoBehaviour
{
    public Image fadeImage; // 이미지 컴파운드 가져와서 스크립트로 색 변경




    // Start is called before the first frame update
    void Start(){
        StartCoroutine("FadeIn"); // 문자로 적는건 임의적으로 멈출 수 있음
        // StartCoroutine(FadeIn); // 성능은 좋지만 나중에 임의적으로 멈출 수 없음
        
    }

    IEnumerator FadeIn(){
        // 범위는 %라서 0~1.0
        Color startColor = fadeImage.color;
        //startColor - RGB 색 지정
        for(int i = 0; i < 100; i++){
            // 지연시간 줘야함
            startColor.a -= 0.01f;
            // 게임에서 조금씩 색이 빠지면 자연스럽게 넘어가는걸로 보임
            fadeImage.color = startColor;
            yield return new WaitForSeconds(0.01f); // 0.01초 대기
            // yield 쓰고 대기시간 명시

        }
    }


}


