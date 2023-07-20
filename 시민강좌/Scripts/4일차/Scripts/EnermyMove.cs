using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    public float moveSpeed = 0.8f;
    public GameObject ParticleFXExplosion;

    void Update()
    {
        float movez = - moveSpeed * Time.deltaTime;
        transform.Translate(0, 0,movez);


        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            //ScoreManager.instance.ComputeScore(1);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(ParticleFXExplosion, transform.position, Quaternion.identity);


            GameManager.instance.score += 10;
            int randomCoin = Random.Range(0, 10);
            GameManager.instance.coin += randomCoin;
            Debug.Log(randomCoin);
            GameManager.instance.UpdateUI();


        }
        else if (other.gameObject.tag.Equals("Plyter"))
        {
            //ScoreManager.instance.ComputeScore(1);
            Destroy(this.gameObject);
            Instantiate(ParticleFXExplosion, transform.position, Quaternion.identity);


        }
    }


    void OnBecameInvisible() //ȭ�� ������ ���� ������ �ʰ� �Ǹ� ȣ���� �ȴ�.
    {
        Destroy(this.gameObject); //��ü�� �����Ѵ�.
    }
}
