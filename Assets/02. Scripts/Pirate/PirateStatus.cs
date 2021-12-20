using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateStatus : MonoBehaviour, IDamage
{

    public int pirateHp; //보스 머리 체력

    float pirateSpeed; //pirate 이동속도
    float hitDelay;    //pirate 피격 후 딜레이

    bool isHitPirate; //pirate 피격 가능 여부(0 :불가능, 1: 가능)
    bool isPirateLive;//보스 생사 여부
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
        if (isHitPirate == true)//보스 피격 딜레이
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
            //얼굴 애니메이션 넣기
            isHitPirate = true;
            if (pirateHp <= 0)
            {
                GameManager.instance.ScoreAdd(1000);
                gameObject.SetActive(false);
                //피라테 터지는 애니메이션
                isPirateLive = false;
            }
        }
    }

}
