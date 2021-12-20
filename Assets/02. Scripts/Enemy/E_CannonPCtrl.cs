using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_CannonPCtrl : MonoBehaviour, IDamage
{
    public GameObject Player;
    public ObjPoolingMgr objPoolingMgr;
    public Animator cannonAnim;
    public GameObject itemWeapon;
    public GameObject destroyEff;

    public string[] cannonPBullets;
    public int enemyHp;

    public float fireDelay, fireTime;  //�Ѿ� ���� �ֱ� Ȯ�ο� �ð� �Լ�
    public float cannonDir; //�÷��̾�� ĳ�� �Ÿ���
    public float cannonOnMoveDir; //�÷��̾�� ������ƮǮ���� �Ÿ���
    public CircleCollider2D objCollider;   //�ݶ��̴� Ȱ��/��Ȱ��ȭ�� �����ϱ� ���� �ݶ��̴� ����

    GameObject cannonPBullet;
 
    private void OnEnable()
    {
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        cannonAnim = GetComponentInChildren<Animator>();
        objCollider = this.gameObject.GetComponent<CircleCollider2D>();  //���� ���� �� �ݶ��̴��� ��Ȱ��ȭ ��Ŵ
        objCollider.enabled = false;
        cannonPBullets = new string[] { "BossMinimeBullet" };
        enemyHp = 3;
        fireTime = 0f;
    }

    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        cannonDir = Player.transform.position.x - this.transform.position.x;  //�÷��̾���� �Ÿ���
        cannonOnMoveDir = objPoolingMgr.transform.position.x - this.transform.position.x; //objPoolingMgr ���� �Ÿ��� (ȭ���� ���߾� ��ġ���� �Ÿ�)
        fireDelay = Random.Range(3.5f, 5.0f);  //�Ѿ� ���� ������ ������������ ó��
        OnCollider();  //�ݶ��̴��� Ȱ��ȭ ��ų �Լ�
        checkPlayerPos();   //�÷��̾� ��ġ�� ���� ĳ���� ���� ��ȯ

        if (enemyHp > 0)
        {
            setBullet();   //ü���� ���� ��� bullet �߻�
        }

        if (this.transform.position.x < -8f)  // x��ǥ ���� -8 ���ϰ� �Ǹ� ������Ʈ ��Ȱ��ȭ
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollider()  //ȭ�� ���߾Ӱ��� x��ǥ ��ġ���� -6 �̻��� ��� �ݶ��̴� Ȱ��ȭ
    {
        if (cannonOnMoveDir > -6)
        {
            objCollider.enabled = true;
        }
    }

    void checkPlayerPos()  //�÷��̾���� �Ÿ��� ���� ������ �ٶ󺸴� ������ ����
    {
        if (cannonAnim.name == "ImageBlueCannonPang")
        {
            if (cannonDir < 0 || cannonDir > 0)   //���ĳ�����
            {
                //���� or ������ �ü�ó��
                if (cannonDir <= -5)
                {
                    cannonAnim.SetInteger("BlueCannonPang", -6);
                }
                else if (cannonDir > -5 && cannonDir <= -1)
                {
                    cannonAnim.SetInteger("BlueCannonPang", -2);
                }
                else if (cannonDir > -1 && cannonDir <= 1)
                {
                    cannonAnim.SetInteger("BlueCannonPang", 0);
                }
                else if (cannonDir > 1 && cannonDir <= 5)
                {
                    cannonAnim.SetInteger("BlueCannonPang", 2);
                }
                else if (cannonDir > 5)
                { cannonAnim.SetInteger("BlueCannonPang", 6); }
            }
        }
        else if (cannonAnim.name == "ImageRedCannonPang")
        {
            if (cannonDir < 0 || cannonDir > 0)   //����ĳ�����
            {
                //���� or ������ �ü�ó��
                if (cannonDir <= -5)
                {
                    cannonAnim.SetInteger("RedCannonPang", -6);
                }
                else if (cannonDir > -5 && cannonDir <= -1)
                {
                    cannonAnim.SetInteger("RedCannonPang", -2);
                }
                else if (cannonDir > -1 && cannonDir <= 1)
                {
                    cannonAnim.SetInteger("RedCannonPang", 0);
                }
                else if (cannonDir > 1 && cannonDir <= 5)
                {
                    cannonAnim.SetInteger("RedCannonPang", 2);
                }
                else if (cannonDir > 5)
                { cannonAnim.SetInteger("RedCannonPang", 6); }
            }
        }
    }

    void setBullet()  //�÷���ȭ��� ��������� �Ѿ� �߻� 
    {
        fireTime += Time.deltaTime;
        if (cannonOnMoveDir > -6)
        {
            if (fireTime > fireDelay)
            {
                cannonPBullet = objPoolingMgr.MakeObj(cannonPBullets[0]);
                cannonPBullet.transform.position = transform.position;
                fireTime = 0;
            }
        }
    }

    public void Damage(int playerAtkDamage)  //�÷��̾�� �ǰݵ� ��� ����Ǵ� damage �Լ�
    {
        enemyHp -= playerAtkDamage;

        if (enemyHp <= 0)
        {
            GameManager.instance.ScoreAdd(100);

            if (this.cannonAnim.name == "ImageRedCannonPang")
            {
                Instantiate(destroyEff, this.transform.position, Quaternion.identity);
                Instantiate(itemWeapon, this.transform.position, Quaternion.identity);

                this.gameObject.SetActive(false);
            }
            else if (this.cannonAnim.name == "ImageBlueCannonPang")
            {
                Instantiate(destroyEff, this.transform.position, Quaternion.identity);
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
