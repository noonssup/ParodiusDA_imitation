using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratePenguinZone : MonoBehaviour
{
    Transform PenguinZone;//��� ���� ����

    ObjPoolingMgr ObjPoolingMgr;
    GameObject objBluePenguin;

    public string[] penguins;
    public string[] penguinsBullet;

    float pirateOn;//�Ƕ��� ����
    float Delay; //���� �ֱ�
    private void OnEnable()
    {
        pirateOn = 0;
        Debug.Log("Ȱ��ȭ");
        Delay = 0;
        PenguinZone = GameObject.Find("PirateShip(Clone)").GetComponentInChildren<Transform>();
        ObjPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        penguins = new string[] { "PiratePenguin" };
        //penguinsBullet = new string[] { "PiratePenguinBullet" };//��� ��ũ��Ʈ�� �̵����Ѿ���

    }
    void Update()
    {
        //pirateOn += Time.deltaTime;
        //if (pirateOn > 5)
        //{
            Delay += Time.deltaTime;
            if (Delay > 2)
            {
                Penguinmake();
                Delay = 0;
            }
        //}
    }
    void Penguinmake()
    {
        objBluePenguin = ObjPoolingMgr.MakeObj(penguins[0]);
        if (objBluePenguin != null)
        {
            objBluePenguin.transform.position = PenguinZone.transform.position;
        }
    }
}
