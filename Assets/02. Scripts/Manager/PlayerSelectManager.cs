using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectManager : MonoBehaviour
{
    public string sceneName;         //�� �̸��� ���� string ����
    public GameObject selectTaco;    //�÷��̾� ����Ʈ ������ ���� ã��
    public GameObject selectPantarou;//�÷��̾� ����Ʈ ������ ��� ã��

    public GameObject autoTaco;      //Ÿ���� ���� ����
    public GameObject manualTaco;    //Ÿ���� ���� �޴���
    public GameObject autoPantarou;  //��Ÿ���� ���� ����
    public GameObject manualPantarou;//��Ÿ���� ���� �޴���

    public string selectPlayer;      //�� ������ ���� �÷��̾�ĳ���� �̸�
    public string selectMode;        //�÷��̾� ���� ��带 ���� �̸�

    //private void Awake()
    //{
    //    sceneName = SceneManager.GetActiveScene().name;

    //    if (sceneName == "PlayerSelectScene")
    //    {
    //        selectTaco = GameObject.Find("SelectTaco");
    //        selectPantarou = GameObject.Find("SelectPantarou");
    //    }
    //    else if (sceneName == "ControlSelectScene")
    //    {
    //        selectPlayer = GameManager.instance.playerName;
    //        autoTaco = GameObject.Find("AutoTaco");
    //        manualTaco = GameObject.Find("ManualTaco");
    //        autoPantarou = GameObject.Find("AutoPantarou");
    //        manualPantarou = GameObject.Find("manualPantarou");
    //    }
    //}
    private void OnEnable()
    {
        sceneName = SceneManager.GetActiveScene().name;


        if (sceneName == "PlayerSelectScene")    //�÷��̾�ĳ���� ���� ȭ���� ��� ���õ� ĳ���� ���ӿ�����Ʈ ����
        {
            selectTaco = GameObject.Find("SelectTaco");
            selectPantarou = GameObject.Find("SelectPantarou");
            GameManager.instance.score = 0;
        }
        else if (sceneName == "ControlSelectScene") { 
            //��Ʈ�Ѽ��� ȭ���� ��� ���ӸŴ����� ������ ĳ������ �̸� ����
            //���۹���� ���� ĳ���� ���ӿ�����Ʈ ����
        
            selectPlayer = GameManager.instance.playerName;
            autoTaco = GameObject.Find("AutoTaco");
            manualTaco = GameObject.Find("ManualTaco");
            autoPantarou = GameObject.Find("AutoPantarou");
            manualPantarou = GameObject.Find("ManualPantarou");
        }

        if (sceneName == "PlayerSelectScene")
        {
            PlayerSelect();
        }
        else if(sceneName == "ControlSelectScene")
        {
            ModeSelect();
        }
    }

    void PlayerSelect() //������ �÷��̾ ���� ��������Ʈ ��ȯ
    {
        selectPlayer = "Taco";
        SelectPlayerTaco();
    }

    void ModeSelect()  //������ ĳ���Ϳ� ���� �ش� ĳ���Ϳ� �´� ���ۼ��� ȭ�� Ȱ��/��Ȱ��ȭ ó��
    {
        if (GameManager.instance.playerName == "Taco")
        {
            TacoCtrlAuto();  //Ÿ�� ���� �� ����
        }
        else if (GameManager.instance.playerName == "Pantarou")
        {
            PantarouCtrlAuto();  //��Ÿ�� ���� �� ����
        }
    }

    void SelectPlayerTaco()   //Ÿ�ڸ� ������ ��� Ÿ���� ��������Ʈ Ȱ��ȭ, ��Ÿ�� ��������Ʈ ��Ȱ��ȭ
    {
        selectTaco.GetComponent<SpriteRenderer>().enabled = true;
        selectPantarou.GetComponent<SpriteRenderer>().enabled = false;
    }

    void SelectPlayerPantarou() //��Ÿ�ΰ� ���õ� ��� ��Ÿ�� ��������Ʈ Ȱ��ȭ, Ÿ�� ��������Ʈ ��Ȱ��ȭ
    {
        selectTaco.GetComponent<SpriteRenderer>().enabled = false;
        selectPantarou.GetComponent<SpriteRenderer>().enabled = true;
    }
    private void Update()
    {
        if (sceneName == "PlayerSelectScene")  //���� ���� �÷��̾� ���� ȭ���� ���
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))   //W, S Ű�� ĳ���� ����
            {
                if (selectPlayer == "Taco")
                {
                    selectPlayer = "Pantarou";
                    SelectPlayerPantarou();
                }
                else if (selectPlayer == "Pantarou")
                {
                    selectPlayer = "Taco";
                    SelectPlayerTaco();
                }
            }

            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
            {
                //switch (selectPlayer)
                //{
                //    case "Taco":
                //        GameManager.instance.SelectPlayerName(selectPlayer);
                //        break;

                //    case "Pantarou":
                GameManager.instance.SelectPlayerName(selectPlayer);

                //        break;
                //}
            }
        }
        else if (sceneName == "ControlSelectScene")
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                if (selectMode == "AutoTaco")
                {
                    //selectMode = "ManualTaco";
                    TacoCtrlManual();
                }
                else if (selectMode == "ManualTaco")
                {
                    //selectMode = "AutoTaco";
                    TacoCtrlAuto();
                }
                else if (selectMode == "AutoPantarou")
                {
                    //selectMode = "ManualPantarou";
                    PantarouCtrlManual();
                }
                else if (selectMode == "ManualPantarou")
                {
                    //selectMode = "AutoPantarou";
                    PantarouCtrlAuto();
                }
            }

        }

        //���۹�� ���� (��� ���� �����ص� �ش� ĳ������ �޴��� �������� �����)
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            if (selectMode == "AutoTaco" || selectMode == "ManualTaco")
            {
                GameManager.instance.SelectModeName("manualTaco");
            }
            else if (selectMode == "AutoPantarou" || selectMode == "ManualPantarou")
            {
                GameManager.instance.SelectModeName("manualPantarou");
            }

        }

    }
    void TacoCtrlAuto()   //���ۼ����� ���� ��������Ʈ Ȱ��/��Ȱ��ȭ ó��
    {
        selectMode = "AutoTaco";
        autoTaco.GetComponent<SpriteRenderer>().enabled = true;
        manualTaco.GetComponent<SpriteRenderer>().enabled = false;
        autoPantarou.GetComponent<SpriteRenderer>().enabled = false;
        manualPantarou.GetComponent<SpriteRenderer>().enabled = false;
    }

    void PantarouCtrlAuto()   //���ۼ����� ���� ��������Ʈ Ȱ��/��Ȱ��ȭ ó��
    {
        selectMode = "AutoPantarou";
        autoTaco.GetComponent<SpriteRenderer>().enabled = false;
        manualTaco.GetComponent<SpriteRenderer>().enabled = false;
        autoPantarou.GetComponent<SpriteRenderer>().enabled = true;
        manualPantarou.GetComponent<SpriteRenderer>().enabled = false;
    }

    void TacoCtrlManual()   //���ۼ����� ���� ��������Ʈ Ȱ��/��Ȱ��ȭ ó��
    {
        selectMode = "ManualTaco";
        autoTaco.GetComponent<SpriteRenderer>().enabled = false;
        manualTaco.GetComponent<SpriteRenderer>().enabled = true;
        autoPantarou.GetComponent<SpriteRenderer>().enabled = false;
        manualPantarou.GetComponent<SpriteRenderer>().enabled = false;
    }

    void PantarouCtrlManual()   //���ۼ����� ���� ��������Ʈ Ȱ��/��Ȱ��ȭ ó��
    {
        selectMode = "ManualPantarou";
        autoTaco.GetComponent<SpriteRenderer>().enabled = false;
        manualTaco.GetComponent<SpriteRenderer>().enabled = false;
        autoPantarou.GetComponent<SpriteRenderer>().enabled = false;
        manualPantarou.GetComponent<SpriteRenderer>().enabled = true;
    }
}
