using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ChickCtrl : MonoBehaviour, IDamage
{
    public GameObject Player;
    public GameObject destroyEff;

    public float chickSpeed;
    public int enemyHp;

    Vector3 towardPoint;

    float randY;

    public MonsterManager monsterManager;

    void Start()
    {
        enemyHp = 1;
        chickSpeed = 5.0f;
        towardPoint = new Vector3(-13f, gameObject.transform.position.y, 0);

        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        Debug.Log("randY : " + randY);
    }

    void Update()
    {
        randY = monsterManager.babychickRandY;

        if (gameObject.transform.position.x < -12f) //ȭ�� ���� ����� �� ����
            Destroy(gameObject);

        ChickMove();
    }

    void ChickMove()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, towardPoint, chickSpeed * Time.deltaTime);

        if (gameObject.transform.position.x < -6.4f)
            towardPoint.x = -13f;
    }

    private void OnTriggerEnter2D(Collider2D collision) //Point�� ����ĥ �� ���� Y�� ����
    {
        if (collision.name == "Point100")
        {
            if (randY > 0)
                towardPoint = new Vector3(3.9f, randY - 2f, 0);
            else
                towardPoint = new Vector3(3.9f, randY + 2f, 0);
        }

        if (collision.name == "Point80")    //80%����
        { towardPoint = new Vector3(1.3f, randY, 0); }

        if (collision.name == "Point60")    //60%����
        {
            if (randY > 0)
                towardPoint = new Vector3(-1.3f, randY - 2f, 0);
            else
                towardPoint = new Vector3(-1.3f, randY + 2f, 0);
        }

        if (collision.name == "Point40")    //40%����
        { towardPoint = new Vector3(-3.9f, randY, 0); }

        if (collision.name == "Point20")    //20%����
        {
            if (randY > 0)
                towardPoint = new Vector3(-6.5f, randY - 2f, 0);
            else
                towardPoint = new Vector3(-6.5f, randY + 2f, 0);
        }

        if (collision.tag == "Player")
        {
            Debug.Log("Collision with Chick");
            Destroy(gameObject);
        }
    }

    public void Damage(int playerAtkDamage)   //�÷��̾� �Ѿ˿� �¾��� �� ����� �Լ�  / IDamage �������̽��� ���� �Ѿ� �ǰݿ� ���� ������ ����
    {
        enemyHp -= playerAtkDamage;

        if (enemyHp <= 0)
        {
            Instantiate(destroyEff, this.transform.position, Quaternion.identity);
            GameManager.instance.ScoreAdd(100);
            this.gameObject.SetActive(false);
        }

    }
}
