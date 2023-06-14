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
        float hp = HPgauge.GetInstance().GetHP(); // GetHP 메서드 호출하여 반환된 값을 가져오기
        hp += 10f;
        HPgauge.GetInstance().SetHP(hp);
    }

    private void Snickers()
    {
        float hp = HPgauge.GetInstance().GetHP(); // GetHP 메서드 호출하여 반환된 값을 가져오기
        hp += 10f;
        HPgauge.GetInstance().SetHP(hp);
    }
}

