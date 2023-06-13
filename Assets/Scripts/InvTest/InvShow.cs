using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvShow : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;

    private void Start()
    {
       
        inventoryPanel.SetActive(activeInventory);
    }

    // Update is called once per frame
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))//Oculus yŰ
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
}
