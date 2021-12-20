using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCannon1 : MonoBehaviour, IDamage
{
    public int cannon3Hp;
    
    public ObjPoolingMgr objPoolingMgr;//오브젝트 풀링 매니저

    public string[] pirateBullets;

   public GameObject DestroyEff;


    float fireDelay;
    float fireTime;
    float playerY;
    float pirateY;

    Animator cannon3Anim;

    Transform player;
    Transform piratePos;

    CircleCollider2D collider3;

    GameObject pirateBullet;
    private void Awake()
    {
        piratePos = GameObject.Find("PirateShip(Clone)").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        collider3 = GetComponent<CircleCollider2D>();
        cannon3Anim = GetComponentInChildren<Animator>();
        pirateBullets = new string[] { "PirateBullet" };
        cannon3Hp = 8;
        fireDelay = 6;
        fireTime = 0;
    }

    private void Update()
    {
        pirateY = piratePos.position.y;
        playerY = player.position.y;
        if(cannon3Hp > 0) { 
        if (pirateY + 1 > playerY)//좌측 0
        {
            Angle0();
        }
        else if (pirateY + 1 < playerY && pirateY + 2 > playerY) //좌측 45
        {
            Angle45();
        }
        else if (pirateY + 2 <= playerY && pirateY + 3 > playerY)//좌측 90
        {
            Angle90();
        }
        }

        //135, 180도 대포 이미지
        //if (player.transform.position.x > piratePos.position.x)
        //{
        //     else if (pirateY + 1.5 <= playerY && pirateY + 2.0 > playerY)//우측 135
        //    {
        //        Angle135();
        //    }
        //    else if (pirateY + 2 <= playerY && pirateY + 2.5 > playerY)//우측 180
        //    {
        //        Angle180();
        //    }

        //}


        fireTime += Time.deltaTime;
        if (fireTime > fireDelay && cannon3Hp > 0)
        {
            pirateBullet = objPoolingMgr.MakeObj(pirateBullets[0]);
            pirateBullet.transform.position = this.transform.position;
            fireTime = 0;
        }
    }
    void IDamage.Damage(int damage)
    {
        cannon3Hp -= damage;
        cannon3Anim.SetInteger("TopCannon1Hp", cannon3Hp);
        if (cannon3Hp < 1)
        {
            collider3.enabled = false;
            Instantiate(DestroyEff, this.transform.position, Quaternion.identity);
        }
    }

    void Angle0()
    {
        cannon3Anim.SetInteger("Cannon3Angle", 0);
    }
    void Angle45()
    {
        cannon3Anim.SetInteger("Cannon3Angle", 1);
    }

    void Angle90()
    {
        cannon3Anim.SetInteger("Cannon3Angle", 2);
    }
    //void Angle135()
    //{
    //    cannon3Anim.SetInteger("Cannon3Angle", 3);
    //}
    //void Angle180()
    //{
    //    cannon3Anim.SetInteger("Cannon3Angle",4);
    //}
}

