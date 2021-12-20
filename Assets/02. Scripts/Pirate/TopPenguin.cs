using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPenguin : MonoBehaviour, IDamage
{
    public GameObject itemPrefab;
    public GameObject destroyEff;
    CapsuleCollider2D penguinCollider;
    Animator penguinAnim;
    Transform player;

    float Speed;
    float downDelay;//넘어지는 모션
    float penguinHp;
    float loudDelay;//울부짖는 모션딜레이

    float playerX;
    float penguinX;

    int movePattern;
    int downPattern;

    bool isLive;
    bool isTouchGuard;

    Vector3 dir;//생성시 펭귄이 움직이는 방향



    private void OnEnable()
    {
        isTouchGuard = false;
        isLive = true;
        Speed = 1f;
        downDelay = 0;
        loudDelay = 0;
        penguinHp = 1;
        movePattern = 1;
        downPattern = Random.Range(2, 5);
        penguinCollider = GetComponent<CapsuleCollider2D>();
        penguinAnim = GetComponentInChildren<Animator>();

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);
        penguinCollider.isTrigger = false;
    }

    void Update()
    {
        playerX = player.position.x;
        penguinX = this.transform.position.x;
        // this.transform.position += dir * Speed * Time.deltaTime;
        Debug.Log(movePattern);
        switch (movePattern)
        {
            case 0:
                Left();
                movePattern = 2;
                break;
            case 1:
                Right();
                movePattern = 2;
                break;
            case 2:
                MoveFromLeft();
                break;
            case 3:
                MoveFromRight();
                break;
            case 4:
                Loud();
                loudDelay += Time.deltaTime;
                if (loudDelay > 0.8f)
                {
                    movePattern = 2;
                    loudDelay = 0;
                }
                break;
        }

        if (this.gameObject.transform.position.x > 7.1f)//펭귄위치 바다 밑으로 갈 시 꺼줌
        {
            this.gameObject.SetActive(false);
        }

        //펭귄 넘어지는 모션
        if (isLive)
        {
            downDelay += Time.deltaTime;
            if (downDelay > downPattern)
            {
                //넘어지는 모션 넣어주기
                penguinAnim.SetTrigger("Down");
                downDelay = 0;
            }
        }
    }



    public void Right()//오른쪽 방향을 가진 펭귄 생성
    {
        dir = Vector3.right * 2;
        this.transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    public void Left()//왼쪽 방향을 가진 펭귄 생성
    {
        dir = Vector3.left * 2;
        this.transform.rotation = Quaternion.identity;
    }
    public void MoveFromLeft()
    {
        this.transform.position += dir * Speed * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(180, 0, 0);
        if (playerX + 1.2f <= penguinX && penguinX <= playerX + 2f)
        {
            movePattern = 4;
        }
    }
    public void MoveFromRight()
    {
        this.transform.position += dir * Speed * Time.deltaTime;
    }
    public void Loud()
    {
        penguinAnim.SetTrigger("Loud");
        this.transform.rotation = Quaternion.Euler(180, 180, 0);
        this.transform.position -= dir * 0.4f * Time.deltaTime;
    }

    public void Damage(int playerAtkDamage)
    {
        penguinHp -= playerAtkDamage;

        if (penguinHp <= 0)
        {
            GameManager.instance.ScoreAdd(100);
            float randItem = Random.Range(0, 10000);
            if (randItem < 9999)
            {
                Instantiate(destroyEff, this.transform.position, Quaternion.identity);
                Instantiate(itemPrefab, gameObject.transform.position, Quaternion.identity);
            }

            this.gameObject.SetActive(false);
        }
    }


}