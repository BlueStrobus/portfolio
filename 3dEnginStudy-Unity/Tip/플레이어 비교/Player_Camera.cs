using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{// 플레이어 움직이기

    // 이동 속도_________________________________________
    public float walkSpeed; // 속도 5
    // private에서 SerializeField함수선언해서 인스펙션에서 속도 수정 가능하게 만듦
    //근데 왜 퍼블릭 안쓰지?
    //__________________________________________

    // 카메라________________________________________
    public float lookSensitivity;// 카메라 민감도  1(0으로 하면 안움직임)
    public float cameraRotationLimit; //카메라 각도 45
    private float currentCameraRotationX;
    public Camera theCamera;


    private Rigidbody myRigid;



    void Start()
    {
        theCamera = FindObjectOfType<Camera>();
        myRigid = GetComponent<Rigidbody>();
        // myRigid에 리지드바디 넣겠다
        
    }

    void Update()
    {
        Move();
        CameraRotation();
        CharacterRotation();
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        // Horizontal - 좌우(X)
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        // Vertical - 앞뒤(Z)
        // - 점프(Y 높이)


        //위에 변수로 이동벡터 설정
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized*walkSpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }
    private void CharacterRotation()
    { // 좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        // 오일러값을 쿼터니엄 값으로 바꿈
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        Debug.Log(myRigid.rotation);
        Debug.Log(myRigid.rotation.eulerAngles);
    }

    private void CameraRotation()
    { //상하 카메라 회전
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX; //반전시키기
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //각도 제한

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); //localEulerAngles - 오일러각으로 변환;
    }


}
