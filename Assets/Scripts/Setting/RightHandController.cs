using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class RightHandController : MonoBehaviour
{
    public GameObject eq;  // Eq 게임 오브젝트
    public GameObject handCollider;  // HandCollider 게임 오브젝트
    public GameObject flask;  // Flask 게임 오브젝트
    public GameObject compass;  // Compass 게임 오브젝트

    private int currentItemIndex = 0;  // 현재 활성화할 아이템의 인덱스

    private void Update()
    {
        // k 키를 눌렀을 때 처리
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ActivateNextItem();
        }
    }

    private void ActivateNextItem()
    {
        // 모든 아이템을 비활성화
        DeactivateAllItems();

        // 다음 아이템을 활성화
        switch (currentItemIndex)
        {
            case 0:
                handCollider.SetActive(true);
                break;
            case 1:
                flask.SetActive(true);
                break;
            case 2:
                compass.SetActive(true);
                break;
        }

        // 현재 아이템 인덱스 증가
        currentItemIndex = (currentItemIndex + 1) % 3;
    }

    private void DeactivateAllItems()
    {
        handCollider.SetActive(false);
        flask.SetActive(false);
        compass.SetActive(false);
    }
}

