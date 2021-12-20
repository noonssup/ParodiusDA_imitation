using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;     //�÷��̾� �̵� �ӵ�
    public float h, v;          //�÷��̾� �����¿� �̵�
    bool isHitPlayer;    //�÷��̾� �ǰ� ���� ����

    public GameObject speedUpEffect;

    
    Animator anim;

    // StageManager stageMgr;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        speedUpEffect = this.gameObject.GetComponent<PlayerMove>().speedUpEffect;

    }

    private void OnEnable()
    {
        this.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        moveSpeed = 5f;     //�÷��̾� �̵� �ӵ� 5f�� �ʱ�ȭ
        isHitPlayer = true; //���� ���� �� �÷��̾� �ǰ� �����ϵ��� isHitPlayer Ȱ��ȭ
    }

    private void Update()
    {
        if (this.gameObject != null) //�÷��̾� ������Ʈ�� ȭ�鿡 ������ ��쿡�� ���� ����
        {
            MovingPlayer(); //�÷��̾� ���� �Լ�
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            MoveSpeedUp();       //���ǵ�� ���� �Լ� (���� = ������ 'H');
        }
    }

    void MovingPlayer()  //�÷��̾� ����
    {
        h = Input.GetAxisRaw("Horizontal");   //�¿� ���� (A, D, <-, ->)
        v = Input.GetAxisRaw("Vertical");     //���� ���� (W, S, ��, ��)

        Vector3 movement = new Vector3(h, v, 0);
        this.transform.position += movement * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Vertical") || Input.GetButtonUp("Vertical"))
        {
            anim.SetInteger("Input0", (int)v);
        }

    }

    public void MoveSpeedUp()     //���ǵ�� ���� �Լ� (���� = ������ 'H' / F Ű �Է� �� �ӵ� �ʱ�ȭ)
    {

        if (moveSpeed < 7.5f)
        {
            Instantiate(speedUpEffect, this.transform.position, Quaternion.identity);
            moveSpeed += 0.5f;
        }


        if (Input.GetKeyDown(KeyCode.F))  //�÷��̾� �̵� �ӵ� �ʱ�ȭ
        {
            moveSpeed = 5f;     //�÷��̾� �̵� �ӵ� 5f�� �ʱ�ȭ
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IDamage damage = collision.GetComponent<IDamage>();

        if (collision.tag == "ENEMY" || collision.tag == "ENEMYBULLET" || collision.tag == "BGGuard")
        {
            moveSpeed = 0;
            isHitPlayer = false;
        }
    }


}
