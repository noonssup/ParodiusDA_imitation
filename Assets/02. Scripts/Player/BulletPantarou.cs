using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPantarou : MonoBehaviour
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
        StartCoroutine(BulletInvisible());   //�Ѿ� ������ ȿ�� ���� �Լ� (��������Ʈ �������� �ݺ� ����)

    }

    void Update()
    {
        if (bulletName == "BulletNormalPantarou(Clone)")
        {
            BulletMovingNormal();
        }
        else if (bulletName == "BulletDoublePantarou(Clone)")
        {
            BulletMovingDouble();
            //Debug.Log("����Ÿ��");
        }
        else if (bulletName == "BulletSpreadPantarou(Clone)")
        {
            BulletMovingSpread();
        }

        if (this.transform.position.x > 6.6f || this.transform.position.y > 5.6f)
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
        this.transform.position += new Vector3(1, 1, 0).normalized * moveSpeed * Time.deltaTime;
    }

    void BulletMovingSpread()
    {
        this.transform.position += new Vector3(1, 0, 0).normalized * (moveSpeed + 5) * Time.deltaTime;
    }

    IEnumerator BulletInvisible()   //�Ѿ� ������ ȿ�� ���� �Լ� (��������Ʈ �������� �ݺ� ����)
    {
        if(this.gameObject.name != "BulletSpreadPantarou(Clone)") {
            while (this.gameObject != null)
            {
                //Debug.Log("�Ѿ� ����");
                spriteRenderer.color = new Color(1, 1, 1, 0.5f);
                yield return new WaitForSeconds(0.05f);
                spriteRenderer.color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)   //�Ѿ��� ��򰡿� �ε����� ��
    {
        IDamage damage = collision.GetComponent<IDamage>();

        if (collision.tag == "NONTARGET" || collision.tag == "BGGuard")
        {

            if (this.gameObject.name == "BulletSpreadPantarou(Clone)")   //���� ������Ʈ�� ��Ÿ���� ������Ʈ���� ���, ����ȿ�� �߰�
            {
                stageMgr.SpreadGunBomb(this.transform.position);
                //this.gameObject.SetActive(false);
            }

            this.gameObject.SetActive(false);
        }

        else if (damage != null && collision.tag == "ENEMY")  //���� �ε��� ������Ʈ�� �±װ� ENEMY ���, �׸��� �ش� ������Ʈ�� damage �� ���� �ִٸ� �Լ� ����
        {
            damage.Damage(bulletDamage);


            if (this.gameObject.name == "BulletSpreadPantarou(Clone)")   //���� ������Ʈ�� ��Ÿ���� ������Ʈ���� ���, ����ȿ�� �߰�
            {
                stageMgr.SpreadGunBomb(this.transform.position);
                //this.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
    }

}

