using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public Animator birdAnimator; // Animator ������Ʈ�� �����ϱ� ���� ����

    private void Start()
    {
        // Animator ������Ʈ ��������
        birdAnimator = GetComponent<Animator>();
    }

    public void FlyAway()
    {
        // "Fly"��� �̸��� �ִϸ��̼��� ����մϴ�.
        birdAnimator.SetTrigger("Fly");
    }
}

