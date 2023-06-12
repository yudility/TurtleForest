using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{

    public RowUI rowUi;
    public ScoreManager scoreManager;
    

    // Start is called before the first frame update
    void Start()
    {
        AddNewUsersScore();
        LoadLeaderBoard();
    }

    public void LoadLeaderBoard()
    {
        var scores = scoreManager.GetHighScores().ToArray();

        for (int i = 0; i < 5; i++)
        {
            
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.nickname.text = scores[i].nickname;

            if (scores[i].timeScore >= 0)
            {
                int minutes = Mathf.FloorToInt(8 - scores[i].timeScore / 60f);
                int seconds = Mathf.FloorToInt(60 - scores[i].timeScore % 60f);
                row.score.text = string.Format("{0:0}:{1:00}", minutes, seconds);

            }
            else
            {
                int hp_percent = Mathf.FloorToInt(scores[i].hpScore * 100);
                //PlayerScores[i].text = leaderboardScores[i].ToString() + "hp";
                row.score.text = string.Format("{0}hp", hp_percent);

            }
            Debug.Log("nickname!: " + scores[i].nickname);
            Debug.Log("timeScore!: " + scores[i].timeScore);
            Debug.Log("hpScore!: " + scores[i].hpScore);
        }
       
    }

    public void AddNewUsersScore()
    {
        string nickname = PlayerPrefs.GetString("UserInput");
        float timeScore = PlayerPrefs.GetFloat("TimeScore");
        float hpScore = PlayerPrefs.GetFloat("HpScore");
        bool isDuplicated = false;

        Debug.Log("UserInput: " + nickname);
        Debug.Log("TimeScore: " + timeScore);
        Debug.Log("HpScore: " + hpScore);

        if (hpScore >= 0)
        {
            isDuplicated = scoreManager.CheckScoreExists(nickname, timeScore, hpScore); //중복 체크
            if(!isDuplicated)
                scoreManager.AddScore(new Score(nickname, timeScore, hpScore)); //중복 아닌 경우에만 추가

        }
    }


}
