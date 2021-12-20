using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBackMove : MonoBehaviour
{
    public float moveSpeed;   //��� �̵� �ӵ�
    GameObject universeBG2;   //���ӿ�����Ʈ ���ֹ��2 (BG_Universe2)
    GameObject universeBG3;   //���ӿ�����Ʈ ���ֹ��3 (BG_Universe3)
    float removeDelay = 0.4f;
    float removeTime = 0;

    private void OnEnable()
    {
        moveSpeed = 0.75f;
        universeBG2 = GameObject.Find("BG_Universe2"); //���ֹ��2 ã��
        universeBG3 = GameObject.Find("BG_Universe3"); //���ֹ��3 ã��
    }
    private void Update()
    {
        BGBackMoving();   //���� / �ٴ� ��� �̵� �Լ�
    }

    void BGBackMoving()  //����/�ٴٹ���̵�
    {
        if (this.transform.position.x > -98)
        {
            this.transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }

        if (this.transform.position.x < -15)
        {
            BGBackRemove();  //���� ��� ���� �Լ�
        }
    }

    void BGBackRemove()  //���� ��� ���� (0.8f �� 0.1f �� ���� �ø�? ����?)
    {

        removeTime += Time.deltaTime;
        if (removeTime > removeDelay)
        {
            universeBG2.GetComponent<SpriteRenderer>().color -= new Color(1, 1, 1,0.05f);
            universeBG3.GetComponent<SpriteRenderer>().color -= new Color(1, 1, 1,0.05f);
            removeTime = 0;
        }
    }

}
