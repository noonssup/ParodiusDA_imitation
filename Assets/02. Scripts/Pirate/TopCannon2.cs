using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCannon2 : MonoBehaviour, IDamage
{
    [SerializeField]
    GameObject DestroyEff;


    public ObjPoolingMgr objPoolingMgr;

    public string[] pirateBullets;

    public int cannon4Hp;

    float fireDelay;
    float fireTime;
    float playerY;
    float pirateY;

    Animator cannon4Anim;

    Transform player;
    Transform piratePos;

    CircleCollider2D collider4;

    GameObject pirateBullet;

    private void Awake()
    {
        piratePos = GameObject.Find("PirateShip(Clone)").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        collider4 = GetComponent<CircleCollider2D>();
        cannon4Anim = GetComponentInChildren<Animator>();
        pirateBullets = new string[] { "PirateBullet" };
        cannon4Hp = 8;
        fireDelay = 6;
        fireTime = 0;
    }
    private void Update()
    {
        pirateY = piratePos.position.y;
        playerY = player.position.y;
        if (cannon4Hp > 0)
        {
            if (pirateY + 1 > playerY)//ÁÂÃø 0
            {
                Angle0();
            }
            else if (pirateY + 1 < playerY && pirateY + 2 > playerY) //ÁÂÃø 45
            {
                Angle45();
            }
            else if (pirateY + 2 <= playerY && pirateY + 3 > playerY)//ÁÂÃø 90
            {
                Angle90();
            }
        }
        fireTime += Time.deltaTime;
        if (fireTime > fireDelay && cannon4Hp > 0)
        {
            pirateBullet = objPoolingMgr.MakeObj(pirateBullets[0]);
            pirateBullet.transform.position = this.transform.position;
            fireTime = 0;
        }
    }

    void IDamage.Damage(int damage)
    {
        cannon4Hp -= damage;
        cannon4Anim.SetInteger("TopCannon2Hp", cannon4Hp);
        if (cannon4Hp < 1)
        {
            Instantiate(DestroyEff, this.transform.position, Quaternion.identity);
            collider4.enabled = false;
        }
    }

    void Angle0()
    {
        cannon4Anim.SetInteger("Cannon4Angle", 0);
    }
    void Angle45()
    {
        cannon4Anim.SetInteger("Cannon4Angle", 1);
    }

    void Angle90()
    {
        cannon4Anim.SetInteger("Cannon4Angle", 2);
    }
}
