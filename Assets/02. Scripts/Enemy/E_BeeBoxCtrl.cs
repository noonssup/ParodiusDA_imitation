using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BeeBoxCtrl : MonoBehaviour, IDamage
{
    public ObjPoolingMgr objPoolingMgr;   //objPoolingMgr �� ���� ����
    public Animator beeBoxAnim;   //�ִϸ����͸� ���� ����
    public BoxCollider2D objCollider;  //�ݶ��̴��� ���� ����
    public GameObject explosion; //���� ����Ʈ�� ���� ������Ʈ ����
      
    public GameObject enemyBee;  //�� ������ ���� ������Ʈ ����
    public int enemyHp;  //�ڽ��� ü��

    public float fireDir;  //���� ������ Ÿ�̹��� Ȯ���ϱ� ���� �Ÿ��� ���� (objPoolingMgr ���� �Ÿ����� ���)
    public float fireTime;  //�� ���� Ÿ�̹�
    bool isEnemyDown;

    private void OnEnable()
    {
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();  //objManager �Ҵ�
        beeBoxAnim = GetComponentInChildren<Animator>();  //�ڽ� �ִϸ����� �Ҵ�
        beeBoxAnim.SetInteger("FireBee", 0);
        objCollider = this.gameObject.GetComponent<BoxCollider2D>();  //���� ���� �ÿ��� �ݶ��̴� ��Ȱ��ȭ ó��
        objCollider.enabled = false;
        enemyHp = 5;
        fireTime = 0;
        isEnemyDown = false;
    }

    private void Update()
    {
        fireDir = objPoolingMgr.transform.position.x - this.transform.position.x;
        OnCollider();  //�÷���ȭ�鿡 ��������� �ݶ��̴� Ȱ��ȭ
        if (isEnemyDown == false)  //�ڽ��� ���� �ʾ��� ��쿡�� �� ���� ����
        {
            MoveOnFireBee();
        }
    }



    void OnCollider()  //ȭ�� ���߾Ӱ��� x��ǥ ��ġ���� -6 ������ ��� �ݶ��̴� Ȱ��ȭ
    {
        if (fireDir > -6)
        {
            objCollider.enabled = true;
        }
    }

    void MoveOnFireBee()
    {
        if(fireDir > -5 && fireDir < -3.5f)
        {
            beeBoxAnim.SetInteger("FireBee", 1);
            FireBee();
        }
        else if (fireDir < 4.5f && fireDir > 3f)
        {
            beeBoxAnim.SetInteger("FireBee", 1);
            FireBee();
        }
        else
        {
            beeBoxAnim.SetInteger("FireBee", 0);
        }
    }

    void FireBee()
    {
        fireTime += Time.deltaTime;
        if (fireTime >= 0.3f)
        {
            Instantiate(enemyBee, this.transform.position, Quaternion.identity);
            fireTime = 0;
        }
    }

    public void Damage(int playerAtkDamage)
    {
        enemyHp -= playerAtkDamage;

        if (enemyHp <= 0)
        {
            GameManager.instance.ScoreAdd(100);
            if (isEnemyDown == false)
            {
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            }
            beeBoxAnim.SetBool("Destroy", true);
            isEnemyDown = true;
            //this.gameObject.SetActive(false);
        }
    }
}
