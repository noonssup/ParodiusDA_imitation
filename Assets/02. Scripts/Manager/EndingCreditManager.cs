using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCreditManager : MonoBehaviour
{
    public GameObject playerTaco;    //Ÿ�� �÷��̾� ���ӿ�����Ʈ
    public GameObject playerPantarou;//��Ÿ�� �÷��̾� ���ӿ�����Ʈ
    public Vector3 startPos;
    public string playerName1; //������ �÷��̾��� �̸�
    public int score;
    public float timer;
    public float resultTimer;
    int minute=0;
    int second = 0;
    public Text textScore;
    public Text textTimer;
    public Text textResult;
    public GameObject spriteCredit29;
    public GameObject spriteCredit30;

    private void Awake()
    {
        playerName1 = "Pantarou";
    }
    private void OnEnable()
    {
        if (GameManager.instance.playerName == null)
        {

            MakePlayerCharacter();
        }
        else if (GameManager.instance.playerName != null)
        {
            playerName1 = GameManager.instance.playerName;
            MakePlayerCharacter();
        }

        textResult = GameObject.Find("TextResult").GetComponent<Text>();
        textScore = GameObject.Find("TextEndingCreditScore").GetComponent<Text>();
        //spriteCredit29 = GameObject.Find("EndingCredit (29)");
        //spriteCredit30 = GameObject.Find("EndingCredit (30)");

        score = 0;
        timer = 0;
        resultTimer = 0;

        //spriteCredit29.SetActive(false);
        //spriteCredit30.SetActive(false);
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

    private void Update()
    {
        
        textScore.text = score.ToString();
        //TimeCount();
        resultTimer += Time.deltaTime;
        ResultComment();
        if(resultTimer > 100)
        {
            GameManager.instance.MoveToTitle();
        }
        ChangeTimeScale();
    }

    public void ScoreUp(int scorePoint)
    {
        score += scorePoint;
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

    void ResultComment()
    {
        if (resultTimer> 85 && score >= 1500)
        {
            textResult.text = "����... ���� �� ��������� ���� ������???\n�츮 �̸��� �ʹ� ���� �ı� ��Ű�ż�\n�ڸ��� ����� ���̴��� �ñ��ϱ��� �Ѥ�\n�ƹ�ư �츮 ���ٺ��� ������ ������� �Դϴ�\n�÷������ּż� �����մϴ�\n\nPeace";
        }
        else if (resultTimer > 85 && score < 1500)
        {
            textResult.text = "������ ���� ��ǰ�� ����ּż� ����� �����մϴ�\n���� ����� �̸��� ����� ���̰���??\n\n����� �ճ��� ����� �Բ��ϱ�...\n\nPeace";
        }
    }

    void ChangeTimeScale()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Time.timeScale++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Time.timeScale = 1;
        }
    }
}
