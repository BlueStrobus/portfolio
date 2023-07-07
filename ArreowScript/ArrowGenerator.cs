using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;    // ȭ�� �������� �����ϴ� ����
    public GameObject redArrowPrefab; // ���� ȭ�� �������� �����ϴ� ����
    float span = 0.1f;                // ȭ�� ���� �ֱ�
    float delta = 0;                  // �ð� ���� ����
    float span1 = 1f;                 // ���� ȭ�� ���� �ֱ�
    float delta1 = 0;                 // ���� ȭ�� �ð� ���� ����
    float deltaGravity = 0;           // �߷� ���� �ð� ���� ����
    float gravityScale = 1;           // �߷� ũ�� ���� ����
    int arrowCount = 0;               // ������ ȭ�� ����

    void Update()
    {
        this.delta += Time.deltaTime;  // ����� �ð��� delta�� ����
        deltaGravity += Time.deltaTime; // ����� �ð��� deltaGravity�� ����

        // �߷� ���� �ð��� 5�� �̻� ����� ���
        if (deltaGravity > 5)
        {
            deltaGravity = 0;   // �߷� ���� �ð� �ʱ�ȭ
            gravityScale = 3;    // �߷� ũ�⸦ 3���� ����
        }

        // ȭ�� ���� �ֱ⸶�� ����
        if (this.delta > this.span)
        {
            this.delta = 0;    // �ð� �ʱ�ȭ
            GameObject go = Instantiate(arrowPrefab);  // ȭ�� �������� �����Ͽ� ���� ������Ʈ ����
            int px = Random.Range(-6, 7);  // -6���� 6 ������ ������ ���� ���� ��ǥ�� ����
            go.transform.position = new Vector3(px, 7, 0);   // ������ ���� ������Ʈ�� ��ġ ����
            go.GetComponent<Rigidbody2D>().gravityScale = this.gravityScale;  // ������ ȭ���� �߷� ũ�� ����
            arrowCount++;  // ������ ȭ�� ���� ����

            if (arrowCount >= 10)
            {
                arrowCount = 0;  // ȭ�� ���� �ʱ�ȭ
                // ���� ȭ�� ����
                GameObject redGo = Instantiate(redArrowPrefab);  // ���� ȭ�� �������� �����Ͽ� ���� ������Ʈ ����
                int redPx = Random.Range(-6, 7);  // -6���� 6 ������ ������ ���� ���� ��ǥ�� ����
                redGo.transform.position = new Vector3(redPx, 7, 0);  // ������ ���� ������Ʈ�� ��ġ ����
                redGo.GetComponent<Rigidbody2D>().gravityScale = this.gravityScale;  // ������ ���� ȭ���� �߷� ũ�� ����
            }
        }
    }
}
