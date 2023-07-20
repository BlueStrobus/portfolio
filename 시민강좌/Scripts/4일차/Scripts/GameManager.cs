using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    // ������ ȣ�� ���ص� �ٸ� ��ũ��Ʈ���� ���� �� �ֵ���
    public GameObject pauseUI;
    public Slider progressSlider;
    public float distance, speed;
    public Image win;
    public GameObject die;
    public int score, coin;
    public TextMeshProUGUI scoreText, coinText;
    public int level; // ������ ������ ����
    public GameObject medal1, medal2, medal3;

    public float enemySpeedIncreasePerLevel = 0.2f; // ������ ���� �ӵ� ������
    public float enemySpawnRateDecreasePerLevel = 0.1f; // ������ ���� ���� �� ���ҷ�



    private void Awake()
    {// ������ ȣ�� ���ص� �ٸ� ��ũ��Ʈ���� ���� �� �ֵ���
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        win.gameObject.SetActive(false); // �̹����� ��Ȱ��ȭ
        die.gameObject.SetActive(false);
        medal1.gameObject.SetActive(false);
        medal2.gameObject.SetActive(false);
        medal3.gameObject.SetActive(false);
        distance = 0;
        progressSlider.value = 0;
        // coin = 0;
        // score = 0;
        level = 0; // �ʱ� ������ 1�� ����
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed;
        progressSlider.value = distance;

        // �Ÿ��� 1 �̻��̸� �¸� �̹��� Ȱ��ȭ
        if (distance >= 1)
        {
            win.gameObject.SetActive(true);
            Time.timeScale = 0; // �Ͻ�����
        }

        // ���ھ 100 �̻��̸� ������ 1 �ø���
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

    // public void OnClick��ư�̸�(); �� ����...
    public void OnPauseButton()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0; // �Ͻ�����
    }
    public void OnContinueButton()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }    
    public void PlayerDied()
    {
        die.gameObject.SetActive(true);
        Time.timeScale = 0; // �Ͻ�����
    }

    public void UpdateUI()
    {
        scoreText.text = score.ToString(); // int -> string
        coinText.text = coin.ToString();
    }
    
    
}
