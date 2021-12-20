using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public ObjPoolingMgr objManager;

    public GameObject playerTaco;    //Ÿ�� �÷��̾� ���ӿ�����Ʈ
    public GameObject playerPantarou;//��Ÿ�� �÷��̾� ���ӿ�����Ʈ
    public Vector3 startPos;

    public GameObject pantarouItemMenu;
    public GameObject tacoItemMenu;

    public string playerName; //������ �÷��̾��� �̸�
    public float timer;     //�ð��� ���� ����
    public Text textTimer;  //�ð��� ǥ���� Text ������Ʈ
    int second;  //�� ���� ����
    int minute;  //�� ���� ����

    public int playerHp;   //�÷��̾� ü��

    public Image imagePantarouHp1;   //��Ÿ�� HP �̹��� 1
    public Image imagePantarouHp2;   //��Ÿ�� HP �̹��� 2
    public Image imageTacoHp1;   //Ÿ�� HP �̹��� 1
    public Image imageTacoHp2;   //Ÿ�� HP �̹��� 2
    public Image imageItemMenuPantarou;  //��Ÿ�� �����۸޴�UI
    public Image imageItemMenuTaco;  //Ÿ�� �����۸޴�UI

    public int score;     //���� ������ ���� ����
    public int bestScore; //����Ʈ ������ ���� ����
    public Text textScore;   //���� ������ ǥ���� �ؽ�Ʈ
    public Text TextBestScore;//����Ʈ ������ ǥ���� �ؽ�Ʈ

    public Text textGameOver; //���ӿ��� �� ��� ���ӿ��� �ؽ�Ʈ

    private void Awake()
    {
        if(GameManager.instance.playerName == null)
        {
            startPos = new Vector3(-4, 0, 0);
            Instantiate(playerPantarou, startPos, Quaternion.identity);
        }
        else
        { return; }

    }
    private void OnEnable()
    {
        Time.timeScale = 1;
        ScoreLoad();
        PlayerStateSetting();  //�÷��̾� ���� ���� Ȯ��
        TimerReset();   //ȭ�鿡 ǥ�õ� Ÿ�̸� �ؽ�Ʈ ���� ���� �ʱ�ȭ
        MakePlayerCharacter();  //���õ� �÷��̾� ���� �Լ�
        ItemMenuSetting();   //ȭ�� �ϴܿ� ���� �����۸޴�UI �ʱ�ȭ �Լ�
    }

    void ScoreLoad()
    {
        if (PlayerPrefs.HasKey("HiScore"))
        {
            TextBestScore.text = PlayerPrefs.GetInt("HiScore").ToString();
        }
    }

    void PlayerStateSetting()  //�÷��̾� ���� ���� Ȯ��
    {
        playerName = GameManager.instance.playerName;
        playerHp = GameManager.instance.playerHp;
        imagePantarouHp1 = GameObject.Find("PantarouHp1").GetComponent<Image>();
        imagePantarouHp2 = GameObject.Find("PantarouHp2").GetComponent<Image>();
        imageTacoHp1 = GameObject.Find("TacoHp1").GetComponent<Image>();
        imageTacoHp2 = GameObject.Find("TacoHp2").GetComponent<Image>();
        imageItemMenuPantarou = GameObject.Find("ItemMenuPantarou1").GetComponent<Image>();
        imageItemMenuTaco = GameObject.Find("ItemMenuTaco1").GetComponent<Image>();
        textGameOver = GameObject.Find("TextGameOver").GetComponent<Text>();
        textGameOver.enabled = false;
        
    }

    void TimerReset()  //ȭ�鿡 ǥ�õǴ� �ؽ�Ʈ ���� ���� �ʱ�ȭ
    {
        timer = 0;   //�ð� �ʱ�ȭ
        second = 0;  //�ð� �ʱ�ȭ
        minute = 0;  //�ð� �ʱ�ȭ
        textTimer = GameObject.Find("TimerText").GetComponent<Text>();  //Ÿ�̸��ؽ�Ʈ ã��
    }

    void MakePlayerCharacter()   //�÷��̾� ĳ���� ���� (���� ������ ������ �÷��̾� ������Ʈ�� �ҷ���)
    {
        if (GameManager.instance.playerName == "Pantarou")
        {
            startPos = new Vector3(-4, 0, 0);
            Instantiate(playerPantarou, startPos, Quaternion.identity);
        }
        else if (GameManager.instance.playerName == "Taco")
        {
            startPos = new Vector3(-4, 0, 0);
            Instantiate(playerTaco, startPos, Quaternion.identity);
        }
    }

    void ItemMenuSetting()
    {
        if (playerName == "Pantarou")
        {
            imageItemMenuPantarou.enabled = true;
            imageItemMenuTaco.enabled = false;

        }
        else if (playerName == "Taco")
        {
            imageItemMenuTaco.enabled = true;
            imageItemMenuPantarou.enabled = false;
        }
    }

    private void Update()
    {
        TimeCount();  //�ð� ī��Ʈ �Լ�
        TimeSkip();   //Time.timeScale 2�� �������ִ� �Լ� (�׽�Ʈ�� / 0 = ������ / 9 = ����ӵ�)
        ScoreCount(); //���� ���ھ� ������Ʈ
        MakePlayerHpImage();    //���õ� �÷��̾��� Hp �̹��� ���� �Լ�
    }

    void MakePlayerHpImage()  //ȭ�鿡 ǥ�õ� �÷��̾��� Hp �̹��� ǥ��
    {
        if (playerName == "Pantarou")
        {
            imageTacoHp1.enabled = false;
            imageTacoHp2.enabled = false;
            switch (playerHp)
            {
                case 2:
                    imagePantarouHp1.enabled = true;
                    imagePantarouHp2.enabled = true;
                    break;
                case 1:
                    imagePantarouHp1.enabled = true;
                    imagePantarouHp2.enabled = false;
                    break;
                case 0:
                    imagePantarouHp1.enabled = false;
                    imagePantarouHp2.enabled = false;
                    break;
            }
        }
        else if (playerName == "Taco")
        {
            imagePantarouHp1.enabled = false;
            imagePantarouHp2.enabled = false;
            switch (playerHp)
            {
                case 2:
                    imageTacoHp1.enabled = true;
                    imageTacoHp2.enabled = true;
                    break;
                case 1:
                    imageTacoHp1.enabled = true;
                    imageTacoHp2.enabled = false;
                    break;
                case 0:
                    imageTacoHp1.enabled = false;
                    imageTacoHp2.enabled = false;
                    break;
            }
        }
    }

    public void GameOverDirection()
    {
        StartCoroutine(MoveToGameOver());
    }

    IEnumerator MoveToGameOver()
    {
        yield return new WaitForSeconds(1f);
        textGameOver.enabled = true;
        Time.timeScale = 0.001f;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = false;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = true;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = false;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = true;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = false;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = true;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = false;
        yield return new WaitForSeconds(0.001f);
        textGameOver.enabled = true;
        yield return new WaitForSeconds(0.001f);
        PlayerPrefs.SetInt("HiScore", GameManager.instance.score);
        GameManager.instance.MoveToContinueScene();
    }

    void TimeCount()   //�÷��̽ð� ī��Ʈ �Լ�
    {
        timer += Time.deltaTime;
        second = (int)timer;
        if (second > 59)
        {
            minute++;
            timer = 0;
        }
        textTimer.text = "PlayTime: " + minute.ToString("00") + ":" + second.ToString("00");
        //Debug.Log(timer);
    }

    void TimeSkip()  //�������� ���� �� �ð� ����
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Time.timeScale = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Time.timeScale = 1;
        }
    }

    void ScoreCount()
    {
        score = GameManager.instance.score;
        textScore.text = score.ToString();
    }

    public void SpreadGunBomb(Vector3 dir)  //��Ÿ���� SpreadBomb ���� ������Ʈ �ҷ�����
    {
        GameObject objBullet = objManager.MakeObj("PantarouBulletSpreadBomb");
        objBullet.transform.position = dir;
    }


}
