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
                    HPgauge.HP -= 20f;
                }
                else
                {
                    //hpGauge.HP += 10f;
                    HPgauge.HP += 20f;
                }

                mushroom.SetActive(false);
            }
        }
    }
}
