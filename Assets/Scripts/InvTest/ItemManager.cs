using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void ExecuteItemFunction(string itemName)
    {
        // �������� �̸��� ���� ������ �Լ��� �����Ͽ� ȣ��
        switch (itemName)
        {
            case "Flask":
                Flask();
                break;
            case "Snickers":
                Snickers();
                break;
            // �߰����� �����ۿ� ���� ó��
            default:
                Debug.LogError("Unknown item name: " + itemName);
                break;
        }
    }

    private void Flask()
    {
        float hp = HPgauge.GetInstance().GetHP(); // GetHP �޼��� ȣ���Ͽ� ��ȯ�� ���� ��������
        hp += 10f;
        HPgauge.GetInstance().SetHP(hp);
    }

    private void Snickers()
    {
        float hp = HPgauge.GetInstance().GetHP(); // GetHP �޼��� ȣ���Ͽ� ��ȯ�� ���� ��������
        hp += 10f;
        HPgauge.GetInstance().SetHP(hp);
    }
}

