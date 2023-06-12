using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class showscore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score; // Reference to the UI text element to display the UserInput
    [SerializeField] TextMeshProUGUI hp;

    private void Update()
    {
        // Retrieve the User Input value from PlayerPrefs
        float score_time = PlayerPrefs.GetFloat("TimeScore");

        int minutes = Mathf.FloorToInt(8-score_time / 60f);
        int seconds = Mathf.FloorToInt(60-score_time % 60f);

        float score_hp = PlayerPrefs.GetFloat("HpScore");
        // 게임 종료 시 보이게 하기
        score.text = string.Format("time {0:0}:{1:00}", minutes, seconds);
        hp.text = string.Format("hp {0}",score_hp);
    }
}
