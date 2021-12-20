using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float moveSpeed;  //����������� �̵� �ӵ�
    public float bgMovePosition;

    private void OnEnable()
    {
        moveSpeed = 2f * 0.8f;  //��� �̵� �ӵ� �ʱ�ȭ

    }
    private void Update()
    {
        BGMoving();  //��� �̵� �Լ�
        PassMovePosition();  //���ӸŴ��� ��ũ��Ʈ�� ��� ������Ʈ�� X��ǥ ��ġ�� ����
    }

    void BGMoving()  //��� �̵�
    {
        if (this.transform.position.x > -207)
        {
            this.transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }
    }

    void PassMovePosition()
    {
        bgMovePosition = this.transform.position.x;
        GameManager.instance.bgMovePosition = bgMovePosition;
    }
}
