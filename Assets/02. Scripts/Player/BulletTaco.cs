using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTaco : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    int bulletDamage;

    public StageManager stageMgr;
    PantarouFireCtrl fireCtrl;
    SpriteRenderer spriteRenderer;

    string bulletName;

    private void Awake()
    {
        bulletName = this.gameObject.name;
        fireCtrl = GetComponent<PantarouFireCtrl>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        stageMgr = GameObject.Find("StageManager").GetComponent<StageManager>();
    }
    private void OnEnable()
    {
        bulletName = this.gameObject.name;
        bulletDamage = 1;
        moveSpeed = 20;
        spriteRenderer.color = new Color(1, 1, 1, 1);


    }

    void Update()
    {
        if (bulletName == "BulletNormalTaco(Clone)")
        {
            StartCoroutine(BulletInvisible());   //�Ѿ� ������ ȿ�� ���� �Լ� (��������Ʈ �������� �ݺ� ����)
            BulletMovingNormal();
        }
        else if (bulletName == "BulletDoubleTaco(Clone)")
        {
            StartCoroutine(BulletInvisible());   //�Ѿ� ������ ȿ�� ���� �Լ� (��������Ʈ �������� �ݺ� ����)
            BulletMovingDouble();
            //Debug.Log("����Ÿ��");
        }
        else if (bulletName == "BulletRippleTaco(Clone)")
        {
            BulletMovingRipple();
        }

        if (this.transform.position.x > 6.6f || this.transform.position.x < -6.6f || this.transform.position.y > 5.6f || this.transform.position.y < -6.6f)
        {
            this.gameObject.SetActive(false);
        }
    }

    void BulletMovingNormal()
    {
        this.transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
    }

    void BulletMovingDouble()
    {
        this.transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
    }

    void BulletMovingRipple()
    {
        this.transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
    }

    IEnumerator BulletInvisible()   //�Ѿ� ������ ȿ�� ���� �Լ� (��������Ʈ �������� �ݺ� ����)
    {
        while (this.gameObject != null)
        {
            //Debug.Log("�Ѿ� ����");
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.05f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)   //�Ѿ��� ��򰡿� �ε����� ��
    {
        IDamage damage = collision.GetComponent<IDamage>();

        if (collision.tag == "NONTARGET" || collision.tag == "BGGuard")
        {
            this.gameObject.SetActive(false);

        }

        else if (damage != null && collision.tag == "ENEMY")  //���� �ε��� ������Ʈ�� �±װ� ENEMY ���, �׸��� �ش� ������Ʈ�� damage �� ���� �ִٸ� �Լ� ����
        {
            damage.Damage(bulletDamage);

            //if (bulletName != "BulletRippleTaco(Clone)")
            //{
                this.gameObject.SetActive(false);
            //}
        }





        //if (collision.tag == "NONTARGET")
        //{
        //    //this.gameObject.SetActive(false);
        //}
        //else
        //{
        //    if (damage != null && collision.tag == "ENEMY")
        //    {
        //        damage.Damage(bulletDamage);

        //        //this.gameObject.SetActive(false);
        //    }
        //}

    }

}

