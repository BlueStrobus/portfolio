using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = true;
    public List<GameObject> enemyPrefabs; // �� �����յ��� ����Ʈ
    public List<GameObject> spawnedEnemies; // ������ �� ������Ʈ���� ������ ����Ʈ
    // public float initialSpawnRateMin = 3f; // �ʱ� ���� ���� �ֱ� �ּҰ�
    // public float initialSpawnRateMax = 6f; // �ʱ� ���� ���� �ֱ� �ִ밪
    // public float minSpawnRate = 1f; // �ּ� ���� ���� �ֱ�
    // public float spawnRateDecreasePerLevel = 0.5f; // ������ ���� ���� �ֱ� ���ҷ�
    // public float enemySpeedIncreasePerLevel = 0.01f; // ������ ���� �ӵ� ������
    // public float enemySpawnRateDecreasePerLevel = 0.05f; // ������ ���� ���� �ֱ� ���ҷ�
    public float frequency;
    void SpawnEnemy()
    {
        if (enableSpawn && enemyPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count); // ����Ʈ���� �������� �� �������� �����մϴ�.
            Vector3 spawnPosition = new Vector3(8.5f, 0.56f, Random.Range(-1.5f, 1.5f));
            Quaternion spawnRotation = Quaternion.Euler(0, 90, 0); // y������ 90�� ȸ���� Quaternion

            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], spawnPosition, spawnRotation);
            spawnedEnemies.Add(enemy); // ������ ���� ����Ʈ�� �߰��մϴ�.

            /*
            // GameManager ��ũ��Ʈ���� ������ ���� ���� �ӵ��� ���� �󵵸� �����մϴ�.
            float levelMultiplier = 1 + (GameManager.instance.level * enemySpeedIncreasePerLevel);
            enemy.GetComponent<EnermyMove>().moveSpeed *= levelMultiplier;

            float spawnRateMultiplier = 1 - (GameManager.instance.level * enemySpawnRateDecreasePerLevel);
            float randomSpawnRate = Random.Range(initialSpawnRateMin, initialSpawnRateMax);
            float finalSpawnRate = Mathf.Max(randomSpawnRate - spawnRateDecreasePerLevel * GameManager.instance.level, minSpawnRate);
            //Invoke("SpawnEnemy", finalSpawnRate * spawnRateMultiplier); // ���� ���� �����մϴ�.

            */
        }
    }

    void Start()
    {
        spawnedEnemies = new List<GameObject>();
        InvokeRepeating("SpawnEnemy", 1, frequency); // 1�� �ĺ���, 4�ʸ��� SpawnEnemy �Լ��� �ݺ��ؼ� �����մϴ�.
    }
}
