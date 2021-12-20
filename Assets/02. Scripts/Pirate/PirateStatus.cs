using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateStatus : MonoBehaviour, IDamage
{

    public int pirateHp; //���� �Ӹ� ü��

    float pirateSpeed; //pirate �̵��ӵ�
    float hitDelay;    //pirate �ǰ� �� ������

    bool isHitPirate; //pirate �ǰ� ���� ����(0 :�Ұ���, 1: ����)
    bool isPirateLive;//���� ���� ����
    Animator pirateAnim;
    Animator pirateFoot;
    private void OnEnable()
    {
        pirateHp = 8;
        hitDelay = 0;
        isHitPirate = false;
        isPirateLive = true;
        pirateAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (isHitPirate == true)//���� �ǰ� ������
        {
            hitDelay += Time.deltaTime;
            if (hitDelay > 1)
            {
                isHitPirate = false;
                hitDelay = 0;
            }
        }
    }
    void IDamage.Damage(int damage)
    {
        if (isHitPirate == false)
        {
            pirateHp -= damage;
            pirateAnim.SetTrigger("CatFaceDamaged");
            pirateAnim.SetInteger("CatFaceHp", pirateHp);
            //�� �ִϸ��̼� �ֱ�
            isHitPirate = true;
            if (pirateHp <= 0)
            {
                GameManager.instance.ScoreAdd(1000);
                gameObject.SetActive(false);
                //�Ƕ��� ������ �ִϸ��̼�
                isPirateLive = false;
            }
        }
    }

}
