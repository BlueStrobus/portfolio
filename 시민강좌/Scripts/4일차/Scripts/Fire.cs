using UnityEngine;

using System.Collections;

public class Fire : MonoBehaviour
{

    private float moveSpeed = 5f;
    public GameObject ParticleFXExplosionPrefab;

    //�Ѿ��� ������ �ӵ��� ����� �������ݽô�.


    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime;
        //�̵��� �Ÿ��� ������ �ݽô�.
        transform.Translate(moveX, 0, 0);
        //�̵��� �ݿ����ݽô�.

        if (transform.position.x > 12f)
        {
            Destroy(gameObject);
        }
    }

    /* // ���⸻�� EnermyMove���� ���
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {//�ε��� ��ü�� ������ �˻�
            Destroy(other.gameObject); //�ε��� ���� ����ϴ�.
            Destroy(this.gameObject); //�ڱ� �ڽ��� ����ϴ�.
            // ���� ����Ʈ �������� �����Ͽ� ������ ����
            GameObject ParticleFXExplosion = Instantiate(ParticleFXExplosionPrefab, this.transform.position, Quaternion.identity);
            // ���� ����Ʈ �������� 1.5�� �Ŀ� ����
            Destroy(ParticleFXExplosion, 1.5f);
            Debug.Log("���");
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
        Destroy(this.gameObject);// �ڱ� �ڽ��� ����ϴ�.
    }

}