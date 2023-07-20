using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�

    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider; // �����̴� UI�� ������ ����

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
        currentHealth = maxHealth; // hp ���� �ʱ�ȭ
        UpdateHealthSlider(); //  HP �� ���̱�
    }

    private void Update()
    {
        // �÷��̾� �̵� ó�� (���⼭�� X�� Z �ุ ���)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Z �� �̵� ����
        float clampedZ = Mathf.Clamp(transform.position.z, -1.9f, 1.9f);
        // X�� �̵� ����
        float clampedX = Mathf.Clamp(transform.position.x, -5.0f, 0.0f);

        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        ShootControl();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // �浹�� ��ü�� �±װ� 'Enermy'�� ��� ������ ó��
        if (other.gameObject.CompareTag("Enermy"))
        {
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
            GameObject damageEffect = Instantiate(this.damageEffect, firePoint.position, Quaternion.identity);  //��������Ʈ ���
            Destroy(damageEffect, 1.5f);    //��������Ʈ ���� ����
            TakeDamage(10); // �浹 �� ������ 10 ���� (���ϴ� ���� �־��ֽø� �˴ϴ�.)
        }
    }

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            gameManager.PlayerDied();
            currentHealth = 0; // �ּ� ü���� 0���� ����
            Destroy(gameObject); // �������� -100�� �Ǹ� ��ü �Ҹ�
        }

        UpdateHealthSlider();
    }

    private void UpdateHealthSlider()
    {
        // �����̴� UI ������Ʈ (ü�� ������ ���� �� ����)
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
