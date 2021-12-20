using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance = null;
    public string sceneName;
    public string playerName;
    public string controlMode;
    public int playerHp;
    public int score;
    public int bestScore;
    public int creditCount; //���� ũ���� ��
    public float bgMovePosition;

    private void Awake()
    {
        //���ӸŴ��� �ν��Ͻ�ȭ
        if (instance == null)//�̱����� �������� ���� ���
        {
            instance = this;//�ش� ������Ʈ�� �̱��� ������Ʈ�� ����
        }
        else if (instance != this)//instance�� �Ҵ�� Ŭ������ �ν��Ͻ��� �ٸ� ���
        {
            Destroy(this.gameObject);//�ߺ� ������ ���� �� ������Ʈ�� ����
        }

        DontDestroyOnLoad(gameObject);//���� ����Ǵ��� �������� �ʰ� ����


        playerName = null;
        playerHp = 2;
        score = 0;
        creditCount = 0;
        bgMovePosition = 0;
    }

    private void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;  //������ �� ���� Ȯ��
        PlayableControl();   //Ÿ��Ʋȭ�鿡�� u Ű�� ������ ĳ���� ���� ȭ������...
        PlayerStatusReset(); //�÷��̾� ���� �ʱ�ȭ
        //Debug.Log("�����ǥ" + bgMovePosition);
        MoveToEndingCredit();

        GamePause();
    }

    void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
    }
    void PlayableControl()  //�� �̵� �Լ�
    {

        if (Input.GetKeyDown(KeyCode.T))   //Ÿ��Ʋ ������ �̵�
        {
            SceneManager.LoadScene("TitleScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))  //�÷��̾� ü�� �ٿ�
        {
            playerHp = 0;  
        }
        else if (Input.GetKeyDown(KeyCode.X))   //���� Ŭ���� ������ �̵�
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }

    void PlayerStatusReset()   //���� �� �÷��̾� ���� ȭ������ ���� �̵��� ���, �÷��̾��� �̸��� HP, ������ �ʱ�ȭ
    {
        if(sceneName == "PlayerSelectScene")
        {
            playerName = null;
            playerHp = 2;
            score = 0;
        }
    }

    void MoveToEndingCredit()
    {
        if (sceneName == "GameClearScene")
        {
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SceneManager.LoadScene("EndingCreditScene");
            }
        }
        
    }

    public void ScoreAdd(int addScore)
    {
        score += addScore;
    }

    public void MoveToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void SelectPlayerName(string pName)  
        //ĳ���� ���ý� �ش� ĳ������ �̸��� �����ϰ� ���۹�� ���� ������ �̵��ϴ� �Լ�
        //ĳ���� ���� ������ ĳ���� ������ �ϸ� �����
    {
        playerName = pName;
        SceneManager.LoadScene("ControlSelectScene");
    }


    public void SelectModeName(string mode)  
        //ĳ���� ���� ������ �Ϸ��ϸ� ���� ��ŸƮ ������ �̵�
        //ĳ���� ���� ����� �����ϸ� �����
    {
        controlMode = mode;
        SceneManager.LoadScene("GameStartScene");

    }

    public void ContinueGamePlay()  //��Ƽ�� �� ĳ���� ���� ������ �̵�
    {
        creditCount--;
        SceneManager.LoadScene("PlayerSelectScene");
    }

    public void MoveToContinueScene()  //���ӿ����� �Ǹ� ����Ǵ� �Լ�, ��Ƽ������ ������ �̵�
    {
        SceneManager.LoadScene("ContinueGameScene");
        Time.timeScale = 1;
    }

    public void MoveToGameClearScene()
    {
        SceneManager.LoadScene("GameClearScene");
    }
}
