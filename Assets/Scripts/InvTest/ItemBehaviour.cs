using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private GameObject item;
    private SlotTest slotTest;
    private string defaultImageName;
    

    private void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void init()
    {
        // SlotTest 객체의 참조 가져오기
        slotTest = GetComponent<SlotTest>();


        if (slotTest != null)
        {
            // SlotTest 스크립트의 DefaultImg의 이름 가져오기
            defaultImageName = slotTest.GetDefaultImageName();
            Debug.Log("DefaultImg의 이름: " + defaultImageName);

            item = Resources.Load<GameObject>(defaultImageName);
            if (item == null)
            {
                Debug.Log("Could not find prefeb! " + defaultImageName);
            }
        }
    }

    public void UseItem()
    {
        Component scriptComponent = item.GetComponent<Component>();

    }
}
