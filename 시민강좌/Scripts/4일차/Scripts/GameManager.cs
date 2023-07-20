using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    // 일일이 호출 안해도 다른 스크립트에서 읽을 수 있도록
    public GameObject pauseUI;
    public Slider progressSlider;
    public float distance, speed;
    public Image win;
    public GameObject die;
    public int score, coin;
    public TextMeshProUGUI scoreText, coinText;
    public int level; // 레벨을 저장할 변수
    public GameObject medal1, medal2, medal3;

    public float enemySpeedIncreasePerLevel = 0.2f; // 레벨당 적의 속도 증가량
    public float enemySpawnRateDecreasePerLevel = 0.1f; // 레벨당 적의 출현 빈도 감소량



    private void Awake()
    {// 일일이 호출 안해도 다른 스크립트에서 읽을 수 있도록
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        win.gameObject.SetActive(false); // 이미지를 비활성화
        die.gameObject.SetActive(false);
        medal1.gameObject.SetActive(false);
        medal2.gameObject.SetActive(false);
        medal3.gameObject.SetActive(false);
        distance = 0;
        progressSlider.value = 0;
        // coin = 0;
        // score = 0;
        level = 0; // 초기 레벨을 1로 설정
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed;
        progressSlider.value = distance;

        // 거리가 1 이상이면 승리 이미지 활성화
        if (distance >= 1)
        {
            win.gameObject.SetActive(true);
            Time.timeScale = 0; // 일시정지
        }

        // 스코어가 100 이상이면 레벨을 1 올리기
        if (score >= 100 && score <200)
        {
            level++;
            medal1.gameObject.SetActive(true);
            score = 0;
            MoveScene(5);
        }
        if (score >= 200 && score < 300)
        {
            level++;
            medal2.gameObject.SetActive(true);

            score = 0;
            MoveScene(6);
        }
        if (score >= 300 )
        {
            level++;
            medal3.gameObject.SetActive(true);
            score = 0;
            MoveScene(7);
        }
    }

    public void MoveScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    // public void OnClick버튼이름(); 도 가능...
    public void OnPauseButton()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0; // 일시정지
    }
    public void OnContinueButton()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }    
    public void PlayerDied()
    {
        die.gameObject.SetActive(true);
        Time.timeScale = 0; // 일시정지
    }

    public void UpdateUI()
    {
        scoreText.text = score.ToString(); // int -> string
        coinText.text = coin.ToString();
    }
    
    
}
