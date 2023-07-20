using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ���̵��Ϸ��� �־����

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
            // ��ũ�ѹ� �̵� ������(0~1���� ����)
        {
            // SceneManager.LoadScene("Main"); //  �� �̸�
            SceneManager.LoadScene(1); // ���弼���ǳѹ�
        }
        else
        {
            loadingTime += Time.deltaTime;
            loadingBar.value = loadingTime / delayTime; 
            // delaytime��ŭ �ε��ϱ�
        }
    }
}
