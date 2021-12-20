using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRightCannon : MonoBehaviour, IDamage
{
    public int cannon2Hp;         //ü��

    public ObjPoolingMgr objPoolingMgr;

    public string[] pirateBullets;

    float fireDelay;
    float fireTime;
    float playerY;
    float pirateY;

    Animator cannon2Anim;         //�ִϸ��̼�

    Transform player;
    Transform piratePos;

    GameObject pirateBullet;

    CapsuleCollider2D collider2;   //�ݶ��̴�
    void Awake()
    {
        piratePos = GameObject.Find("PirateShip(Clone)").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        collider2 = GetComponent<CapsuleCollider2D>();
        cannon2Anim = GetComponentInChildren<Animator>(); //���߿� Ŭ���߰�
        pirateBullets = new string[] { "PirateBullet" };
        cannon2Hp = 8;
        fireDelay = 5;
        fireTime = 0;
    }

    private void Update()
    {
        pirateY = piratePos.position.y;
        playerY = player.position.y;
        if (cannon2Hp > 0)
        {
            if (pirateY - 3 <= playerY)//���� 0
            {
                Angle0();
            }
            else if (pirateY - 3 > playerY && pirateY - 4 < playerY) //���� 45
            {
                Angle30();
            }
            else if (pirateY - 4 >= playerY && pirateY - 5 < playerY)//���� 90
            {
                Angle45();
            }
            else if (pirateY - 5 >= playerY && pirateY - 6 < playerY)//���� 90
            {
                Angle60();
            }
            else if (pirateY - 6 >= playerY)//���� 90
            {
                Angle90();
            }
        }

        fireTime += Time.deltaTime;
        if (fireTime > fireDelay && cannon2Hp > 0)
        {
            pirateBullet = objPoolingMgr.MakeObj(pirateBullets[0]);
            pirateBullet.transform.position = this.transform.position;
            fireTime = 0;
        }
    }
    void IDamage.Damage(int damage)
    {
        cannon2Hp -= damage;
        cannon2Anim.SetInteger("Cannon2Hp", cannon2Hp);
        if (cannon2Hp < 1)
        {
            cannon2Anim.SetTrigger("Cannon2Down");
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            collider2.enabled = false;
        }
    }
    void Angle0()
    {
        cannon2Anim.SetInteger("Cannon2Angle", 0);
    }
    void Angle30()
    {
        cannon2Anim.SetInteger("Cannon2Angle", 1);
    }
    void Angle45()
    {
        cannon2Anim.SetInteger("Cannon2Angle", 2);
    }
    void Angle60()
    {
        cannon2Anim.SetInteger("Cannon2Angle", 3);
    }
    void Angle90()
    {
        cannon2Anim.SetInteger("Cannon2Angle", 4);
    }





}
