using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPenguin : MonoBehaviour, IDamage
{
    public GameObject itemPrefab;
    public GameObject destroyEff;
    Animator penguinAnim;
    Transform player;

    Vector3 dir;

    float speed;
    float downDelay;
    float penguinHp;
    float loudDelay;

    float playerX;
    float penguinX;

    int downPattern;
    int movePattern;
    bool isLive;

    public void Damage(int damage)
    {
        penguinHp -= damage;
        if (penguinHp <= 0)
        {
            GameManager.instance.ScoreAdd(100);
            float randItem = Random.Range(0, 10000);
            if (randItem < 3000)
            {
                itemPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            }
            destroyEff = Instantiate(destroyEff, this.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        downPattern = Random.Range(2, 6);
        movePattern = 0;
        isLive = true;
        speed = 2.5f;
        downDelay = 0;
        loudDelay = 0;
        penguinHp = 1;
        penguinAnim = GetComponentInChildren<Animator>();

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        playerX = player.position.x;
        penguinX = this.transform.position.x;


        switch (movePattern)
        {
            case 0:
                Right();
                break;
            case 1:
                //  Left();
                break;
            case 2:
                Move();
                break;
            case 3:
                Loud();
                loudDelay += Time.deltaTime;
                if (loudDelay > 1f)
                {
                    movePattern = 2;
                    loudDelay = 0;
                }
                break;

        }

        if (this.gameObject.transform.position.y < -5.7f)//�����ġ �ٴ� ������ �� �� ����
        {
            this.gameObject.SetActive(false);
        }

        if (isLive == true)
        {
            downDelay += Time.deltaTime;
            if (downDelay > downPattern)
            {
                penguinAnim.SetTrigger("Down");
                downDelay = 0;
            }
        }
    }

    public void Right()
    {
        dir = Vector3.right * 2;
        this.transform.rotation = Quaternion.identity;
        movePattern = 2;
    }
    //public void Left()
    //{
    //    dir = Vector3.left * 2;
    //    this.transform.rotation = Quaternion.Euler(0, 180, 0);
    //}
    public void Move()
    {
        this.transform.rotation = Quaternion.identity;
        this.transform.position += dir * speed * Time.deltaTime;
        if (playerX + 1.2f <= penguinX && penguinX <= playerX + 1.6f)
        {
            movePattern = 3;
        }
    }
    public void Loud()
    {
        penguinAnim.SetTrigger("Loud");
        this.transform.rotation = Quaternion.Euler(0, 180, 0);
        this.transform.position -= dir * 0.4f * Time.deltaTime;
    }

}
