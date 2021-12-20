using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public string sceneName;  //�� �̸��� ���� string ����
    public string playerName;  //���� ������ ���õ� �÷��̾���� ������ ����
    public int playerHp;      //�÷��̾�HP �̹��� ǥ�ø� ���� ����

    public Image imagePantarouHp1;   //��Ÿ�� HP �̹��� 1
    public Image imagePantarouHp2;   //��Ÿ�� HP �̹��� 2
    public Image imageTacoHp1;   //Ÿ�� HP �̹��� 1
    public Image imageTacoHp2;   //Ÿ�� HP �̹��� 2

    public int score;     //���� ������ ���� ����
    public int bestScore; //����Ʈ ������ ���� ����
    public Text textScore;   //���� ������ ǥ���� �ؽ�Ʈ
    public Text TextBestScore;//����Ʈ ������ ǥ���� �ؽ�Ʈ

    public GameObject pantarouItemMenu;
    public GameObject tacoItemMenu;




    private void OnEnable()
    {
        PlayerStatusSetting();  //�÷��̾� ���� ���� �Ҵ�
        ItemMenuSetting();  //������ ĳ���Ϳ� ���� ȭ�� �ϴ��� ������ �̹��� ����
        ScoreLoad();
    }

    void ScoreLoad()
    {
        if (PlayerPrefs.HasKey("HiScore"))
        {
            TextBestScore.text = PlayerPrefs.GetInt("HiScore").ToString();
        }
    }

    void PlayerStatusSetting()
    {
        sceneName = SceneManager.GetActiveScene().name;  //�� �̸� �Ҵ� (�̰� ���� ���� �ֳ�???)
        playerHp = GameManager.instance.playerHp;        //�÷��̾�HP �Ҵ� (ȭ�鿡 ���� HP ǥ���� ��)
        playerName = GameManager.instance.playerName;    //�÷��̾�ĳ���� �̸��� ���� ����
        score = GameManager.instance.score;              //���� ���� (���� ���� �ô� 0, �÷��� �߿��� ������ ������)
        bestScore = GameManager.instance.bestScore;      //����Ʈ ����
        imagePantarouHp1 = GameObject.Find("PantarouHp1").GetComponent<Image>();
        imagePantarouHp2 = GameObject.Find("PantarouHp2").GetComponent<Image>();
        imageTacoHp1 = GameObject.Find("TacoHp1").GetComponent<Image>();
        imageTacoHp2 = GameObject.Find("TacoHp2").GetComponent<Image>();

    }

    void ItemMenuSetting()
    {
        if(playerName == "Pantarou")
        {
            Instantiate(pantarouItemMenu, new Vector3(0, -4.64f, 0), Quaternion.identity);
        }
        else if (playerName == "Taco")
        {
            Instantiate(tacoItemMenu, new Vector3(0, -4.64f, 0), Quaternion.identity);
        }
    }


    private void Update()
    {
        ChangeToGamePlayScene();  //���ӽ��� �� �̵� �Լ�
        ScoreStateUpdate();       //���� ���ھ� ���� �Լ�
        MakePlayerHpImage();  //���� �÷��̾��� ������ ���� HP �̹��� ������ ������ �Լ�
    }

    void ChangeToGamePlayScene()  // YŰ�� ������ ���ӽ��� ������ �̵�
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("Stage01_SHJ");
        }
    }

    void ScoreStateUpdate()
    {
        score = GameManager.instance.score;
        textScore.text = score.ToString();
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

}
