using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMinimeAttack : MonoBehaviour
{
    public GameObject Boss;

    public ObjPoolingMgr objPoolingMgr; //오브젝트 풀링 매니저

    public string[] minimeBullets;

    float fireDelay;
    float fireTime;

    //Transform player;
    BossMove bossmove;
    GameObject boss;
    GameObject minimeBullet;
    //BossAttack bossAttack;
    private void OnEnable()
    {
        //bossAttack = GameObject.Find("Boss").GetComponent<BossAttack>();
        minimeBullets = new string[] { "BossMinimeBullet" };

       
        fireDelay = 6;
        fireTime = 0;

    }
    void Update()
    {
        if (Boss != null)
        {
            objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
            bossmove = GameObject.Find("Boss(Clone)").GetComponent<BossMove>();
            boss = GameObject.Find("Boss(Clone)").GetComponent<GameObject>();
        }
        //  bossAttack.minimeBulletMaker();
        // 미니미 총알 발사(생성)
        if (bossmove.isBossLive == true)
        {
            setBullet();
        }
    }
    void setBullet()
    {
        fireTime += Time.deltaTime;
        if (fireTime > fireDelay)//미니미총알발사
        {
            minimeBullet = objPoolingMgr.MakeObj(minimeBullets[0]);
            minimeBullet.transform.position = this.transform.position;
            fireTime = 0;
        }
    }
    //public void minimeBulletMaker()
    //{
    //    objMinimeBullet = objPoolingMgr.MakeObj(minimesBullet[0]);
    //    if (objMinimeBullet != null)
    //    {
    //        objMinimeBullet.transform.position = this.gameObject.transform.position;
    //    }
    //}
}
