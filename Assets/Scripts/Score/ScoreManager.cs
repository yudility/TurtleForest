using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ScoreManager : MonoBehaviour
{

    private ScoreData sd;

    // Start is called before the first frame update
    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        //sd = new ScoreData();

        sd = JsonUtility.FromJson<ScoreData>(json);
    }


    public IEnumerable<Score> GetHighScores()
    {
        var highScoresTime = sd.scores.OrderByDescending(x => x.timeScore);
        var highScoresHp = sd.scores.OrderByDescending(x => x.hpScore);
        var filteredScores = highScoresTime.Where(x => x.timeScore >= 0)
                                       .Concat(highScoresHp.Where(x => x.timeScore < 0));
        return filteredScores;
    }

    public bool CheckScoreExists(string nickname, float timeScore, float hpScore)
    {
        return sd.scores.Any(score => score.nickname == nickname && score.timeScore == timeScore && score.hpScore == hpScore);
    }


    public void AddScore(Score score)
    {
        sd.scores.Add(score);
        Debug.Log("nickname!: " + score.nickname);
        Debug.Log("timeScore!: " + score.timeScore);
        Debug.Log("hpScore!: " + score.hpScore);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }

}
