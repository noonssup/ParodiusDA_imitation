using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTaco : MonoBehaviour
{
    public ObjPoolingMgr objPoolingMgr;  //������Ʈ Ǯ�� �Ŵ���
    public TacoFireCtrl tacoFireCtrl;
    public Transform target0;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform firePos;  //�Ѿ� �߻� ��ġ

    public string[] bullets;
    public string[] subWeapons;
    public bool isSubweapon;   //������� Ȱ��ȭ ����

    float fireDelay;
    float fireTime;
    float subFireTime;
    float subFireDelay;

    [SerializeField] float dampSpeed;
    public PlayerMove tacoMove;   //Ÿ���� �̵� ��ũ��Ʈ �Ҵ� (�ɼ��� ������ ������ ���� �ʿ�)
    public Animator anim;
    GameObject objBullet;

    int weaponType;

    private void Awake()
    {
        objPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        tacoFireCtrl = GameObject.Find("Taco(Clone)").GetComponent<TacoFireCtrl>();
        tacoMove = GameObject.Find("Taco(Clone)").GetComponent<PlayerMove>();
        bullets = new string[] { "BulletNormalTaco", "BulletDoubleTaco", "BulletRippleTaco" };
        subWeapons = new string[] { "TacoBulletUpTwoWay", "TacoBulletDownTwoWay" };
        weaponType = 0;
        fireTime = 0;
        subFireTime = 0;
        fireDelay = 0.3f;
        subFireDelay = 0.5f;
        dampSpeed = 10;
        anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        TargetControl();  //�ɼ����ֺ� �̵� ��ġ Ÿ�� ����
    }

    void TargetControl()  //�ɼ����ֺ� �̵� ��ġ Ÿ�� ����
    {
        if (GameObject.Find("Taco(Clone)") != null)
        {
            target0 = GameObject.Find("Taco(Clone)").GetComponent<Transform>();
        }

        if (GameObject.Find("OptionTaco0(Clone)") != null)
        {
            target1 = GameObject.Find("OptionTaco0(Clone)").GetComponent<Transform>();
        }

        if (GameObject.Find("OptionTaco1(Clone)") != null)
        {
            target2 = GameObject.Find("OptionTaco1(Clone)").GetComponent<Transform>();
        }

        if (GameObject.Find("OptionTaco2(Clone)") != null)
        {
            target3 = GameObject.Find("OptionTaco2(Clone)").GetComponent<Transform>();
        }
    }

    void Update()
    {
        weaponType = tacoFireCtrl.weaponType;
        isSubweapon = tacoFireCtrl.isSubweapon;

        MoveDirSetting(); //Ÿ���� ���� �̵�
        MovingAnim();    //���Ʒ� �̵��� ���� �ִϸ��̼� ����
        FireBullet();    //�Ѿ� ���� �Լ� (���� = ������ 'K')
        AutoFireBullet();//�Ѿ� �ڵ� �߻� �Լ� (���� = ';')
        FireSubWeapon(); //������� ���� �Լ� (���� = ������ 'L')
    }

    void MoveDirSetting()  //�÷��̾� Ÿ�ڸ� ���� ���� �Լ�
    {
        if ((int)tacoMove.v != 0 || (int)tacoMove.h != 0)  //�÷��̾� Ÿ�ڰ� ������ ��쿡�� ������ ���� �̵� (Ÿ�ڰ� ������ ��� �� �ڸ����� ����)
        {
            if (this.gameObject.name == "OptionTaco0(Clone)")
            {
                Vector3 newPos = target0.position + new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);

            }
            else if (this.gameObject.name == "OptionTaco1(Clone)")
            {

                Vector3 newPos = target1.position + new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);

            }
            else if (this.gameObject.name == "OptionTaco2(Clone)")
            {

                Vector3 newPos = target2.position + new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);

            }
            else if (this.gameObject.name == "OptionTaco3(Clone)")
            {

                Vector3 newPos = target3.position + new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);

            }
        }
    }

    void MovingAnim()   //���Ʒ� �����ӿ� ���� �ִϸ��̼� ����
    {
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Vertical") || Input.GetButtonUp("Vertical"))
        {
            anim.SetInteger("Input", (int)v);
        }
    }

    void FireBullet()   //�Ѿ� ���� �Լ�
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

    void AutoFireBullet()  //�������̾�
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
    void Fire2()    //Ripple �Ѿ� ���� �Լ�
    {

        //textBulletCount.text = "" + bulletCount.ToString("00");
        objBullet = objPoolingMgr.MakeObj(bullets[weaponType]);
        objBullet.transform.position = firePos.position;
    }

    void FireSubWeapon()  //������� ��� �Լ�
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

    //�ɼ� ������ �þ ���, 2��°������ ������ ������ �ɼ������� ����ٳ���ϴµ�...
    //�ɼ��� �ϳ� ������ ������ �ش� �ɼ����ֿ� ��ȣ�� �ο��ϰ�, �ɼ������� ������ �� �ش� ������ Ȱ��ȭ�� �ɼ������� ���� ���
    //�ش� ������ ���ڸ� Ȯ���Ͽ� ������ ������ �ڿ� �پ� �ٴѴ�
    //���� ��� �ɼ� ������ ���� 2�Ⱑ �ִٸ�, �ش� �ɼ����ֵ��� 0, 1 �Ǵ� 1, 2 �� ��ȣ�� �ο��ϰ� 3��° ������ 1~2��° ������ ���縦 Ȯ���� �Ŀ� �ڽſ��� 2 �Ǵ� 3 ��ȣ�� �ο��ϰ�
    //�ٷ� �� ��ȣ ������ ��ġ�� �Ҵ� ���� �Ŀ� �������� �����Ѵ�
    //20210912, 22:28�� �ۼ� (�� �ּ��� �� ������ ������ �Ŀ� ������ ��)
    //20210914, 15:00�� �ۼ� (�� �ּ��� �����Ϸ��� ������ ���� ����� �ٲ㼭 ����� ���ܺ�)
    //�÷��̾� ���� �ÿ� �ɼ��� �̸� ������ ��, setactive(false) �� �����д�, ���� �ɼ��� �����Ҷ����� �ɼ������� ���� �þ(true), ���� ������Ʈ�� ��ġ�� �÷��̾� ���� ��ÿ� �̸� �Ҵ����־���
}
