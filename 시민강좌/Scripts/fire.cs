using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float moveSpeed = 0.45f; //�Ѿ��� ������ �ӵ��� ����� �������ݽô�. 
    void Start()
    {
    }
    void Update()
    {
        float moveY = moveSpeed * Time.deltaTime;         //�̵��� �Ÿ��� ������ �ݽô�. 
        transform.Translate(0, moveY, 0);    //�̵��� �ݿ����ݽô�. 
    }
}