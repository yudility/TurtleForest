using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPgauge : MonoBehaviour
{
    Image HPBar;
    float maxHP = 300f;
    public static float HP;

    void Awake()
    {
        //GameManager.Instance.OnGameStateChanged += OnGameStateChanged; //이벤트 구독
        GameManager.GetInstance().OnGameStateChanged += OnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.GetInstance().OnGameStateChanged -= OnGameStateChanged; //이벤트 구독 취소
    }


    void Start()
    {
        HPBar = GetComponent<Image>();
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().CurrentGameState == GameState.Gameplay)
        {
            HP -= Time.deltaTime;
            HPBar.fillAmount = HP / maxHP;
        }
       
        //HP 저장 
        //PlayerPrefs.SetFloat("HpScore", HP / maxHP);
    }


    private void OnGameStateChanged(GameState newgameState)
    {
        
        PlayerPrefs.SetFloat("HpScore", HP / maxHP); //gamestate 변경 이벤트 발생시 저장
        Debug.Log("newgameState : " + newgameState + " // HpScore saved :" + HP / maxHP);
    }
}
