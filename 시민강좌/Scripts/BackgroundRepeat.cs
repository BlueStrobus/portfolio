using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    public float scrollSpeed = 0.9f;
    //��ũ���� �ӵ��� ����� ������ �ݴϴ�. 
    private Material thisMaterial;
    //Quad�� Material �����͸� �޾ƿ� ��ü�� �����մϴ�. 
    void Start()
    {
        //��ü�� �����ɶ� ���� 1ȸ�� ȣ�� �Ǵ� �Լ� �Դϴ�. 
        thisMaterial = GetComponent<Renderer>().material;
        //���� ��ü�� Component���� ������ Renderer��� ������Ʈ�� Material������ �޾ƿɴϴ�. 
    }
    void Update()
    {
        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // ���Ӱ� �������� OffSet ��ü�� �����մϴ�. 
        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));
        // Y�κп� ���� y���� �ӵ��� ������ ������ �ؼ� �����ݴϴ�. 
        thisMaterial.mainTextureOffset = newOffset;
        //�׸��� ���������� Offset���� �������ݴϴ�. 
    }
}