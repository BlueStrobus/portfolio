using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 씬이동하려면 있어야함

public class Intro : MonoBehaviour
{
    private float loadingTime;
    public Slider loadingBar;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        loadingBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (loadingBar.value >= 1)
            // 스크롤바 이동 끝나면(0~1까지 있음)
        {
            // SceneManager.LoadScene("Main"); //  씬 이름
            SceneManager.LoadScene(1); // 빌드세팅의넘버
        }
        else
        {
            loadingTime += Time.deltaTime;
            loadingBar.value = loadingTime / delayTime; 
            // delaytime만큼 로딩하기
        }
    }
}
