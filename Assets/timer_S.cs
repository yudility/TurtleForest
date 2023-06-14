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
        UpdateTimerText(); // 시작할 때 텍스트 업데이트
        //GameManager.GetInstance().OnGameStateChanged += OnGameStateChanged;
    }

    void Awake()
    {
        GameManager.GetInstance().OnGameStateChanged += OnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.GetInstance().OnGameStateChanged -= OnGameStateChanged; //이벤트 구독 취소
    }

    private void OnGameStateChanged(GameState newgameState)
    {
        PlayerPrefs.SetFloat("TimeScore", time); // gamestate 변경 이벤트 발생시 저장
        Debug.Log("newgameState : " + newgameState + " // timer saved :" + time);

        if (newgameState == GameState.Gameplay)
        {
            UpdateTimerText(); // Gameplay 상태로 변경되었을 때 텍스트 업데이트
        }
    }

    void Update()
    {
        Debug.Log("GameManager.GetInstance().CurrentGameState : " + GameManager.GetInstance().CurrentGameState);
        if (GameManager.GetInstance().CurrentGameState == GameState.Gameplay)
        {
            time -= Time.deltaTime;
            UpdateTimerText(); // Gameplay 상태일 때만 텍스트 업데이트
        }
    }

    void UpdateTimerText()
    {
        text_time[0].text = ((int)time / 60 % 60).ToString();
        text_time[1].text = ((int)time % 60).ToString();
    }

    // 다른 곳에서 이 함수를 호출하여 타이머 텍스트를 초기화할 수 있습니다.
    public void ResetTimerText()
    {
        time = 480; // 시간 초기화
        UpdateTimerText(); // 텍스트 업데이트
    }
}