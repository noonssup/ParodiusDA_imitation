using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotonCtrl : MonoBehaviour
{
    float moveSpeed;
    int bulletDamage;
    public bool isOnland;
    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.gravityScale = 1;
        isOnland = false;
        moveSpeed = 5;
        bulletDamage = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)   //���� �������� SUBWEAPONTRIGGER �±׸� ���� �ݸ����� ������ Y�� ����
    {
        IDamage damage = collision.GetComponent<IDamage>();

        if (collision.tag == "ENEMY")
        {
            damage.Damage(bulletDamage);
        }

        if (this.gameObject != null)
        {
            if (collision.tag == "SUBWEAPONTRIGGER")
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)    //SUBWEAPONTRIGGER �� ��� �ִ� ���� Y���� ��� ���� ��Ű�� ������ �̵���
    {
        if (this.gameObject != null)
        {
            if (collision.tag == "SUBWEAPONTRIGGER")
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                isOnland = true;
                //StartCoroutine(PotonMoving());
                this.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(100f, -3.8f, 0), moveSpeed * Time.deltaTime);

            }
            else if(collision.tag == "BGGuard")
            {
                isOnland = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)   //SUBWEAPONTRIGGER �ݸ������� �������� Y�� ���� ����Ͽ� �߷� ����, ȭ�� �Ʒ��� ���������� ����
    {
        if (this.gameObject != null)
        {
            if (collision.tag == "SUBWEAPONTRIGGER")
            {
                rb.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    private void Update()
    {
        if (this.transform.position.y < -5)    //Y�� ��ǥ -5 ���ϰ� �Ǹ� ������Ʈ ����
        {
            this.gameObject.SetActive(false);
        }
    }
}
