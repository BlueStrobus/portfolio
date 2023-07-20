using UnityEngine;

using System.Collections;

public class Fire : MonoBehaviour
{

    private float moveSpeed = 5f;
    public GameObject ParticleFXExplosionPrefab;

    //총알이 움직일 속도를 상수로 지정해줍시다.


    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime;
        //이동할 거리를 지정해 줍시다.
        transform.Translate(moveX, 0, 0);
        //이동을 반영해줍시다.

        if (transform.position.x > 12f)
        {
            Destroy(gameObject);
        }
    }

    /* // 여기말고 EnermyMove에서 사용
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {//부딪힌 객체가 적인지 검사
            Destroy(other.gameObject); //부딪힌 적을 지웁니다.
            Destroy(this.gameObject); //자기 자신을 지웁니다.
            // 폭발 이펙트 프리팹을 생성하여 변수에 저장
            GameObject ParticleFXExplosion = Instantiate(ParticleFXExplosionPrefab, this.transform.position, Quaternion.identity);
            // 폭발 이펙트 프리팹을 1.5초 후에 제거
            Destroy(ParticleFXExplosion, 1.5f);
            Debug.Log("사용");
            GameManager.instance.score += 10;
            int randomCoin = Random.Range(0, 10);
            GameManager.instance.coin += randomCoin;
            Debug.Log(randomCoin);
            GameManager.instance.UpdateUI();


        }
    }
    */
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);// 자기 자신을 지웁니다.
    }

}