using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotTest : MonoBehaviour
{

    public Stack<ItemTest> slot;       // 슬롯을 스택으로 만든다.
    public TextMeshProUGUI text;       // 아이템에 개수를 표현해줄 텍스트.
    public Sprite DefaultImg; // 슬롯에 있는 아이템을 다 사용할 경우 아무것도 없는 이미지를 넣어줄 필요가 있다.

    public GameObject itemPrefab; //찾아서 프리팹 담을 곳

    private Image ItemImg;
    private bool isSlot;     // 현재 슬롯이 비어있는지?

    public ItemTest ItemReturn() { return slot.Peek(); } // 슬롯에 존재하는 아이템이 뭔지 반환.
    public bool ItemMax(ItemTest item) { return ItemReturn().MaxCount > slot.Count; } // 겹칠수 있는 한계치를 넘으면.   
    public bool isSlots() { return isSlot; } // 슬롯이 현재 비어있는지? 에 대한 플래그 반환.
    public void SetSlots(bool isSlot) { this.isSlot = isSlot; }

    void Start()
    {
        // 스택 메모리 할당.
        slot = new Stack<ItemTest>();

        // 맨 처음엔 슬롯이 비어있다.
        isSlot = false;

        // 인벤토리 및 슬롯의 크기가 커지가나 작아지면
        // 텍스트 폰트의 크기도 유동적으로 바뀌어야 한다.
        // 텍스트 폰트의 크기를 슬롯에 크기에 따라 변경해주는 구문이다.
        //RectTransform rect = text.gameObject.GetComponent<RectTransform>();
        float Size = text.gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta.x;
        text.fontSize = (int)(Size * 0.5f);

        // 텍스트 컴포넌트의 RectTransform을 가져온다.
        // 텍스트 객체의 부모 객체의 x지름을 가져온다.
        // 폰트의 크기를 부모 객체의 x지름 / 2 만큼으로 지정해준다.
        Debug.Log("get Img");
        ItemImg = transform.GetChild(0).GetComponent<Image>();
    }

    public void AddItem(ItemTest item)
    {
        // 스택에 아이템 추가.
        slot.Push(item);
        UpdateInfo(true, item.DefaultImg);
    }

    // 아이템 사용.
    /*public void ItemUse()
    {
        // 슬롯이 비어있으면 함수를 종료.
        if (!isSlot)
            return;

        // 슬롯에 아이템이 1개인 경우.
        // 아이템이 1개일 때 사용하게 되면 0개가 된다.
        if (slot.Count == 1)
        {
            // 혹시 모를 오류를 방지하기 위해 slot리스트를 Clear해준다
            slot.Clear();
            // 아이템 사용으로 인해 아이템 개수를 표현하는 텍스트가 달라졌으므로 업데이트 시켜준다.
            UpdateInfo(false, DefaultImg);
            return;
        }

        slot.Pop();
        UpdateInfo(isSlot, ItemImg.sprite);
    }*/

   /* IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
    {
        if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
        if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

        yield return new WaitForSeconds(duration);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }*/


    public void ItemUse()
    {
        if (!isSlot)
            return;

        if (slot.Count == 1)
        {
            slot.Clear();
            UpdateInfo(false, DefaultImg);
            return;
            //StartCoroutine(Haptics(1, 1, 0.1f, false, true));
        }

        ItemTest currentItem = slot.Pop();
        UpdateInfo(isSlot, ItemImg.sprite);
        

        string itemName = currentItem.Name;

        // ItemManager 오브젝트 찾기
        ItemManager itemManager = GameObject.FindObjectOfType<ItemManager>();
        if (itemManager != null)
        {
            // 아이템 이름에 따른 함수 실행
            itemManager.ExecuteItemFunction(itemName);
        }
    }
    

    private GameObject InstantiateItemObject(string itemName)
    {
        GameObject instantiatedObject = null;
        // 여기에서 itemName에 따라 적절한 프리팹을 가져와서 인스턴스화합니다.
        // 예를 들어, itemName이 "ItemA"인 경우 "ItemAPrefab"을 가져와서 인스턴스화할 수 있습니다.
        GameObject itemPrefab = Resources.Load<GameObject>(itemName + "Prefab");
        if (itemPrefab != null)
        {
            instantiatedObject = Instantiate(itemPrefab);
        }
        return instantiatedObject;
    }
   

    // 슬롯에 대한 각종 정보 업데이트.
    public void UpdateInfo(bool isSlot, Sprite sprite)
    {
        this.isSlot = isSlot;
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;

        if (slot.Count > 1)
            text.text = slot.Count.ToString();
        else
            text.text = "";

        ItemIO.SaveDate();
    }

    public string GetDefaultImageName()
    {
        if (DefaultImg != null)
        {
            return DefaultImg.name;
        }
        else
        {
            return string.Empty;
        }
    }

}
