using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;     //움직이는 속도를 정의해 줍니다. 

    public GameObject firePrefab; //발사할 탄을 저장합니다. 
    public bool canShoot = true; //탄을 쏠 수 있는 상태인지 검사합니다. 
    public float shootDelay = 0.5f; //탄을 쏘는 주기를 정해줍니다. 
    float shootTimer = 0; //시갂을 잴 타이머를 만들어줍니다. 

    private List<GameObject> instantiatedFirePrefabs = new List<GameObject>();

    void Start()
    {

    }
    void Update()
    {
        moveControl();        //캐릭터를 움직이는 함수를 프레임마다 호출 합니다. 
        ShootControl(); // 발사를 관리하는 함수 입니다. 

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
        //아까 지정한 Axes를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정해줍니다. 
        this.gameObject.transform.Translate(distanceX, 0, 0);
        //이동량 만큼 실제로 이동을 반영합니다. 
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다. 
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다. 
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다. 
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변홖한다. 
        transform.position = worldPos; //좌표를 적용한다. 
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
        { //부딪힌 객체가 적인지 검사합니다. 
            Destroy(other.gameObject); //부딪힌 적을 지웁니다. 
            Destroy(this.gameObject); //자기 자싞을 지웁니다. 
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity);
            //폭발 이펙트를 생성합니다. 
          }

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);// 자기 자신을 지웁니다. 
    }

  

}