using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class VolumeSettings : MonoBehaviour
{
    public GameObject settingsPanel;
    bool activeSettings  = false;
    
    // Start is called before the first frame update
    void Start()
    {
        settingsPanel.SetActive(activeSettings);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))//Oculus startŰ
        {
            activeSettings = !activeSettings;
            settingsPanel.SetActive(activeSettings);
        }
    }
}
