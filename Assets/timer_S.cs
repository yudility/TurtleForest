using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class timer_S : MonoBehaviour
{
    
    public TextMesh[] text_time; // 시간을 표시할 text
    float time; // 시간.

    private void Start()
    {
        time = 480; //8분으로 설정
    }

    void Update() 
    {

            time -= Time.deltaTime;
            //text_time[0].text = ((int)time / 3600).ToString();
            text_time[0].text = ((int)time / 60%60).ToString();
            text_time[1].text = ((int)time % 60 ).ToString(); 
            //시간 저장
            PlayerPrefs.SetFloat("TimeScore", time);

    }
}