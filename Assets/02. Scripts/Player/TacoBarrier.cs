using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoBarrier : MonoBehaviour, IDamage
{
    int barrierHp;   //��ȣ���� ü�� (10)
    int bulletDamage; //��ȣ���� ENEMY �±׸� ���� ���� �ε����� ��� �ش� ������ �ִ� ������ (1)
    public Transform playerPos;  //��ȣ���� ������ �� ��ġ�� �ڸ�
    public TacoFireCtrl tacoFireCtrl;  //Ÿ�� ���ݰ��� ��ũ��Ʈ
    Animator anim;  //��ȣ���� ���¿� ���� ��������Ʈ ���� (�ִϸ������� �Ķ���͸� �̿��� ��ȯ)

    private void OnEnable()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
        playerPos = GameObject.Find("Taco(Clone)").GetComponent<Transform>();
        tacoFireCtrl = GameObject.Find("Taco(Clone)").GetComponent<TacoFireCtrl>();
        bulletDamage = 1;
        barrierHp = 10;
    }

    private void Update()
    {
        //Vector3 newPos = playerPos.position + new Vector3(0, 0, 0);
        this.transform.position = playerPos.position + new Vector3(0.72f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage damage = collision.GetComponent<IDamage>();

        if (collision.tag == "ENEMY")
        {
            barrierHp--;
            damage.Damage(bulletDamage);
            Debug.Log(barrierHp);
            anim.SetInteger("BarrierHp", barrierHp);


            if (collision.name == "BossMinime(Clone)")   //��ȣ���� �ε��� ��ü�� �����̴Ϲ̶�� �����̴Ϲ̸� ��Ȱ��ȭ
            {
                collision.gameObject.SetActive(false);
            }

            if (barrierHp <= 0)
            {
                tacoFireCtrl.BarrierFalse(false);
                StartCoroutine(RemoveBarrier());
            }
        }
    }
    IEnumerator RemoveBarrier()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    public void Damage(int damage)
    {
        barrierHp -= damage;
        if (barrierHp <= 0)
        {
            tacoFireCtrl.BarrierFalse(false);
            StartCoroutine(RemoveBarrier());
        }
    }
}
