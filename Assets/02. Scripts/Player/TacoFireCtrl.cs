using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TacoFireCtrl : MonoBehaviour
{
    public ObjPoolingMgr objPoolingMgr;  //������Ʈ Ǯ�� �Ŵ���
    public ItemMenu itemMenu;  //������ �޴� ��ũ��Ʈ
    public Transform firePos;  //�⺻ �Ѿ� �߻� ��ġ
    public GameObject optionTaco0;   //�ɼ�����0 ���ӿ�����Ʈ �Ҵ�
    public GameObject optionTaco1;   //�ɼ�����1 ���ӿ�����Ʈ �Ҵ�
    public GameObject optionTaco2;   //�ɼ�����2 ���ӿ�����Ʈ �Ҵ�
    public GameObject optionTaco3;   //�ɼ�����3 ���ӿ�����Ʈ �Ҵ�
    public GameObject tacoBarrier;   //��ȣ�� ���ӿ�����Ʈ �Ҵ�

    //public Text textBulletCount;

    public string[] bullets;
    public string[] subWeapons;
    public bool isSubweapon;   //������� Ȱ��ȭ ����
    public bool isBarrier;     //��ȣ�� Ȱ��ȭ ����

    float fireDelay;
    float fireTime;
    float subFireTime;
    float subFireDelay;
    int bulletNo;

    public int weaponType;
    public int optionNo = 0;

    public int bulletCount;   //�Ѿ� ī��Ʈ, ȭ�鿡 2�� �̻� ������ �ʵ��� ����
    GameObject objBullet;

    private void Awake()
    {
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        optionTaco0 = Instantiate(optionTaco0, firePos.position, Quaternion.identity);  //�ɼ����� �Ҵ�
        optionTaco1 = Instantiate(optionTaco1, firePos.position, Quaternion.identity);
        optionTaco2 = Instantiate(optionTaco2, firePos.position, Quaternion.identity);
        optionTaco3 = Instantiate(optionTaco3, firePos.position, Quaternion.identity);
        //tacoBarrier = Instantiate(tacoBarrier, firePos.position, Quaternion.identity);  //��ȣ�� ����

        bulletCount = 0;
        bullets = new string[] { "BulletNormalTaco", "BulletDoubleTaco", "BulletRippleTaco" };
        subWeapons = new string[] { "TacoBulletUpTwoWay", "TacoBulletDownTwoWay" };
        weaponType = 0;
        fireTime = 0;
        subFireTime = 0;
        fireDelay = 0.2f;
        subFireDelay = 0.7f;

    }

    private void OnEnable()
    {
        OptionUnitRemove();  //���� ���� �� �ɼ����� ��Ȱ��ȭ (������ ȹ�� �� ���� Ȱ��ȭ)
        itemMenu = GameObject.Find("StageManager").GetComponent<ItemMenu>();
        //tacoBarrier.SetActive(false);
        isBarrier = false;
        isSubweapon = false;  //���� ���� �� ������� false �� �ʱ�ȭ
    }

    public void OptionUnitRemove()
    {
        optionTaco0.SetActive(false);
        optionTaco1.SetActive(false);
        optionTaco2.SetActive(false);
        optionTaco3.SetActive(false);
    }

    void OptionUnitActive1()
    {
        optionTaco0.SetActive(true);
        optionTaco0.transform.position = this.transform.position;
        optionTaco1.SetActive(false);
        optionTaco2.SetActive(false);
        optionTaco3.SetActive(false);
    }
    void OptionUnitActive2()
    {
        optionTaco0.SetActive(true);
        optionTaco1.SetActive(true);
        optionTaco1.transform.position = this.transform.position;
        optionTaco2.SetActive(false);
        optionTaco3.SetActive(false);
    }
    void OptionUnitActive3()
    {
        optionTaco0.SetActive(true);
        optionTaco1.SetActive(true);
        optionTaco2.SetActive(true);
        optionTaco2.transform.position = this.transform.position;
        optionTaco3.SetActive(false);
    }
    void OptionUnitActive4()
    {
        optionTaco0.SetActive(true);
        optionTaco1.SetActive(true);
        optionTaco2.SetActive(true);
        optionTaco3.SetActive(true);
        optionTaco3.transform.position = this.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OptionActive();  //�ɼ����� ���� �Լ� (���� = ������ 'O')
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            WeaponChange();  //���� ���� �Լ� (���� = ������ 'I(�빮�� ����)')
        }

        FireBullet();    //�Ѿ� ���� �Լ� (���� = ������ 'K')
        AutoFireBullet();//�Ѿ� �ڵ� �߻� �Լ� (���� = ';')
        FireSubWeapon(); //������� ���� �Լ� (���� = ������ 'L')

        if (Input.GetKeyDown(KeyCode.B))
        {
            BarrierActive(); //��ȣ�� ���� �Լ� (���� = ������ 'B')
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            ActiveSubWeapon();   //������� Ȱ��ȭ �Լ� (���� = ������ 'N')
        }

    }

    public void OptionActive()  //�ɼ����� ���� �Լ� (���� = ������ 'O')
    {
        if (optionNo < 5)
        {
            optionNo++;
            OptionPlus(optionNo);  //�ɼ� �߰� ���� �Լ�
        }
        else if (optionNo == 5)
        {
            optionNo = 0;
        }
        //optionNo = (optionNo + 1) % 5;
        //OptionPlus(optionNo);
    }

    public void OptionPlus(int num)  //�ɼ��� �߰� �� ����
    {
        switch (num)
        {
            case 0:
                OptionUnitRemove();
                break;
            case 1:
                OptionUnitActive1();
                break;
            case 2:
                OptionUnitActive2();
                break;
            case 3:
                OptionUnitActive3();
                break;

            case 4:
                OptionUnitActive4();
                break;

        }
    }

    public void WeaponChange()   //���� ���� �Լ� (���� = ������ 'I(�빮�� ����)')
    {
        if (weaponType < 3)
        {
            weaponType++;
            if (weaponType == 3)
            {
                weaponType = 0;
            }
        }
    }

    void FireBullet()    //�Ѿ� ���� �Լ� (���� = ������ 'K')
    {
        fireTime += Time.deltaTime;
        if (fireTime > fireDelay)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                switch (weaponType)
                {
                    case 0:
                        Fire0();
                        break;

                    case 1:
                        Fire1();
                        break;
                    case 2:
                        Fire2();
                        break;

                }
                fireTime = 0;
            }

        }
    }

    void AutoFireBullet()
    {

        if (Input.GetKey(KeyCode.Semicolon))
        {
            fireTime += Time.deltaTime;
            if (fireTime > fireDelay)
            {
                switch (weaponType)
                {
                    case 0:
                        Fire0();
                        break;

                    case 1:
                        Fire1();
                        break;
                    case 2:
                        Fire2();
                        break;

                }
                fireTime = 0;
            }

        }
    }
    void Fire0()   //�⺻ �Ѿ� ���� �Լ�
    {

        //textBulletCount.text = "" + bulletCount.ToString("00");
        objBullet = objPoolingMgr.MakeObj(bullets[weaponType]);
        objBullet.transform.position = firePos.position;
    }
    void Fire1()   //���� �Ѿ� ���� �Լ�
    {

        //textBulletCount.text = "" + bulletCount.ToString("00");
        objBullet = objPoolingMgr.MakeObj(bullets[weaponType - 1]);
        objBullet.transform.position = firePos.position;
        objBullet = objPoolingMgr.MakeObj(bullets[weaponType]);
        objBullet.transform.position = firePos.position;
    }
    void Fire2()    //Spread �Ѿ� ���� �Լ�
    {

        //textBulletCount.text = "" + bulletCount.ToString("00");
        objBullet = objPoolingMgr.MakeObj(bullets[weaponType]);
        objBullet.transform.position = firePos.position;
    }

    void FireSubWeapon()   //������� ���� �Լ� (���� = ������ 'L')
    {
        if (isSubweapon == true)
        {
            subFireTime += Time.deltaTime;
            if (subFireTime > subFireDelay)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    objBullet = objPoolingMgr.MakeObj(subWeapons[0]);
                    objBullet.transform.position = firePos.position;
                    objBullet = objPoolingMgr.MakeObj(subWeapons[1]);
                    objBullet.transform.position = firePos.position;
                    subFireTime = 0;
                }
            }
        }
    }

    public void BarrierActive()
    {
        if (isBarrier == false)
        {
            isBarrier = true;
            //tacoBarrier.SetActive(true);
            Instantiate(tacoBarrier, firePos.position, Quaternion.identity);
        }
    }

    public void BarrierFalse(bool active)
    {
        isBarrier = active;
    }
    public void ActiveSubWeapon()
    {
        isSubweapon = true;
    }
}
