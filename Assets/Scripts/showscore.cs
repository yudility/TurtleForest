using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class showscore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score; // Reference to the UI text element to display the UserInput
    [SerializeField] TextMeshProUGUI hp;

    void Start()
    {
        GameManager.GetInstance().OnGameStateChanged += OnGameStateChanged;
    }

    private void Update()
    {
    }
    

    private void OnDestroy()
    {
        GameManager.GetInstance().OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        if (newGameState == GameState.gameover)
        {
            Initialize();
        }
    }


    public void Initialize()
    {
        // Retrieve the User Input value from PlayerPrefs
        float score_time = PlayerPrefs.GetFloat("TimeScore");

        int minutes = Mathf.FloorToInt(8 - score_time / 60f);
        int seconds = Mathf.FloorToInt(60 - score_time % 60f);

        float score_hp = PlayerPrefs.GetFloat("HpScore");
        // 게임 종료 시 보이게 하기
        score.text = string.Format("time {0:0}:{1:00}", minutes, seconds);
        int hp_percent = Mathf.FloorToInt(score_hp * 100);
        hp.text = string.Format("hp {0}", hp_percent);
    }


    /*private void OnEnable()
    {
        Initialize();
    }*/
}
