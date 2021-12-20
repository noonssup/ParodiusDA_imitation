using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    float yUp;      //���� �����̴� ���κ�
    float yDown;    //�Ʒ��� �����̴� ���κ�
    float bossSpeed;//���� �̵��ӵ�
    bool isHitBoss; //���� �ǰ� ���� ����

    Vector3 bossDir = Vector3.up;

    Animator bossAnim;

    private void OnEnable()
    {
        bossSpeed = 5f;
        isHitBoss = true;
    }

    void Start()
    {

    }

    void Update()
    {
        MovingBoss();
        
    }

    void MovingBoss()
    {
        this.transform.position += bossDir * bossSpeed * Time.deltaTime;
             //���� ����
        if(this.transform.position.y == moveY)
        {
            bossDir = Vector3.up;
            moveY = Random.Range(-2.5f, 2.5f);
        }
    }
}
