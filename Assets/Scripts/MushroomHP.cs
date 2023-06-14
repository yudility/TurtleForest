using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHP : MonoBehaviour
{

    public GameObject mushroom;

    private float randomValue;

    private void Start()
    {
        randomValue = Random.value;
    }


    private void OnTriggerStay(Collider other)
    {
        float SecIndexTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        float SecHandTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

        if (SecIndexTrigger != 0.0f)
        {
            if (other.gameObject.layer == 7)
            {
                if (randomValue < 0.5f)
                {
                    float hp = HPgauge.GetInstance().GetHP(); // GetHP �޼��� ȣ���Ͽ� ��ȯ�� ���� ��������
                    hp -= 20f;
                    HPgauge.GetInstance().SetHP(hp);
                }
                else
                {
                    float hp = HPgauge.GetInstance().GetHP(); // GetHP �޼��� ȣ���Ͽ� ��ȯ�� ���� ��������
                    hp += 20f;
                    HPgauge.GetInstance().SetHP(hp);
                }

                mushroom.SetActive(false);
            }
        }
    }
}
