using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;     //�����̴� �ӵ��� ������ �ݴϴ�. 

    public GameObject firePrefab; //�߻��� ź�� �����մϴ�. 
    public bool canShoot = true; //ź�� �� �� �ִ� �������� �˻��մϴ�. 
    public float shootDelay = 0.5f; //ź�� ��� �ֱ⸦ �����ݴϴ�. 
    float shootTimer = 0; //�ÁA�� �� Ÿ�̸Ӹ� ������ݴϴ�. 

    private List<GameObject> instantiatedFirePrefabs = new List<GameObject>();

    void Start()
    {

    }
    void Update()
    {
        moveControl();        //ĳ���͸� �����̴� �Լ��� �����Ӹ��� ȣ�� �մϴ�. 
        ShootControl(); // �߻縦 �����ϴ� �Լ� �Դϴ�. 

        // Check positions of instantiated firePrefabs
        for (int i = instantiatedFirePrefabs.Count - 1; i >= 0; i--)
        {
            GameObject instantiatedFire = instantiatedFirePrefabs[i];
            if (instantiatedFire.transform.position.y > 30)
            {
                Destroy(instantiatedFire);
                instantiatedFirePrefabs.RemoveAt(i);
            }
        }

    }
    void moveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //�Ʊ� ������ Axes�� ���� Ű�� ������ �Ǵ��ϰ� �ӵ��� ������ ������ ���� �̵����� �����ݴϴ�. 
        this.gameObject.transform.Translate(distanceX, 0, 0);
        //�̵��� ��ŭ ������ �̵��� �ݿ��մϴ�. 
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�. 
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�. 
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�. 
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //�ٽ� ���� ��ǥ�� ���Q�Ѵ�. 
        transform.position = worldPos; //��ǥ�� �����Ѵ�. 
    }
    void ShootControl()
    {
        if (canShoot)
        {
            if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space))
            {
                GameObject newFirePrefab = Instantiate(firePrefab, transform.position, Quaternion.identity);
                instantiatedFirePrefabs.Add(newFirePrefab);
                shootTimer = 0;
            }
            shootTimer += Time.deltaTime;
        }
    }

    public GameObject ParticleFXExplosion;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        { //�ε��� ��ü�� ������ �˻��մϴ�. 
            Destroy(other.gameObject); //�ε��� ���� ����ϴ�. 
            Destroy(this.gameObject); //�ڱ� �ښ��� ����ϴ�. 
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity);
            //���� ����Ʈ�� �����մϴ�. 
          }

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);// �ڱ� �ڽ��� ����ϴ�. 
    }

  

}