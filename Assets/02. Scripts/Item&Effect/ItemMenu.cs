using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour, IGetItem
{
    public Image pObjSpeedUp;   //��Ÿ�� Ȱ��ȭ ������ �̹���
    public Image pObjsubWeapon;
    public Image pObjDoubleBullet;
    public Image pObjSpBullet;
    public Image pObjOption;
    public Image pBarrier;

    public Image tObjSpeedUp;  //Ÿ�� Ȱ��ȭ ������ �̹���
    public Image tObjsubWeapon;
    public Image tObjDoubleBullet;
    public Image tObjSpBullet;
    public Image tObjOption;
    public Image tBarrier;

    public Image emptySpeedUp;  //�ش� �������� max �� ��� Ȱ��ȭ�� ��ڽ�
    public Image emptySubWeapon;
    public Image emptyDoubleBullet;
    public Image emptySpBullet;
    public Image emptyOption;
    public Image emptyBarrier;

    public Image curEmptySpeedUp; //�ش� �������� max �̸鼭 ������ ȹ������ ������ ������ �ش� �ڽ��� ��ġ�� ���
    public Image curEmptySubWeapon;
    public Image curEmptyDoubleBullet;
    public Image curEmptySpBullet;
    public Image curEmptyOption;
    public Image curEmptyBarrier;

    public PlayerMove playerMove;
    public PantarouFireCtrl pantarouFireCtrl;
    public TacoFireCtrl tacoFireCtrl;
    public int curItemSelectNo;  //������ ȹ�� �� ���� ���õǾ� �ִ� �������� ��ġ
    //0: ������ ȹ�� ��, 1:���ǵ��, 2:�������, 3/4:�Ѿ�, 5:�ɼ�, 6:������?, 7:��ȣ��

    public string playerName;

    private void OnEnable()
    {
        curItemSelectNo = 0; //���� ���� �� �����ۼ����� 0 ���� �ʱ�ȭ
        playerName = GameManager.instance.playerName;
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        pantarouFireCtrl = GameObject.FindWithTag("Player").GetComponent<PantarouFireCtrl>();
        tacoFireCtrl = GameObject.FindWithTag("Player").GetComponent<TacoFireCtrl>();
        //FireCtrlScr();  //ĳ���Ϳ� �´� ��ũ��Ʈ �Ҵ�
        ItemMenuImageSetting();  //������ �̹��� ������Ʈ �Ҵ�
        PantarouItemMenuOff();   //��Ÿ�� ���� �̹��� ��Ȱ��ȭ
        TacoItemMenuOff();       //Ÿ�� ���� �̹��� ��Ȱ��ȭ
        CommonItemMenuOff(); //ĳ���� ���� �����۸޴� ������Ʈ ��Ȱ��ȭ (max, max ���ý� Ȱ��ȭ�Ǵ� �ڽ�)
    }

    //void FireCtrlScr()
    //{
    //    if (GameObject.Find("Pantarou(Clone)").tag == "Player")
    //    {
    //        pantarouFireCtrl = GameObject.FindWithTag("Player").GetComponent<PantarouFireCtrl>();
    //        tacoFireCtrl = null;
    //    }
    //    else if (GameObject.Find("Taco(Clone)").tag == "Player")
    //    {
    //        tacoFireCtrl = GameObject.FindWithTag("Player").GetComponent<TacoFireCtrl>();
    //        pantarouFireCtrl = null;
    //    }
    //}

    void ItemMenuImageSetting()   //������ �̹��� ������Ʈ �Ҵ�
    {
        pObjSpeedUp = GameObject.Find("SpeedUpPantarou").GetComponent<Image>();
        pObjsubWeapon = GameObject.Find("SubWeaponPantarou").GetComponent<Image>();
        pObjDoubleBullet = GameObject.Find("DoubleBulletPantarou").GetComponent<Image>();
        pObjSpBullet = GameObject.Find("SpBulletPantarou").GetComponent<Image>();
        pObjOption = GameObject.Find("OptionPantarou").GetComponent<Image>();
        pBarrier = GameObject.Find("BarrierPantarou").GetComponent<Image>();

        tObjSpeedUp = GameObject.Find("SpeedUpTaco").GetComponent<Image>();
        tObjsubWeapon = GameObject.Find("SubWeaponTaco").GetComponent<Image>();
        tObjDoubleBullet = GameObject.Find("DoubleBulletTaco").GetComponent<Image>();
        tObjSpBullet = GameObject.Find("SpBulletTaco").GetComponent<Image>();
        tObjOption = GameObject.Find("OptionTaco").GetComponent<Image>();
        tBarrier = GameObject.Find("BarrierTaco").GetComponent<Image>();

        emptySpeedUp = GameObject.Find("EmptySpeedUp").GetComponent<Image>();
        emptySubWeapon = GameObject.Find("EmptySubWeapon").GetComponent<Image>();
        emptyDoubleBullet = GameObject.Find("EmptyDoubleBullet").GetComponent<Image>();
        emptySpBullet = GameObject.Find("EmptySpBullet").GetComponent<Image>();
        emptyOption = GameObject.Find("EmptyOption").GetComponent<Image>();
        emptyBarrier = GameObject.Find("EmptyBarrier").GetComponent<Image>();

        curEmptySpeedUp = GameObject.Find("CurEmptySpeedUp").GetComponent<Image>();
        curEmptySubWeapon = GameObject.Find("CurEmptySubWeapon").GetComponent<Image>();
        curEmptyDoubleBullet = GameObject.Find("CurEmptyDoubleBullet").GetComponent<Image>();
        curEmptySpBullet = GameObject.Find("CurEmptySpBullet").GetComponent<Image>();
        curEmptyOption = GameObject.Find("CurEmptyOption").GetComponent<Image>();
        curEmptyBarrier = GameObject.Find("CurEmptyBarrier").GetComponent<Image>();
    }

    void PantarouItemMenuOff()
    {
        pObjSpeedUp.enabled = false;
        pObjsubWeapon.enabled = false;
        pObjDoubleBullet.enabled = false;
        pObjSpBullet.enabled = false;
        pObjOption.enabled = false;
        pBarrier.enabled = false;
    }

    void TacoItemMenuOff()
    {
        tObjSpeedUp.enabled = false;
        tObjsubWeapon.enabled = false;
        tObjDoubleBullet.enabled = false;
        tObjSpBullet.enabled = false;
        tObjOption.enabled = false;
        tBarrier.enabled = false;


    }

    void CommonItemMenuOff()  //ĳ���� ���� �޴� ������Ʈ ��Ȱ��ȭ
    {
        emptySpeedUp.enabled = false;
        emptySubWeapon.enabled = false;
        emptyDoubleBullet.enabled = false;
        emptySpBullet.enabled = false;
        emptyOption.enabled = false;
        emptyBarrier.enabled = false;

        curEmptySpeedUp.enabled = false;
        curEmptySubWeapon.enabled = false;
        curEmptyDoubleBullet.enabled = false;
        curEmptySpBullet.enabled = false;
        curEmptyOption.enabled = false;
        curEmptyBarrier.enabled = false;
    }

    private void Update()
    {
        CharacterNameCheck();      //���õ� ĳ���� Ȯ��
        PantarouItemCurMax();      //��Ÿ�� ������ �ƽ� �� ����� �Լ�
        TacoItemCurMax();      //Ÿ�� ������ �ƽ� �� ����� �Լ�
    }

    void CharacterNameCheck()
    {
        if (playerName == "Pantarou")
        {
            ChangeItemMenuPantarou();  //������ī��Ʈ�� ���� �����۸޴� ������Ʈ Ȱ��ȭ
            TacoItemMenuOff();         //������ ��ȹ�� ����
        }
        else if (playerName == "Taco")
        {
            ChangeItemMenuTaco();  //������ī��Ʈ�� ���� �����۸޴� ������Ʈ Ȱ��ȭ
            PantarouItemMenuOff(); //������ ��ȹ�� ����
        }
    }

    void PantarouItemCurMax()
    {
        if (pantarouFireCtrl != null)
        {
            if (playerMove.moveSpeed >= 7.5f)  //���ǵ尡 �ƽ��� ��� ���ǵ�� �ؽ�Ʈ ������
            {
                emptySpeedUp.enabled = true;
            }

            if (pantarouFireCtrl.isSubweapon == true)
            {
                emptySubWeapon.enabled = true;
            }

            if (pantarouFireCtrl.weaponType == 1)
            {
                emptyDoubleBullet.enabled = true;
                emptySpBullet.enabled = false;
            }

            if (pantarouFireCtrl.weaponType == 2)
            {
                emptySpBullet.enabled = true;
                emptyDoubleBullet.enabled = false;
            }

            if (pantarouFireCtrl.optionNo == 4)
            {
                emptyOption.enabled = true;
            }


            if (pantarouFireCtrl.isBarrier == true)
            {
                emptyBarrier.enabled = true;
            }
            else if (pantarouFireCtrl.isBarrier == false)
            {
                emptyBarrier.enabled = false;
            }
        }
    }

    void TacoItemCurMax()
    {
        if (tacoFireCtrl != null)
        {
            if (playerMove.moveSpeed >= 7.5f)  //���ǵ尡 �ƽ��� ��� ���ǵ�� �ؽ�Ʈ ������
            {
                emptySpeedUp.enabled = true;
            }

            if (tacoFireCtrl.isSubweapon == true)
            {
                emptySubWeapon.enabled = true;
            }

            if (tacoFireCtrl.weaponType == 1)
            {
                emptyDoubleBullet.enabled = true;
                emptySpBullet.enabled = false;
            }

            if (tacoFireCtrl.weaponType == 2)
            {
                emptySpBullet.enabled = true;
                emptyDoubleBullet.enabled = false;
            }

            if (tacoFireCtrl.optionNo == 4)
            {
                emptyOption.enabled = true;
            }

            if (tacoFireCtrl.isBarrier == true)
            {
                emptyBarrier.enabled = true;
            }
            else if (tacoFireCtrl.isBarrier == false)
            {
                emptyBarrier.enabled = false;
            }
        }
    }


    void ChangeItemMenuPantarou()  //ȭ�� �ϴ� ������UI ���� (��Ÿ��)
    {
        switch (curItemSelectNo)
        {
            case 0:   //������ ��ȹ�� (���ӽ��� �� �ʱ�ȭ)
                PantarouItemMenuOff();
                CommonItemMenuOff();
                break;
            case 1:   //������ ȹ�� �� curItemSelectNo �� 1�� ���
                if (playerMove.moveSpeed >= 7.5f && curItemSelectNo == 1)
                {
                    curEmptySpeedUp.enabled = true;
                    emptySpeedUp.enabled = false;
                    pObjSpeedUp.enabled = false;
                    pBarrier.enabled = false;
                    curEmptyBarrier.enabled = false;
                    
                }
                else if (playerMove.moveSpeed < 7.5f && curItemSelectNo == 1)
                {
                    pObjSpeedUp.enabled = true;
                    pBarrier.enabled = false;
                    curEmptyBarrier.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        playerMove.MoveSpeedUp();
                        pObjSpeedUp.enabled = false;
                        curItemSelectNo = 0;
                    }
                }
                else if (curItemSelectNo == 1)
                {
                    pObjSpeedUp.enabled = true;
                    curEmptyBarrier.enabled = false;
                }

                    break;

            case 2:   //�����۸޴��� ��������� ���
                if(pantarouFireCtrl.isSubweapon == true && curItemSelectNo == 2)
                {
                    curEmptySubWeapon.enabled = true;
                    pObjSpeedUp.enabled = false;
                    curEmptySpeedUp.enabled = false;
                }
                else if (curItemSelectNo == 2)
                {
                    pObjsubWeapon.enabled = true;
                    pObjSpeedUp.enabled = false;
                    curEmptySpeedUp.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        pantarouFireCtrl.ActiveSubWeapon();
                        pObjsubWeapon.enabled = false;
                        emptySubWeapon.enabled = true;
                        curItemSelectNo = 0;
                    }
                }
                break;

            case 3:  //�����۸޴��� ���� �Ѿ��� ���
                if (pantarouFireCtrl.weaponType == 1 && curItemSelectNo == 3)
                {
                    curEmptySubWeapon.enabled = false;
                    pObjsubWeapon.enabled = false;
                    curEmptyDoubleBullet.enabled = true;
                }
                else if (curItemSelectNo == 3)
                {
                    pObjDoubleBullet.enabled = true;
                    curEmptySubWeapon.enabled = false;
                    pObjsubWeapon.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        pantarouFireCtrl.weaponType = 1;
                        pObjDoubleBullet.enabled = false;
                        emptySpBullet.enabled = false;
                        emptyDoubleBullet.enabled = true;
                        curItemSelectNo = 0;
                    }
                    
                }
                break;
            case 4:  //�����۸޴��� Ư�� �Ѿ��� ���
                if (pantarouFireCtrl.weaponType == 2 && curItemSelectNo == 4)
                {
                    pObjDoubleBullet.enabled = false;
                    emptyDoubleBullet.enabled = false;
                    curEmptyDoubleBullet.enabled = false;
                    curEmptySpBullet.enabled = true;
                }
                else if (curItemSelectNo == 4)
                {
                    pObjDoubleBullet.enabled = false;
                    pObjSpBullet.enabled = true;
                    curEmptyDoubleBullet.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        pantarouFireCtrl.weaponType = 2;
                        emptySpBullet.enabled = true;
                        pObjDoubleBullet.enabled = false;
                        emptyDoubleBullet.enabled = false;
                        
                        curItemSelectNo = 0;
                    }

                }
                break;
            case 5:  //�����۸޴��� �ɼ��� ���
                if (pantarouFireCtrl.optionNo == 4 && curItemSelectNo == 5)
                {
                    curEmptyOption.enabled = true;
                    pObjSpBullet.enabled = false;
                    curEmptySpBullet.enabled = false;

                }
                else if (curItemSelectNo == 5)
                {
                    pObjOption.enabled = true;
                    pObjSpBullet.enabled = false;
                    curEmptySpBullet.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        pantarouFireCtrl.OptionActive();
                        pObjOption.enabled = false;
                        curItemSelectNo = 0;
                    }
                }
                break;
            case 6:   //�����۸޴��� ��ȣ���� ���
                if (pantarouFireCtrl.isBarrier == true && curItemSelectNo == 6)
                {
                    curEmptyBarrier.enabled = true;
                    pBarrier.enabled = false;
                    pObjOption.enabled = false;
                    curEmptyOption.enabled = false;
                }
                else if (pantarouFireCtrl.isBarrier == false && curItemSelectNo == 6)
                {
                    pBarrier.enabled = true;
                    pObjOption.enabled = false;
                    curEmptyOption.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        pantarouFireCtrl.BarrierActive();
                        emptyBarrier.enabled = true;
                        pBarrier.enabled = false;
                        curItemSelectNo = 0;
                    }
                }

                break;
        }
    }

    void ChangeItemMenuTaco()  //ȭ�� �ϴ� ������UI ���� (Ÿ��)
    {
        switch (curItemSelectNo)
        {
            case 0:   //������ ��ȹ�� (���ӽ��� �� �ʱ�ȭ)
                TacoItemMenuOff();
                CommonItemMenuOff();
                break;
            case 1:   //������ ȹ�� �� curItemSelectNo �� 1�� ���
                if (playerMove.moveSpeed >= 7.5f && curItemSelectNo == 1)
                {
                    curEmptySpeedUp.enabled = true;
                    emptySpeedUp.enabled = false;
                    tObjSpeedUp.enabled = false;
                    tBarrier.enabled = false;
                    curEmptyBarrier.enabled = false;

                }
                else if (playerMove.moveSpeed < 7.5f && curItemSelectNo == 1)
                {
                    tObjSpeedUp.enabled = true;
                    tBarrier.enabled = false;
                    curEmptyBarrier.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        playerMove.MoveSpeedUp();
                        tObjSpeedUp.enabled = false;
                        curItemSelectNo = 0;
                    }
                }
                else if (curItemSelectNo == 1)
                {
                    tObjSpeedUp.enabled = true;
                    curEmptyBarrier.enabled = false;
                }

                break;

            case 2:   //�����۸޴��� ��������� ���
                if (tacoFireCtrl.isSubweapon == true && curItemSelectNo == 2)
                {
                    curEmptySubWeapon.enabled = true;
                    tObjSpeedUp.enabled = false;
                    curEmptySpeedUp.enabled = false;
                }
                else if (curItemSelectNo == 2)
                {
                    tObjsubWeapon.enabled = true;
                    tObjSpeedUp.enabled = false;
                    curEmptySpeedUp.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        tacoFireCtrl.ActiveSubWeapon();
                        tObjsubWeapon.enabled = false;
                        emptySubWeapon.enabled = true;
                        curItemSelectNo = 0;
                    }
                }
                break;

            case 3:  //�����۸޴��� ���� �Ѿ��� ���
                if (tacoFireCtrl.weaponType == 1 && curItemSelectNo == 3)
                {
                    curEmptySubWeapon.enabled = false;
                    tObjsubWeapon.enabled = false;
                    curEmptyDoubleBullet.enabled = true;
                }
                else if (curItemSelectNo == 3)
                {
                    tObjDoubleBullet.enabled = true;
                    curEmptySubWeapon.enabled = false;
                    tObjsubWeapon.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        tacoFireCtrl.weaponType = 1;
                        tObjDoubleBullet.enabled = false;
                        emptySpBullet.enabled = false;
                        emptyDoubleBullet.enabled = true;
                        curItemSelectNo = 0;
                    }

                }
                break;
            case 4:  //�����۸޴��� Ư�� �Ѿ��� ���
                if (tacoFireCtrl.weaponType == 2 && curItemSelectNo == 4)
                {
                    tObjDoubleBullet.enabled = false;
                    emptyDoubleBullet.enabled = false;
                    curEmptyDoubleBullet.enabled = false;
                    curEmptySpBullet.enabled = true;
                }
                else if (curItemSelectNo == 4)
                {
                    tObjDoubleBullet.enabled = false;
                    tObjSpBullet.enabled = true;
                    curEmptyDoubleBullet.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        tacoFireCtrl.weaponType = 2;
                        emptySpBullet.enabled = true;
                        tObjDoubleBullet.enabled = false;
                        emptyDoubleBullet.enabled = false;

                        curItemSelectNo = 0;
                    }

                }
                break;
            case 5:  //�����۸޴��� �ɼ��� ���
                if (tacoFireCtrl.optionNo == 4 && curItemSelectNo == 5)
                {
                    curEmptyOption.enabled = true;
                    tObjSpBullet.enabled = false;
                    curEmptySpBullet.enabled = false;

                }
                else if (curItemSelectNo == 5)
                {
                    tObjOption.enabled = true;
                    tObjSpBullet.enabled = false;
                    curEmptySpBullet.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        tacoFireCtrl.OptionActive();
                        tObjOption.enabled = false;
                        curItemSelectNo = 0;
                    }
                }
                break;
            case 6:   //�����۸޴��� ��ȣ���� ���
                if (tacoFireCtrl.isBarrier == true && curItemSelectNo == 6)
                {
                    curEmptyBarrier.enabled = true;
                    tBarrier.enabled = false;
                    tObjOption.enabled = false;
                    curEmptyOption.enabled = false;
                }
                else if (tacoFireCtrl.isBarrier == false && curItemSelectNo == 6)
                {
                    tBarrier.enabled = true;
                    tObjOption.enabled = false;
                    curEmptyOption.enabled = false;
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        tacoFireCtrl.BarrierActive();
                        emptyBarrier.enabled = true;
                        tBarrier.enabled = false;
                        curItemSelectNo = 0;
                    }
                }

                break;
        }
    }

    public void GetItem(int itemCount)   //�÷��̾ �������� ȹ���ϸ� ����Ǵ� �Լ� (�������̽� Ȱ��)
    {
        curItemSelectNo += itemCount;
        if (curItemSelectNo == 7)
        {
            curItemSelectNo = 1;
        }
    }
}
