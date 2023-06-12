using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPgauge : MonoBehaviour
{
    Image HPBar;
    float maxHP = 300f;
    public static float HP;
    // Start is called before the first frame update
    void Start()
    {
        HPBar = GetComponent<Image>();
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HP -= Time.deltaTime;
        HPBar.fillAmount = HP / maxHP; 
        //HP 저장 
        PlayerPrefs.SetFloat("HpScore", HP/maxHP);
    }
}
