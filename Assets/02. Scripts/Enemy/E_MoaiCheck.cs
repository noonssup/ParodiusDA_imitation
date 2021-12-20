using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_MoaiCheck : MonoBehaviour    //����̸� �׷�ȭ �� �ڵ�
{
    public E_MoaiCtrl moaiCtrl;             //����� ������ ��Ʈ���ϴ� �ڵ��� ����
    public GameObject ItemPrefeb;           //����� 1��Ʈ�� �����߸��� ������ ������

    public int itemLimit;                   //������ ���� ����
    public int attackCount;

    private void OnEnable()
    {
        for (int i = 0; i < 5; i++)
        { moaiCtrl = GameObject.Find("Moai" + i).GetComponent<E_MoaiCtrl>(); }
        attackCount = 0;
        itemLimit = 0;
    }
    //void Start()
    //{
    //    for (int i = 0; i < 5; i++)
    //    { moaiCtrl = GameObject.Find("Moai" + i).GetComponent<E_MoaiCtrl>(); }
    //    attackCount = 0;
    //    itemLimit = 0;
    //}

    void Update()
    {
        if (gameObject.transform.childCount <= 0)
        {
            if (attackCount >= 4)
            {
                if (this.gameObject.name == "MoaiGroup1(Clone)")
                {
                    Instantiate(ItemPrefeb, moaiCtrl.contactPoint1, Quaternion.identity);
                    Debug.Log("moaiCtrl.contactPoint1 : "+moaiCtrl.contactPoint1);
                    Destroy(gameObject);
                }
               if (this.gameObject.name == "MoaiGroup2(Clone)")
                {
                    Instantiate(ItemPrefeb, moaiCtrl.contactPoint2, Quaternion.identity);
                    Debug.Log("moaiCtrl.contactPoint2 : " + moaiCtrl.contactPoint2);
                    Destroy(gameObject);
                }
            }

            else
                Destroy(gameObject);
        }
    }
}
