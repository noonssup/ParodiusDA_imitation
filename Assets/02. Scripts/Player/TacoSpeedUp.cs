using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoSpeedUp : MonoBehaviour
{
    float delay = 0.5f;
    float removeTime = 0;
    public Transform playerPos;

    private void OnEnable()
    {
        playerPos = GameObject.Find("Taco(Clone)").GetComponent<Transform>();
    }
    private void Update()
    {
        MoveEffect();  //���ǵ�� ����Ʈ ������Ʈ�� ��ġ
        removeTime += Time.deltaTime;
        if (removeTime > delay)
        {
            this.gameObject.SetActive(false);
        }
    }

    void MoveEffect()
    {
        this.transform.position = playerPos.position + new Vector3(-0.725f,0,0);
    }
}
