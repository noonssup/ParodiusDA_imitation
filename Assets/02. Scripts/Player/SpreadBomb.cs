using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBomb : MonoBehaviour
{
    int spreadBombDamage;

    private void Awake()
    {
        spreadBombDamage = 1;
    }

    private void OnEnable()
    {
        spreadBombDamage = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage damage = collision.GetComponent<IDamage>();
        StartCoroutine(BombRemove());
        if (damage != null && collision.tag == "ENEMY")  //���� �ε��� ������Ʈ�� �±װ� ENEMY ���, �׸��� �ش� ������Ʈ�� damage �� ���� �ִٸ� �Լ� ����
        {
            damage.Damage(spreadBombDamage);


        }
        //    if (collision.tag == "ENEMY" || collision.tag == "BGGuard")
        //{

        //    //collision.hp -= damage;
        //    StartCoroutine(BombRemove());
        //}
    }

    IEnumerator BombRemove()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
