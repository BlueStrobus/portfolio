using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{// �÷��̾� �����̱�

    // �̵� �ӵ�_________________________________________
    public float walkSpeed; // �ӵ� 5
    // private���� SerializeField�Լ������ؼ� �ν���ǿ��� �ӵ� ���� �����ϰ� ����
    //�ٵ� �� �ۺ� �Ⱦ���?
    //__________________________________________

    // ī�޶�________________________________________
    public float lookSensitivity;// ī�޶� �ΰ���  1(0���� �ϸ� �ȿ�����)
    public float cameraRotationLimit; //ī�޶� ���� 45
    private float currentCameraRotationX;
    public Camera theCamera;


    private Rigidbody myRigid;



    void Start()
    {
        theCamera = FindObjectOfType<Camera>();
        myRigid = GetComponent<Rigidbody>();
        // myRigid�� ������ٵ� �ְڴ�
        
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
        // Horizontal - �¿�(X)
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        // Vertical - �յ�(Z)
        // - ����(Y ����)


        //���� ������ �̵����� ����
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized*walkSpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }
    private void CharacterRotation()
    { // �¿� ĳ���� ȸ��
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        // ���Ϸ����� ���ʹϾ� ������ �ٲ�
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        Debug.Log(myRigid.rotation);
        Debug.Log(myRigid.rotation.eulerAngles);
    }

    private void CameraRotation()
    { //���� ī�޶� ȸ��
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX; //������Ű��
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //���� ����

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); //localEulerAngles - ���Ϸ������� ��ȯ;
    }


}
