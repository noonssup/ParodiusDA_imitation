using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratePenguinZone : MonoBehaviour
{
    Transform PenguinZone;//펭귄 생성 지역

    ObjPoolingMgr ObjPoolingMgr;
    GameObject objBluePenguin;

    public string[] penguins;
    public string[] penguinsBullet;

    float pirateOn;//피라테 생성
    float Delay; //생성 주기
    private void OnEnable()
    {
        pirateOn = 0;
        Debug.Log("활성화");
        Delay = 0;
        PenguinZone = GameObject.Find("PirateShip(Clone)").GetComponentInChildren<Transform>();
        ObjPoolingMgr = GameObject.Find("ObjPoolingManager").GetComponent<ObjPoolingMgr>();
        penguins = new string[] { "PiratePenguin" };
        //penguinsBullet = new string[] { "PiratePenguinBullet" };//펭귄 스크립트로 이동시켜야함

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
