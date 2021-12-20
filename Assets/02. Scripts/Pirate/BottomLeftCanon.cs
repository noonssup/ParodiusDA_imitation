using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLeftCanon : MonoBehaviour, IDamage
{
    public int cannon1Hp;

    public ObjPoolingMgr objPoolingMgr;

    public string[] pirateBullets;

    float fireDelay;
    float fireTime;
    float playerY;
    float pirateY;

    Animator cannon1Anim;

    Transform player;
    Transform piratePos;

    CapsuleCollider2D collider1;

    GameObject pirateBullet;
    void Awake()
    {
        piratePos = GameObject.Find("PirateShip(Clone)").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        cannon1Anim = GetComponentInChildren<Animator>();
        collider1 = GetComponent<CapsuleCollider2D>();
        pirateBullets = new string[] { "PirateBullet" };
        cannon1Hp = 8;
        fireDelay = 5;
        fireTime = 0;

    }

    private void Update()
    {
        pirateY = piratePos.position.y;
        playerY = player.position.y;
        if (cannon1Hp > 0)//Ä³¸¯ÅÍ ¹æÇâÀ¸·Î ÃÄ´Ùº¸´Â Ä³³í
        {
            if (pirateY - 3 <= playerY)//ÁÂÃø 0
            {
                Angle0();
            }
            else if (pirateY - 3 >= playerY && pirateY - 4 < playerY) //ÁÂÃø 45
            {
                Angle30();
            }
            else if (pirateY - 4 >= playerY && pirateY - 5 < playerY)//ÁÂÃø 90
            {
                Angle45();
            }
            else if (pirateY - 5 >= playerY && pirateY - 6 < playerY)//ÁÂÃø 90
            {
                Angle60();
            }
            else if (pirateY - 6 >= playerY)//ÁÂÃø 90
            {
                Angle90();
            }

            fireTime += Time.deltaTime;
            if (fireTime > fireDelay && cannon1Hp > 0)
            {
                pirateBullet = objPoolingMgr.MakeObj(pirateBullets[0]);
                pirateBullet.transform.position = this.transform.position;
                fireTime = 0;
            }
        }
    }
    void IDamage.Damage(int damage)
    {

        cannon1Hp -= damage;
        cannon1Anim.SetInteger("Cannon1Hp", cannon1Hp);
        if (cannon1Hp < 1)
        {
            cannon1Anim.SetTrigger("CannonDown");
            collider1.enabled = false;
        }

    }

    void Angle0()
    {
        cannon1Anim.SetInteger("Cannon1Angle", 0);
    }
    void Angle30()
    {
        cannon1Anim.SetInteger("Cannon1Angle", 1);
    }
    void Angle45()
    {
        cannon1Anim.SetInteger("Cannon1Angle", 2);
    }
    void Angle60()
    {
        cannon1Anim.SetInteger("Cannon1Angle", 3);
    }
    void Angle90()
    {
        cannon1Anim.SetInteger("Cannon1Angle", 4);
    }


}







