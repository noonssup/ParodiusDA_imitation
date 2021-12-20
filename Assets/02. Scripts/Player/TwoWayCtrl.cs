using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayCtrl : MonoBehaviour
{
    float moveSpeed;
    int bulletDamage;
    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 1;
        bulletDamage = 1;
    }

    private void Update()
    {
        rb.AddForce(Vector2.right * moveSpeed);   //���� �������� �ణ �̵� (��¦ ƨ���ֵ�)

        if (this.transform.position.y < -5 || this.transform.position.y > 5)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)   //�ݸ��� �浹 �� ������ �Լ�
    {
        IDamage damage = collision.GetComponent<IDamage>();

        //if (collision.tag == "NONTARGET" || collision.tag == "BGGuard")
        //{
        //    this.gameObject.SetActive(false);

        //}

        if (damage != null && collision.tag == "ENEMY")  //���� �ε��� ������Ʈ�� �±װ� ENEMY ���, �׸��� �ش� ������Ʈ�� damage �� ���� �ִٸ� �Լ� ����
        {
            damage.Damage(bulletDamage);

            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)   //��� ������Ʈ�� �ݸ����� ���� ��� �ش� �ݸ��� �������� ���������� �Ǹ� ����
    {
        if (collision.tag == "NONTARGET" || collision.tag == "BGGuard")
        {
            this.gameObject.SetActive(false);

        }
    }
}
