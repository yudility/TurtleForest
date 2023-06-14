using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void ExecuteItemFunction(string itemName)
    {
        // 아이템의 이름에 따라 실행할 함수를 선택하여 호출
        switch (itemName)
        {
            case "Flask":
                Flask();
                break;
            case "Snickers":
                Snickers();
                break;
            // 추가적인 아이템에 따른 처리
            default:
                Debug.LogError("Unknown item name: " + itemName);
                break;
        }
    }

    private void Flask()
    {
        HPgauge.HP += 10;
    }

    private void Snickers()
    {
        HPgauge.HP += 10;
    }
}

