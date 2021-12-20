using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public ObjPoolingMgr objPoolingMgr;  //������Ʈ Ǯ�� �Ŵ���

    public string[] minimes;             //������ƮǮ���� �ҷ��� �̴Ϲ� �̸�
    public string[] minimesBullet;       //������Ʈ Ǯ���� �ҷ��� �̴Ϲ� �Ѿ�
    public float delay;                  //�̴Ϲ� ���� �ð�
    public int attackPattern;            //�����������ͳ� 0. ���� 1. �̴Ϲ� ����
    public float bossTime;               //��������ð�
    public float minimeTime;
    //public float minimeRespawn;//�̴Ϲ� ���� �ֱ�
    public bool isBossOn;//���� ��������
    public bool isRespawn; //�̴Ϲ� ���������
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

            case 1:        //�̴Ϲ� ����

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





