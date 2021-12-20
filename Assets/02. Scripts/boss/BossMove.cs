using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossMove : MonoBehaviour, IDamage
{
    public int bossHp; //���� ü��
    float bossSpeed;//���� �̵��ӵ�
    float hitDelay; //���� �ǰ� �� ������

    float yUp;      //���� �����̴� ���κ�
    float yDown;    //�Ʒ��� �����̴� ���κ�

    bool isBossUp; // ������ �̵����� (0 : Up, 1 : Down)
    bool isHitBoss; //���� �ǰ� ���� ����(0 : �Ұ���, 1: ����)
    public bool isBossLive; //���� ���� ����
    Vector3 bossDir = Vector3.up; //���� �⺻ ����

    Animator bossAnim; //���� (Idle, Damaged, Die)�ִϸ��̼�
    Animator navelAnim;//��� �ִϸ��̼�
    Rigidbody2D rigid; //���� ����� �״� ��ǿ� �ʿ��� ������ٵ�
    private void OnEnable()
    {
        bossHp = 15;
        bossSpeed = 3f;
        yUp = 2f;
        yDown = -2f;
        isHitBoss = true;
        isBossUp = true;
        isBossLive = true;
        isHitBoss = false;
        bossAnim = GetComponentInChildren<Animator>();
        navelAnim = GetComponentInChildren<Animator>();
        navelAnim.name = "navel";
    }
    void Update()
    {
        if (isBossLive)
        {
            if (this.transform.position.y > yUp)
            {
                isBossUp = false;
            }
            else if (this.transform.position.y < yDown)
            {
                isBossUp = true;
            }
            switch (isBossUp)
            {
                case false:
                    downMovingBoss();
                    break;
                case true:
                    UpMovingBoss();
                    break;
            }
        }
        else if (isBossLive == false)
        {
            StartCoroutine(BossDie());

            //if(this.transform.position.y < -4.44f)
            //{
            //    bossAnim.SetTrigger("WaveEff");
            //}
            if (this.transform.position.y < -13)
            {
                PlayerPrefs.SetInt("HiScore", GameManager.instance.score);
                this.gameObject.SetActive(false);
                GameManager.instance.MoveToGameClearScene();
            }
        }

        //���� Ÿ��
        if (isHitBoss == true) //�������� �������� �������� ���� ���ϰ� ����
        {
            hitDelay += Time.deltaTime;
            if (hitDelay > 1)
            {
                isHitBoss = false;
                hitDelay = 0;
            }
        }
    }

    void UpMovingBoss() //���� ���� �̵�
    {
        this.transform.position += bossDir * bossSpeed * Time.deltaTime;
    }
    void downMovingBoss()//���� �Ʒ��� �̵�
    {
        this.transform.position -= bossDir * bossSpeed * Time.deltaTime;
    }

    IEnumerator BossDie()
    {
        navelAnim.GetBool("BossDie");
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        yield return new WaitForSeconds(4f);
        BossDown();

    }
    void BossDown()
    {
        this.transform.position += Vector3.down * 5 * Time.deltaTime;
        if (this.transform.position.y < -4.44f)
        {
            bossAnim.SetTrigger("WaveEff");
        }
        //this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 2, ForceMode2D.Impulse); 
        //�����׾����� ��¦ �ö󰬴ٰ� �������� ����� �ڵ�
    }

    void IDamage.Damage(int damage)
    {
        if (isHitBoss == false)
        {
            bossHp -= damage;
            bossAnim.SetInteger("BossHp", bossHp);
            bossAnim.SetTrigger("BossDamaged");
            isHitBoss = true;
            if (bossHp <= 0)
            {
                GameManager.instance.ScoreAdd(10000);
                isBossLive = false;
            }
        }
    }
}
