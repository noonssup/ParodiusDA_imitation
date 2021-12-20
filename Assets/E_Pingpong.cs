using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Pingpong : MonoBehaviour, IDamage
{
    Rigidbody2D rigid;
    CapsuleCollider2D capCollider;
    Vector3 dir;
    public GameObject DestroyEff;

    int pingpongHp;
    int movePattern;

    float delay;

    bool isLanding;
    private void OnEnable()
    {
        pingpongHp = 1;
        movePattern = 1;
        isLanding = true;
        rigid = GetComponent<Rigidbody2D>();
        capCollider = GetComponent<CapsuleCollider2D>();
        dir = Vector3.right;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);

    }
    void Update()
    {
        this.transform.position += dir * 0.4f * Time.deltaTime;

        switch (movePattern)
        {
            case 0:
                if (isLanding == true)
                {
                    dir = Vector3.right;
                    rigid.AddForce(new Vector3(20, 280, 0), ForceMode2D.Force);
                    isLanding = false;
                }
                break;

            case 1:
                if (isLanding == true)
                {
                    dir = Vector3.left * 10;
                    rigid.AddForce(new Vector3(-20, 280, 0), ForceMode2D.Force);
                    isLanding = false;
                }
                break;
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        //if(collision.tag == "BGGuard")
        if (collision.tag == "SUBWEAPONTRIGGER")
        {
            rigid.velocity = Vector3.zero;
            isLanding = true;
        }
        if (collision.tag == "EnemyBlock" && movePattern == 0)
        {
            movePattern = 1;
        }
        else if (collision.tag == "EnemyBlock" && movePattern == 1)
        {
            movePattern = 0;
        }
    }


    void IDamage.Damage(int damage)
    {
        pingpongHp -= damage;
        if (pingpongHp < 1)
        {
            GameManager.instance.ScoreAdd(100);
            gameObject.SetActive(false);
            Instantiate(DestroyEff, this.transform.position, Quaternion.identity);
        }
    }

}
