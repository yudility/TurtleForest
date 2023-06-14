using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Setting;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Panel.activeSelf==false)
        {
            //Debug.Log("Panel.activeSelf= " + Panel.activeSelf);
            closeSetting();
        }
    }

    public void closeSetting()
    {
        Setting.SetActive(false);

       // Debug.Log("Setting.SetActive - fasle");
    }
}
