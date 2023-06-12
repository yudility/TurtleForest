using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUIController : MonoBehaviour
{
    public GameObject uiObject; // UI 오브젝트

    public void ShowUI()
    {
        uiObject.SetActive(true);
    }
    public void CloseUI()
    {
        uiObject.SetActive(false);
    }
}
