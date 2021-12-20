using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public int creditCount;
    public Text textInformation;
    public Text textCreditCount;
    public SpriteRenderer pleaseInsertCoin;
    public SpriteRenderer pleaseGameStart;

    private void Awake()
    {
        textInformation = GameObject.Find("ControlInformation").GetComponent<Text>();
        textCreditCount = GameObject.Find("CreditCount").GetComponent<Text>();
        pleaseInsertCoin = GameObject.Find("ImageTitle1").GetComponent<SpriteRenderer>();
        pleaseGameStart = GameObject.Find("ImageTitle2").GetComponent<SpriteRenderer>();

    }
    private void OnEnable()
    {
        textInformation.text = "C Ű�� ������ ������ ���Ե˴ϴ�.";        
    }
    private void Update()
    {
        creditCount = GameManager.instance.creditCount;  //���ӸŴ������� ũ���� ���� ȣ��
        textCreditCount.text = creditCount.ToString();   //ȣ���� ũ���� ������ �ؽ�Ʈ�� ǥ��
        InsertCoin();   //������ ���Ե��� �ʾ��� �� ����� �Լ�
        BeginGame();    //������ ���Ե� �� ���ӽ����� ���� ����� �Լ�
        TitleViewChange();   //���� ���� ���ο� ���� ȭ���� �̹��� ���� (�����־�� / ���ӽ�ŸƮ�ض�... �� ���� ����ȭ��)
    }

    void InsertCoin()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.instance.creditCount++;
            creditCount = GameManager.instance.creditCount;
        }
    }

    void BeginGame()
    {
        if(creditCount > 0)
        {
            textInformation.text = "U Ű�� ������ ������ ���۵˴ϴ�.";
            if (Input.GetKeyDown(KeyCode.U))
            {
                GameManager.instance.creditCount--;
                SceneManager.LoadScene("PlayerSelectScene");
            }
        }
        else if(creditCount <= 0)
        {
            textInformation.text = "C Ű�� ������ ������ ���Ե˴ϴ�.";
            if (Input.GetKeyDown(KeyCode.U))
            {
                textInformation.text = "CŰ�� ���� ������ �־��ּ���.";
            }
        }
    }

    void TitleViewChange()
    {
        if (creditCount <= 0)
        {
            pleaseInsertCoin.enabled = true;
            pleaseGameStart.enabled = false;
        }
        else if (creditCount > 0)
        {
            pleaseInsertCoin.enabled = false;
            pleaseGameStart.enabled = true;
        }
    }
}
