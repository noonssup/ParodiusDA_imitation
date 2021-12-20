using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public ObjPoolingMgr objPoolingMgr;  //오브젝트 풀링 매니저

    public string[] minimes;             //오브젝트풀에서 불러올 미니미 이름
    public string[] minimesBullet;       //오브젝트 풀에서 불러올 미니미 총알
    public float delay;                  //미니미 생성 시간
    public int attackPattern;            //보스공격패터너 0. 등장 1. 미니미 생성
    public float bossTime;               //보스등장시간
    public float minimeTime;
    //public float minimeRespawn;//미니미 생성 주기
    public bool isBossOn;//보스 생성여부
    public bool isRespawn; //미니미 재생성여부
    public int minimeCount;

    GameObject player;
    public GameObject objMinime;
    public GameObject objMinimeBullet;
    private void Awake()
    {
        isBossOn = false;
        isRespawn = false;
        minimeCount = 0;
    }
    void OnEnable()
    {
        isBossOn = true;
        player = GameObject.FindWithTag("Player").GetComponent<GameObject>();
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        minimes = new string[] { "BossMinime" };
        delay = 0f;
        attackPattern = 0;

    }
    void Update()
    {
        switch (attackPattern)
        {
            case 0:
                bossTime += Time.deltaTime;
                if (bossTime > 3)
                {
                    attackPattern = 1;
                    delay = 0;
                }
                break;

            case 1:        //미니미 생성

                delay += Time.deltaTime;
                if (delay > 0.5f)
                {
                    minimeMake();

                    if (minimeCount == 8)
                    {
                        attackPattern = 2;
                    }
                    delay = 0;
                }
                break;

            case 2:
                minimeTime += Time.deltaTime;
                if (minimeTime > 10)
                {
                    minimeCount = 0;
                    attackPattern = 3;
                }
                break;
            case 3:
                minimeTime = 0;
                attackPattern = 1;
                break;
        }
    }
    void minimeMake()
    {
        objMinime = objPoolingMgr.MakeObj(minimes[0]);
        if (objMinime != null)
        {
            objMinime.transform.SetParent(GameObject.Find("Boss(Clone)").transform);
            objMinime.transform.position = this.gameObject.transform.position;
            minimeCount++;
        }
    }
}





