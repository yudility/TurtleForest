using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotTest : MonoBehaviour
{

    public Stack<ItemTest> slot;       // ������ �������� �����.
    public TextMeshProUGUI text;       // �����ۿ� ������ ǥ������ �ؽ�Ʈ.
    public Sprite DefaultImg; // ���Կ� �ִ� �������� �� ����� ��� �ƹ��͵� ���� �̹����� �־��� �ʿ䰡 �ִ�.

    public GameObject itemPrefab; //ã�Ƽ� ������ ���� ��

    private Image ItemImg;
    private bool isSlot;     // ���� ������ ����ִ���?

    public ItemTest ItemReturn() { return slot.Peek(); } // ���Կ� �����ϴ� �������� ���� ��ȯ.
    public bool ItemMax(ItemTest item) { return ItemReturn().MaxCount > slot.Count; } // ��ĥ�� �ִ� �Ѱ�ġ�� ������.   
    public bool isSlots() { return isSlot; } // ������ ���� ����ִ���? �� ���� �÷��� ��ȯ.
    public void SetSlots(bool isSlot) { this.isSlot = isSlot; }

    void Start()
    {
        // ���� �޸� �Ҵ�.
        slot = new Stack<ItemTest>();

        // �� ó���� ������ ����ִ�.
        isSlot = false;

        // �κ��丮 �� ������ ũ�Ⱑ Ŀ������ �۾�����
        // �ؽ�Ʈ ��Ʈ�� ũ�⵵ ���������� �ٲ��� �Ѵ�.
        // �ؽ�Ʈ ��Ʈ�� ũ�⸦ ���Կ� ũ�⿡ ���� �������ִ� �����̴�.
        //RectTransform rect = text.gameObject.GetComponent<RectTransform>();
        float Size = text.gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta.x;
        text.fontSize = (int)(Size * 0.5f);

        // �ؽ�Ʈ ������Ʈ�� RectTransform�� �����´�.
        // �ؽ�Ʈ ��ü�� �θ� ��ü�� x������ �����´�.
        // ��Ʈ�� ũ�⸦ �θ� ��ü�� x���� / 2 ��ŭ���� �������ش�.
        Debug.Log("get Img");
        ItemImg = transform.GetChild(0).GetComponent<Image>();
    }

    public void AddItem(ItemTest item)
    {
        // ���ÿ� ������ �߰�.
        slot.Push(item);
        UpdateInfo(true, item.DefaultImg);
    }

    // ������ ���.
    /*public void ItemUse()
    {
        // ������ ��������� �Լ��� ����.
        if (!isSlot)
            return;

        // ���Կ� �������� 1���� ���.
        // �������� 1���� �� ����ϰ� �Ǹ� 0���� �ȴ�.
        if (slot.Count == 1)
        {
            // Ȥ�� �� ������ �����ϱ� ���� slot����Ʈ�� Clear���ش�
            slot.Clear();
            // ������ ������� ���� ������ ������ ǥ���ϴ� �ؽ�Ʈ�� �޶������Ƿ� ������Ʈ �����ش�.
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

        // ItemManager ������Ʈ ã��
        ItemManager itemManager = GameObject.FindObjectOfType<ItemManager>();
        if (itemManager != null)
        {
            // ������ �̸��� ���� �Լ� ����
            itemManager.ExecuteItemFunction(itemName);
        }
    }
    

    private GameObject InstantiateItemObject(string itemName)
    {
        GameObject instantiatedObject = null;
        // ���⿡�� itemName�� ���� ������ �������� �����ͼ� �ν��Ͻ�ȭ�մϴ�.
        // ���� ���, itemName�� "ItemA"�� ��� "ItemAPrefab"�� �����ͼ� �ν��Ͻ�ȭ�� �� �ֽ��ϴ�.
        GameObject itemPrefab = Resources.Load<GameObject>(itemName + "Prefab");
        if (itemPrefab != null)
        {
            instantiatedObject = Instantiate(itemPrefab);
        }
        return instantiatedObject;
    }
   

    // ���Կ� ���� ���� ���� ������Ʈ.
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
