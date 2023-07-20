using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = true;
    public List<GameObject> enemyPrefabs; // 적 프리팹들의 리스트
    public List<GameObject> spawnedEnemies; // 생성된 적 오브젝트들을 저장할 리스트
    // public float initialSpawnRateMin = 3f; // 초기 적의 출현 주기 최소값
    // public float initialSpawnRateMax = 6f; // 초기 적의 출현 주기 최대값
    // public float minSpawnRate = 1f; // 최소 적의 출현 주기
    // public float spawnRateDecreasePerLevel = 0.5f; // 레벨당 적의 출현 주기 감소량
    // public float enemySpeedIncreasePerLevel = 0.01f; // 레벨당 적의 속도 증가량
    // public float enemySpawnRateDecreasePerLevel = 0.05f; // 레벨당 적의 출현 주기 감소량
    public float frequency;
    void SpawnEnemy()
    {
        if (enableSpawn && enemyPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count); // 리스트에서 무작위로 적 프리팹을 선택합니다.
            Vector3 spawnPosition = new Vector3(8.5f, 0.56f, Random.Range(-1.5f, 1.5f));
            Quaternion spawnRotation = Quaternion.Euler(0, 90, 0); // y축으로 90도 회전한 Quaternion

            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], spawnPosition, spawnRotation);
            spawnedEnemies.Add(enemy); // 생성된 적을 리스트에 추가합니다.

            /*
            // GameManager 스크립트에서 레벨에 따라 적의 속도와 출현 빈도를 조절합니다.
            float levelMultiplier = 1 + (GameManager.instance.level * enemySpeedIncreasePerLevel);
            enemy.GetComponent<EnermyMove>().moveSpeed *= levelMultiplier;

            float spawnRateMultiplier = 1 - (GameManager.instance.level * enemySpawnRateDecreasePerLevel);
            float randomSpawnRate = Random.Range(initialSpawnRateMin, initialSpawnRateMax);
            float finalSpawnRate = Mathf.Max(randomSpawnRate - spawnRateDecreasePerLevel * GameManager.instance.level, minSpawnRate);
            //Invoke("SpawnEnemy", finalSpawnRate * spawnRateMultiplier); // 다음 적을 생성합니다.

            */
        }
    }

    void Start()
    {
        spawnedEnemies = new List<GameObject>();
        InvokeRepeating("SpawnEnemy", 1, frequency); // 1초 후부터, 4초마다 SpawnEnemy 함수를 반복해서 실행합니다.
    }
}
