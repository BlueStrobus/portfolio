using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{// 플레이어 움직이기

    // 이동 속도_________________________________________
    public float walkSpeed; // 걷기 속도 5
    public float runSpeed; // 달리기 속도
    private float applySpeed; // 이동속도 대입
    public float croechSpeed;
    
    //__________________________________________
    // 점프_________________________
    public float jumpForce; // 숫자기입
    //_______________________________________

    // 상태변수_________________________________________
    private bool isRun = false;
    private bool isCrouch = false;
    private bool isGround = true;

    //_________________________________________________


    // 앉을 때 얼마나 앉는가___________________
    public float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;
    //________________________________________




    // 땅 착지 여부______________________
    private CapsuleCollider capsuleCollider;
    // _________________________________________



    // 카메라________________________________________
    public float lookSensitivity;// 카메라 민감도  1(0으로 하면 안움직임)
    public float cameraRotationLimit; //카메라 각도 45
    private float currentCameraRotationX;
    
    // 컴포넌트_____________________________________________
    public Camera theCamera;
    private Rigidbody myRigid;
    //_____________________________________________________
   

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider> ();
        myRigid = GetComponent<Rigidbody>();
        // myRigid에 리지드바디 넣겠다
        applySpeed = walkSpeed;
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;

        
    }

    void Update()
    {
        IsGround(); // 레이저
        TryJump();
        TryRun();
        TryCrouch();
        Move();
        CameraRotation();
        CharacterRotation();
    }

    private void TryCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }

    private void Crouch()
    {
        isCrouch = !isCrouch; // 스위치 역할
        /* // 윗줄 의미
         * if (isCrouch)
            isCrouch = false;
        else
            isCrouch = true;
        */

        if (isCrouch)
        {
            applySpeed = croechSpeed;
            applyCrouchPosY = crouchPosY;
        }
        else
        {
            applySpeed = walkSpeed;
            applyCrouchPosY = originPosY;
        }
        //theCamera.transform.localPosition = new Vector3(theCamera.transform.localPosition.x, applyCrouchPosY, theCamera.transform.localPosition.z);
        StartCoroutine(CrouchCoroutine());
        // 코루틴 시작
    
    }

    // 코루친,, 기원문법 : IEnumerator Crluchcoroutione(){}
    // 병렬처리(같이 동작)
    IEnumerator CrouchCoroutine()
    { // 자연스러운 카메라 처리; 부드러운 동작 실행
        float _posY = theCamera.transform.localPosition.y;
        //yield return new WaitForSeconds(1f);
        int count = 0;
        while (_posY != applyCrouchPosY) //원하는 값이 나올 때 까지 반복(앉은 자세)
        {
            count++;
            // 보간 - 처음 빨랐다가 목적지에 도달할수록 서서히 느려짐
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            // (a,b,c) - a부터 b까지 c의 비율로 증가; c가 0.5면 만가고 남은거의 반가고 ... 도달할 때까지 반복
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            if (count > 15) 
                break;
            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f);
    }

    // 지면 체크.
    private void IsGround() // 레이저
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }


    //점프 시도
    private void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    // 점프
    private void Jump()
    {
        // 앉기 해제
        if (isCrouch)
            Crouch();
        myRigid.velocity = transform.up * jumpForce;

    }

    // 달리기 시도 
    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancle();
        }
    }


    // 달리기
    private void Running()
    {
        // 앉기 해제
        if (isCrouch)
            Crouch();
        isRun = true;
        applySpeed = runSpeed;
    }

    //달리기 취소
    private void RunningCancle()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    //움직임 실행
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

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    // 좌우 캐릭터 회전
    private void CharacterRotation()
    { 
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        // 오일러값을 쿼터니엄 값으로 바꿈
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        //Debug.Log(myRigid.rotation);
        //Debug.Log(myRigid.rotation.eulerAngles);
    }


    //상하 카메라 회전
    private void CameraRotation()
    { 
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX; //반전시키기
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //각도 제한

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); //localEulerAngles - 오일러각으로 변환;
    }


}
