using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolingMgr : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Pirate;


    public GameObject bossSubPrefab;
    public GameObject PantarouBulletNormalPrefab;  //��Ÿ�� �⺻ �Ѿ� ������
    public GameObject PantarouBulletDoublePrefab;  //��Ÿ�� ���� �Ѿ� ������
    public GameObject PantarouBulletSpreadPrefab;  //��Ÿ�� Ư�� �Ѿ� ������
    public GameObject PantarouBulletPotonPrefab;  //��Ÿ�� ������� ������
    public GameObject PantarouBulletSpreadBombPrefab;  //��Ÿ�� Ư������ ���� ������
    public GameObject TacoBulletNormalPrefab;  //Ÿ�� �⺻ �Ѿ� ������
    public GameObject TacoBulletDoublePrefab;  //Ÿ�� ���� �Ѿ� ������
    public GameObject TacoBulletRipplePrefab;  //Ÿ�� Ư�� �Ѿ� ������
    public GameObject TacoBulletUpTwoWayPrefab;  //Ÿ�� �������1 ������
    public GameObject TacoBulletDownTwoWayPrefab;  //Ÿ�� �������2 ������

    public GameObject piratePenguinBulletPrefab;
    public GameObject piratePenguinPrefab;
    public GameObject bulletHitEffectPrefab;
    public GameObject bossMinimeBulletPrefab;
    public GameObject pirateBulletPrefab;

    public GameObject itemWeaponPrefab;  //���� ������ ������

    /*
    public GameObject BabyChickPrefeb;
    public GameObject AdultChickPrefeb;
    public GameObject MoaiPrefeb;

    GameObject[] EBabyChick;
    GameObject[] EAdultChick;
    GameObject[] EMoai;
    */

    GameObject[] minime;

    GameObject[] PantarouBulletNormal;   //��Ÿ�� �⺻ �Ѿ��� ���� ���ӿ�����Ʈ �迭
    GameObject[] PantarouBulletDouble;   //��Ÿ�� ���� �Ѿ��� ���� ���ӿ�����Ʈ �迭
    GameObject[] PantarouBulletSpread;   //��Ÿ�� Ư�� �Ѿ��� ���� ���ӿ�����Ʈ �迭
    GameObject[] PantarouBulletPoton;   //��Ÿ�� ��������� ���� ���ӿ�����Ʈ �迭
    GameObject[] PantarouBulletSpreadBomb;   //��Ÿ�� Ư�� �Ѿ� ����ȿ���� ���� ���ӿ�����Ʈ �迭
    GameObject[] TacoBulletNormal;  //Ÿ�� �⺻ �Ѿ��� ���� ���ӿ�����Ʈ �迭
    GameObject[] TacoBulletDouble;  //Ÿ�� ���� �Ѿ��� ���� ���ӿ�����Ʈ �迭
    GameObject[] TacoBulletRipple;  //Ÿ�� Ư�� �Ѿ��� ���� ���ӿ�����Ʈ �迭
    GameObject[] TacoBulletUpTwoWay;  //Ÿ�� �������1�� ���� ���ӿ�����Ʈ �迭
    GameObject[] TacoBulletDownTwoWay;  //Ÿ�� �������2�� ���� ���ӿ�����Ʈ �迭

    GameObject[] PiratePenguinBullet;
    GameObject[] bulletHitEffect;
    GameObject[] bossMinimeBullet;
    GameObject[] pirateBullet;
    GameObject[] piratePenguin;
    GameObject[] targetPool;

    GameObject[] itemWeapon;  //���� �������� ���� ���ӿ�����Ʈ �迭

    void Awake()
    {


        minime = new GameObject[16];  //������ ��ȯ�ϴ� �̴����

        /*
        EBabyChick = new GameObject[10];  //���Ƹ�
        EAdultChick = new GameObject[5]; //��
        EMoai = new GameObject[10]; //�����
        */

        PantarouBulletNormal = new GameObject[50];   //��Ÿ�� �⺻ ����
        PantarouBulletDouble = new GameObject[50];   //��Ÿ�� ���� ����
        PantarouBulletSpread = new GameObject[50];   //��Ÿ�� ��������� ����
        PantarouBulletPoton = new GameObject[50];    //��Ÿ�� ������� ����
        PantarouBulletSpreadBomb = new GameObject[50];  //��Ÿ�� ��������� ����ȿ��
        TacoBulletNormal = new GameObject[50];     //Ÿ�� �⺻ ����
        TacoBulletDouble = new GameObject[50];     //Ÿ�� ���� ����
        TacoBulletRipple = new GameObject[50];     //Ÿ�� ���� ����
        TacoBulletUpTwoWay = new GameObject[50];   //Ÿ�� ������� ���
        TacoBulletDownTwoWay = new GameObject[50]; //Ÿ�� ������� �ϴ�

        bossMinimeBullet = new GameObject[50];
        bulletHitEffect = new GameObject[100];
        pirateBullet = new GameObject[40];
        PiratePenguinBullet = new GameObject[20];
        piratePenguin = new GameObject[10];
        itemWeapon = new GameObject[10];  //���������
        Generate();
    }

    void Generate()
    {
        //#1. Enemy
        if (Boss != null)
        {
            for (int index = 0; index < minime.Length; index++)
            {
                minime[index] = Instantiate(bossSubPrefab);
                minime[index].SetActive(false);
            }
            for (int index = 0; index < bossMinimeBullet.Length; index++)
            {
                bossMinimeBullet[index] = Instantiate(bossMinimeBulletPrefab);
                bossMinimeBullet[index].SetActive(false);
            }
        }
        if (Pirate != null)
        {
            for (int index = 0; index < piratePenguin.Length; index++)
            {
                piratePenguin[index] = Instantiate(piratePenguinPrefab);
                piratePenguin[index].SetActive(false);
            }
            for (int index = 0; index < pirateBullet.Length; index++)
            {
                pirateBullet[index] = Instantiate(pirateBulletPrefab);
                pirateBullet[index].SetActive(false);
            }
            for (int index = 0; index < PiratePenguinBullet.Length; index++)
            {
                PiratePenguinBullet[index] = Instantiate(piratePenguinBulletPrefab);
                PiratePenguinBullet[index].SetActive(false);
            }
        }
        /*      
                for (int index = 0; index < EBabyChick.Length; index++)     //���Ƹ�
                {
                    EBabyChick[index] = Instantiate(BabyChickPrefeb);
                    EBabyChick[index].SetActive(false);
                }
                for (int index = 0; index < EAdultChick.Length; index++)    //��
                {
                    EAdultChick[index] = Instantiate(AdultChickPrefeb);
                    EAdultChick[index].SetActive(false);
                }
                for (int index = 0; index < EMoai.Length; index++)          //�����
                {
                    EMoai[index] = Instantiate(MoaiPrefeb);
                    EMoai[index].SetActive(false);
                }
        */

        //#3. Bullet
        for (int index = 0; index < PantarouBulletNormal.Length; index++)
        {
            PantarouBulletNormal[index] = Instantiate(PantarouBulletNormalPrefab);
            PantarouBulletNormal[index].SetActive(false);
        }
        for (int index = 0; index < PantarouBulletDouble.Length; index++)
        {
            PantarouBulletDouble[index] = Instantiate(PantarouBulletDoublePrefab);
            PantarouBulletDouble[index].SetActive(false);
        }
        for (int index = 0; index < PantarouBulletSpread.Length; index++)
        {
            PantarouBulletSpread[index] = Instantiate(PantarouBulletSpreadPrefab);
            PantarouBulletSpread[index].SetActive(false);
        }
        for (int index = 0; index < PantarouBulletPoton.Length; index++)
        {
            PantarouBulletPoton[index] = Instantiate(PantarouBulletPotonPrefab);
            PantarouBulletPoton[index].SetActive(false);
        }
        for (int index = 0; index < PantarouBulletSpreadBomb.Length; index++)
        {
            PantarouBulletSpreadBomb[index] = Instantiate(PantarouBulletSpreadBombPrefab);
            PantarouBulletSpreadBomb[index].SetActive(false);
        }
        for (int index = 0; index < TacoBulletNormal.Length; index++)
        {
            TacoBulletNormal[index] = Instantiate(TacoBulletNormalPrefab);
            TacoBulletNormal[index].SetActive(false);
        }
        for (int index = 0; index < TacoBulletDouble.Length; index++)
        {
            TacoBulletDouble[index] = Instantiate(TacoBulletDoublePrefab);
            TacoBulletDouble[index].SetActive(false);
        }
        for (int index = 0; index < TacoBulletRipple.Length; index++)
        {
            TacoBulletRipple[index] = Instantiate(TacoBulletRipplePrefab);
            TacoBulletRipple[index].SetActive(false);
        }
        for (int index = 0; index < TacoBulletUpTwoWay.Length; index++)
        {
            TacoBulletUpTwoWay[index] = Instantiate(TacoBulletUpTwoWayPrefab);
            TacoBulletUpTwoWay[index].SetActive(false);
        }
        for (int index = 0; index < TacoBulletDownTwoWay.Length; index++)
        {
            TacoBulletDownTwoWay[index] = Instantiate(TacoBulletDownTwoWayPrefab);
            TacoBulletDownTwoWay[index].SetActive(false);
        }
        for (int index = 0; index < bulletHitEffect.Length; index++)
        {
            bulletHitEffect[index] = Instantiate(bulletHitEffectPrefab);
            bulletHitEffect[index].SetActive(false);
        }


        for (int index = 0; index < itemWeapon.Length; index++)
        {
            itemWeapon[index] = Instantiate(itemWeaponPrefab);
            itemWeapon[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "BossMinime":
                targetPool = minime;
                break;
            /*
                        case "EBabyChick":
                            targetPool = EBabyChick;
                            break;
                        case "EAdultChick":
                            targetPool = EAdultChick;
                            break;
                        case "EMoai":
                            targetPool = EMoai;
                            break;
            */
            case "BulletNormalPantarou":
                targetPool = PantarouBulletNormal;
                break;
            case "BulletDoublePantarou":
                targetPool = PantarouBulletDouble;
                break;
            case "BulletSpreadPantarou":
                targetPool = PantarouBulletSpread;
                break;
            case "BulletPotonPantarou":
                targetPool = PantarouBulletPoton;
                break;
            case "PantarouBulletSpreadBomb":
                targetPool = PantarouBulletSpreadBomb;
                break;
            case "BulletNormalTaco":
                targetPool = TacoBulletNormal;
                break;
            case "BulletDoubleTaco":
                targetPool = TacoBulletDouble;
                break;
            case "BulletRippleTaco":
                targetPool = TacoBulletRipple;
                break;
            case "TacoBulletUpTwoWay":
                targetPool = TacoBulletUpTwoWay;
                break;
            case "TacoBulletDownTwoWay":
                targetPool = TacoBulletDownTwoWay;
                break;
            case "BulletHitEffect":
                targetPool = bulletHitEffect;
                break;
            case "BossMinimeBullet":
                targetPool = bossMinimeBullet;
                break;
            case "PirateBullet":
                targetPool = pirateBullet;
                break;
            case "PiratePenguin":
                targetPool = piratePenguin;
                break;
            case "PiratePenguinBullet":
                targetPool = PiratePenguinBullet;
                break;
            case "ItemWeapon":
                targetPool = itemWeapon;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

}
