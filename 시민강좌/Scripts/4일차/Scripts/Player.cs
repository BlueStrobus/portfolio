using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도

    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider; // 슬라이더 UI를 연결할 변수

    public GameObject damageEffect;
    public GameManager gameManager;

    public GameObject firePrefab;
    public GameObject shotEffect;

    public bool canShoot = true;
    public float shootDelay = 0.5f;
    float shootTimer = 0;

    public Transform firePoint;

    public GameObject healEffect;
    public Transform healpoint;

    private void Start()
    {
        currentHealth = maxHealth; // hp 정보 초기화
        UpdateHealthSlider(); //  HP 바 보이기
    }

    private void Update()
    {
        // 플레이어 이동 처리 (여기서는 X와 Z 축만 고려)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Z 축 이동 제한
        float clampedZ = Mathf.Clamp(transform.position.z, -1.9f, 1.9f);
        // X축 이동 제한
        float clampedX = Mathf.Clamp(transform.position.x, -5.0f, 0.0f);

        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        ShootControl();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // 충돌한 객체의 태그가 'Enermy'인 경우 데미지 처리
        if (other.gameObject.CompareTag("Enermy"))
        {
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
            GameObject damageEffect = Instantiate(this.damageEffect, firePoint.position, Quaternion.identity);  //피해이펙트 출력
            Destroy(damageEffect, 1.5f);    //피해이펙트 제거 예약
            TakeDamage(10); // 충돌 시 데미지 10 적용 (원하는 값을 넣어주시면 됩니다.)
        }
    }

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            gameManager.PlayerDied();
            currentHealth = 0; // 최소 체력은 0으로 제한
            Destroy(gameObject); // 데미지가 -100이 되면 객체 소멸
        }

        UpdateHealthSlider();
    }

    private void UpdateHealthSlider()
    {
        // 슬라이더 UI 업데이트 (체력 비율에 따라 값 설정)
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    void ShootControl()
    {
        if (canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootDelay && (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                GameObject shotEffectObj = Instantiate(shotEffect, firePoint.position, Quaternion.identity);
                Destroy(shotEffectObj, 0.5f);
                Instantiate(firePrefab, firePoint.position, Quaternion.identity);
                shootTimer = 0;
            }
        }
    }

    public void Heal()
    {
        GameObject healEffectObj = Instantiate(healEffect, healpoint.position, healpoint.rotation) as GameObject;
        Destroy(healEffectObj, 1.5f);
        currentHealth += (int)(maxHealth * 0.3f);
        UpdateHealthSlider();
        /*
        GameObject healEffectObj = Instantiate(healEffect, healpoint.position, Quaternion.identity);
        Destroy(healEffectObj, 1.5f);
        currentHealth += (int)(maxHealth * 0.3f);
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure currentHealth doesn't exceed maxHealth
        UpdateHealthSlider();
        */
    }
}
