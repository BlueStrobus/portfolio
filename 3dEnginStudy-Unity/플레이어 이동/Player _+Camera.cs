using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{// �÷��̾� �����̱�

    // �̵� �ӵ�_________________________________________
    public float walkSpeed; // �ȱ� �ӵ� 5
    public float runSpeed; // �޸��� �ӵ�
    private float applySpeed; // �̵��ӵ� ����
    public float croechSpeed;
    
    //__________________________________________
    // ����_________________________
    public float jumpForce; // ���ڱ���
    //_______________________________________

    // ���º���_________________________________________
    private bool isRun = false;
    private bool isCrouch = false;
    private bool isGround = true;

    //_________________________________________________


    // ���� �� �󸶳� �ɴ°�___________________
    public float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;
    //________________________________________




    // �� ���� ����______________________
    private CapsuleCollider capsuleCollider;
    // _________________________________________



    // ī�޶�________________________________________
    public float lookSensitivity;// ī�޶� �ΰ���  1(0���� �ϸ� �ȿ�����)
    public float cameraRotationLimit; //ī�޶� ���� 45
    private float currentCameraRotationX;
    
    // ������Ʈ_____________________________________________
    public Camera theCamera;
    private Rigidbody myRigid;
    //_____________________________________________________
   

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider> ();
        myRigid = GetComponent<Rigidbody>();
        // myRigid�� ������ٵ� �ְڴ�
        applySpeed = walkSpeed;
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;

        
    }

    void Update()
    {
        IsGround(); // ������
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
        isCrouch = !isCrouch; // ����ġ ����
        /* // ���� �ǹ�
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
        // �ڷ�ƾ ����
    
    }

    // �ڷ�ģ,, ������� : IEnumerator Crluchcoroutione(){}
    // ����ó��(���� ����)
    IEnumerator CrouchCoroutine()
    { // �ڿ������� ī�޶� ó��; �ε巯�� ���� ����
        float _posY = theCamera.transform.localPosition.y;
        //yield return new WaitForSeconds(1f);
        int count = 0;
        while (_posY != applyCrouchPosY) //���ϴ� ���� ���� �� ���� �ݺ�(���� �ڼ�)
        {
            count++;
            // ���� - ó�� �����ٰ� �������� �����Ҽ��� ������ ������
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            // (a,b,c) - a���� b���� c�� ������ ����; c�� 0.5�� ������ �������� �ݰ��� ... ������ ������ �ݺ�
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            if (count > 15) 
                break;
            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f);
    }

    // ���� üũ.
    private void IsGround() // ������
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }


    //���� �õ�
    private void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    // ����
    private void Jump()
    {
        // �ɱ� ����
        if (isCrouch)
            Crouch();
        myRigid.velocity = transform.up * jumpForce;

    }

    // �޸��� �õ� 
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


    // �޸���
    private void Running()
    {
        // �ɱ� ����
        if (isCrouch)
            Crouch();
        isRun = true;
        applySpeed = runSpeed;
    }

    //�޸��� ���
    private void RunningCancle()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    //������ ����
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        // Horizontal - �¿�(X)
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        // Vertical - �յ�(Z)
        // - ����(Y ����)


        //���� ������ �̵����� ����
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    // �¿� ĳ���� ȸ��
    private void CharacterRotation()
    { 
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        // ���Ϸ����� ���ʹϾ� ������ �ٲ�
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        //Debug.Log(myRigid.rotation);
        //Debug.Log(myRigid.rotation.eulerAngles);
    }


    //���� ī�޶� ȸ��
    private void CameraRotation()
    { 
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX; //������Ű��
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //���� ����

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); //localEulerAngles - ���Ϸ������� ��ȯ;
    }


}
