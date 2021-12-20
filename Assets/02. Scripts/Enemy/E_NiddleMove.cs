using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_NiddleMove : MonoBehaviour, IDamage
{
    public Animator NiddleAnim;
    public int enemyHp;
    public float E_moveSpeed;
    public float delayTime;

    public GameObject ItemPrefeb;
    public GameObject destroyEff;
    public Transform Player;

    public Transform target;

    public Vector2 contactPoint;

    Vector3 towardPoint;
    Vector3 dir;

    private void OnEnable()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        NiddleAnim = GetComponentInChildren<Animator>();
        E_moveSpeed = 5f;
        delayTime = 3f;
        enemyHp = 0;

        towardPoint = new Vector3(-13f, gameObject.transform.position.y, 0);
        dir = Player.transform.position - gameObject.transform.position;
    }

    void Update()
    {
        ENiddleMove();
        dir = Player.transform.position - gameObject.transform.position;

        if (gameObject.transform.position.x < -12f) //ȭ�� ���� ����� �� ����
            Destroy(gameObject);
    }

    void ENiddleMove()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, towardPoint, E_moveSpeed * Time.deltaTime);
        if (gameObject.transform.position.x < -6.4f)
            towardPoint.x = -13f;
    }

    void ENiddleRotate()
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle < -90)
        { angle = angle + 180; }
        else if(angle > 90)
        { angle = angle - 180; }
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision) //Point�� ����ĥ �� ���� Y�� ����
    {
        if (collision.name == "Point80")    //80%����
        {
            if (gameObject.transform.position.y > Player.transform.position.y)  //���� Y���� �� ������
            {   
                //�÷��̾��� ��ġ�� ���� Y�� ����
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(1.3f, gameObject.transform.position.y - (gameObject.transform.position.y - Player.transform.position.y), 0);
            }
            else if(gameObject.transform.position.y < Player.transform.position.y)  //���� Y���� �� ������
            {
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(1.3f, gameObject.transform.position.y + (Player.transform.position.y - gameObject.transform.position.y), 0);
            }
        }

        if (collision.name == "Point60")    //60%����
        {
            if (gameObject.transform.position.y > Player.transform.position.y)  //���� Y���� �� ������
            {
                //�÷��̾��� ��ġ�� ���� Y�� ����
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(-1.3f, gameObject.transform.position.y - (gameObject.transform.position.y - Player.transform.position.y), 0);
            }
            else if (gameObject.transform.position.y < Player.transform.position.y)  //���� Y���� �� ������
            {
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(-1.3f, gameObject.transform.position.y + (Player.transform.position.y - gameObject.transform.position.y), 0);
            }
        }

        if (collision.name == "Point40")    //40%����
        {
            if (gameObject.transform.position.y > Player.transform.position.y)  //���� Y���� �� ������
            {
                //�÷��̾��� ��ġ�� ���� Y�� ����
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(-3.9f, gameObject.transform.position.y - (gameObject.transform.position.y - Player.transform.position.y), 0);
            }
            else if (gameObject.transform.position.y < Player.transform.position.y)  //���� Y���� �� ������
            {
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(-3.9f, gameObject.transform.position.y + (Player.transform.position.y - gameObject.transform.position.y), 0);
            }
        }

        if (collision.name == "Point20")    //20%����
        {
            if (gameObject.transform.position.y > Player.transform.position.y)  //���� Y���� �� ������
            {
                //�÷��̾��� ��ġ�� ���� Y�� ����
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(-6.5f, Player.transform.position.y, 0);
            }
            else if (gameObject.transform.position.y < Player.transform.position.y)  //���� Y���� �� ������
            {
                new WaitForSeconds(delayTime);
                towardPoint = new Vector3(-6.5f, Player.transform.position.y, 0);
            }
        }

        if (gameObject.transform.position.x > Player.transform.position.x)  //�÷��̾� �տ� ���� ���� ��
        { ENiddleRotate(); }
        
        else                                //�÷��̾�� �ڿ� ������
        {
            dir = Vector3.zero;
            ENiddleRotate();
        }

        if (collision.tag == "Player")
        {
            Debug.Log("Collision with Emple");
            towardPoint.x = -13f;
            Destroy(gameObject);
        }

        contactPoint = collision.ClosestPoint(collision.transform.position);
    }

    public void Damage(int playerAtkDamage)   //�÷��̾� �Ѿ˿� �¾��� �� ����� �Լ�  / IDamage �������̽��� ���� �Ѿ� �ǰݿ� ���� ������ ����
    {
        enemyHp -= playerAtkDamage;

        if (enemyHp <= 0)
        {

            Instantiate(destroyEff, this.transform.position, Quaternion.identity);
            GameManager.instance.ScoreAdd(100);

            if (NiddleAnim.name == "ImageRedSyringe")
                Instantiate(ItemPrefeb, contactPoint, Quaternion.identity);

            this.gameObject.SetActive(false);
        }
    }
}
