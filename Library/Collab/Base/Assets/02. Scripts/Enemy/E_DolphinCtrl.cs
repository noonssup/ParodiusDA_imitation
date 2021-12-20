using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_DolphinCtrl : MonoBehaviour, IDamage
{
    /*
        public Rigidbody2D _rigidbody;
        public float dolphinSpeed;
        public float dolphinDegree;

        Vector3 curPos;
        Vector3 targetPos;
        Vector3 beforePos;

        void Start()
        {
            enemyHp = 1;
            dolphinSpeed = 10.0f;
            targetPos = new Vector3(3.9f, -3.6f, 0);

            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = targetPos * dolphinSpeed * Time.deltaTime;

            float radian= dolphinDegree * Mathf.PI / 180;   //������ �������� ��ȯ
            Vector2 radianToVector = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

            _rigidbody.AddForce(radianToVector * dolphinSpeed * 100);
            beforePos = transform.position;
        }

        private void FixedUpdate()
        {

            float angle = Mathf.Atan2(_rigidbody.position.y, _rigidbody.position.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
            _rigidbody.AddForce(transform.forward);

        }

        void Update()
        {
            if (beforePos != curPos) // �������Ӱ� ���������� ��ǥ�� �ٸ��� Ȯ���մϴ�.
            {
                Vector3 directionVec = curPos - beforePos;  //���� �����Ӱ� ���������� ���̷� ���⺤�͸� ���մϴ�.

                float radian = Mathf.Atan2(directionVec.y, directionVec.x);     // ���⺤�� -> ���� -> ����(degree) ������ ��ȯ�մϴ�.
                float degree = radian * 180 / Mathf.PI;

                transform.eulerAngles = new Vector3(0, 0, degree);  // ������ �����մϴ�.

                beforePos = curPos;     //����������ǥ�� �����մϴ�.
            }
        }

        void dolphinMove()
        { }


    Rigidbody2D rb2d;
    public float launchPower = 5f;
    public float launchDegree = 30f;
    Vector3 beforePos;//�� �������� ������ ����
    Vector3 pos;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //����(degree)�� ����(radian)���� ��ȯ�մϴ�.
        float radian = launchDegree * Mathf.PI / 180;

        //������ �������ͷ� ��ȯ�մϴ�.
        Vector2 radianToVector2 = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

        //AddForce
        rb2d.AddForce(radianToVector2 * launchPower * 100);

        //�� ������ ��ǥ �ʱ�ȭ
        beforePos = transform.position;
    }

    void Update()
    {
        pos = gameObject.transform.position;

        if (beforePos != pos) // �������Ӱ� ���������� ��ǥ�� �ٸ��� Ȯ���մϴ�.
        {
            //���� �����Ӱ� ���������� ���̷� ���⺤�͸� ���մϴ�.
            Vector3 directionVec = pos - beforePos;

            // ���⺤�� -> ���� -> ����(degree) ������ ��ȯ�մϴ�.
            float radian = Mathf.Atan2(directionVec.y, directionVec.x);
            float degree = radian * 180 / Mathf.PI;

            // ������ �����մϴ�.
            transform.eulerAngles = new Vector3(0, 0, degree);

            //����������ǥ�� �����մϴ�.
            beforePos = pos;
        }
    }
    */

    public int enemyHp;
    public float dolphinSpeed;

    public Vector3 targetPos;

    void Start()
    {
        targetPos = new Vector3(6.5f, -1f, 0);
        dolphinSpeed = 3f;
    }

    void Update()
    {
        DolphinMove();

        if (gameObject.transform.position.x < -9f)
            Destroy(gameObject);
    }

    void DolphinMove()
    { gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, targetPos, Time.deltaTime * dolphinSpeed); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Point100")
        { targetPos = new Vector3(3.9f, -6f, 0); }
        if (collision.name == "Point80")
        { targetPos = new Vector3(1.3f, -1f, 0); }
        if (collision.name == "Point60")
        { targetPos = new Vector3(-1.3f, -6f, 0); }
        if (collision.name == "Point40")
        { targetPos = new Vector3(-3.9f, -1f, 0); }
        if (collision.name == "Point20")
        { targetPos = new Vector3(-6.5f, -6f, 0); }
        if (collision.name == "Point0")
        { targetPos = new Vector3(-9.1f, -1f, 0); }
    }

    public void Damage(int playerAtkDamage)
    {
        enemyHp -= playerAtkDamage;

        if (enemyHp <= 0)
        {
            GameManager.instance.ScoreAdd(100);
            this.gameObject.SetActive(false);
        }
    }
}
