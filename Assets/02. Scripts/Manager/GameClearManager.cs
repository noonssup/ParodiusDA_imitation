using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearManager : MonoBehaviour
{
    public Text textClearMent;

    private void OnEnable()
    {
        textClearMent.text = "�÷������ּż� �����մϴ�\n���� �� �ƽð�����, ���⼭ R Ű�� ������\n�� �ٸ� ���谡 ������ �˴ϴ�\n\n�ñ��ϸ� ��������!!";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            textClearMent.text = "���Դϴ�\n��� R Ű�� �ƴϿ��� ������\nŰ���� ����� Ű�� ������\n������ ���������� �̵��մϴ�\n�ñ��ϸ� ���������� �������\nŸ��Ʋȭ������ ������ T �� ��������";
        }
    }
}
