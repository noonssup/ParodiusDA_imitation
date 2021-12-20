using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueGameManager : MonoBehaviour
{
    public Text textCreditCount;
    public Text textCreditText;
    public int creditCount;
    public Text textContinueMent;

    public Image countContinue;

    float countChange = 10f;   //�ð��� ���� ����

    private void OnEnable()
    {
        TextObjectSetting();      //�ؽ�Ʈ ������Ʈ �ʱ�ȭ
    }

    void TextObjectSetting()
    {
        textCreditCount = GameObject.Find("CreditCount").GetComponent<Text>();
        textCreditText = GameObject.Find("CreditText").GetComponent<Text>();
        textContinueMent = GameObject.Find("ContinueMent").GetComponent<Text>();
        textCreditText.text = "CREDIT";
        textContinueMent.text = "������ �ٽ� �����Ϸ��� ������ �־��ּ���\n(C Ű�� ������ CREDIT �� �ö󰩴ϴ�)";
    }

    private void Update()
    {
        CurCredit();    //���� ���μ� Ȯ��
        ContinueGame();  //��Ƽ�� ���� �Լ�
    }

    void CurCredit()  //���� ���� Ȯ�� �� ���� �ؽ�Ʈ ǥ��
    {
        creditCount = GameManager.instance.creditCount;
        textCreditCount.text = creditCount.ToString();
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.instance.creditCount++;
        }
    }

    void ContinueGame()
    {

        ChangeCountImage();   //�ð��� �帧�� ���� ��Ƽ��ī��Ʈ ���ڰ� �پ��
        if (creditCount > 0)
        {
            textContinueMent.text = "U Ű�� ������ ĳ���� ���� ȭ������ ���ư��ϴ�";
            if (Input.GetKeyDown(KeyCode.U))  //ũ������ ���� ��� U Ű�� ������ ����������(Stage01_SHJ) ȣ��
            {
                GameManager.instance.ContinueGamePlay();
            }
        }
    }

    void ChangeCountImage()
    {
        string fileName = "Continue/ContinueNum";
        countChange -= Time.deltaTime;
        switch ((int)countChange)
        {
            case 9:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 9);
                break;
            case 8:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 8);
                break;
            case 7:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 7);
                break;
            case 6:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 6);
                break;
            case 5:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 5);
                break;
            case 4:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 4);
                break;
            case 3:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 3);
                break;
            case 2:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 2);
                break;
            case 1:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 1);
                break;
            case 0:
                countContinue.sprite = Resources.Load<Sprite>(fileName + 0);
                GameManager.instance.MoveToGameClearScene();
                break;
            
        }
    }
}
