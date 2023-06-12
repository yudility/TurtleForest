using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class testrankingjson : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] PlayerNames;
    [SerializeField] TextMeshProUGUI[] PlayerScores;

    private List<string> leaderboardNames; // List to store player names
    private List<float> leaderboardScores; // List to store player scores

    private const string LeaderboardNamesKey = "LeaderboardNames";
    private const string LeaderboardScoresKey = "LeaderboardScores";

    private void Start()
    {
        leaderboardNames = new List<string>();
        leaderboardScores = new List<float>();

        LoadLeaderboard(); // Load leaderboard data from PlayerPrefs

        // Initialize the leaderboard with dummy data (replace this with your own data)
        UpdateLeaderboard();
    }

    private void UpdateLeaderboard()
    {
        // Sort the leaderboard based on scores in descending order
        SortLeaderboard();

        // Display the top 5 winners on the leaderboard
        for (int i = 0; i < 5; i++)
        {
            if (i < leaderboardNames.Count)
            {
                PlayerNames[i].text = leaderboardNames[i];
                if (leaderboardScores[i] >= 1)
                {
                    int minutes = Mathf.FloorToInt(8 - leaderboardScores[i] / 60f);
                    int seconds = Mathf.FloorToInt(60 - leaderboardScores[i] % 60f);
                    PlayerScores[i].text = string.Format("{0:0}:{1:00}", minutes, seconds);
                }
                else
                {
                    int hp_percent = Mathf.FloorToInt(leaderboardScores[i] * 100);
                    //PlayerScores[i].text = leaderboardScores[i].ToString() + "hp";
                    PlayerScores[i].text = string.Format("{0}hp", hp_percent);
                }
            }
            else
            {
                PlayerNames[i].text = "-";
                PlayerScores[i].text = "-";
            }
        }
    }

    private void SortLeaderboard()
    {
        Debug.Log("SortLeaderboard");
        string nickname = PlayerPrefs.GetString("UserInput");
        float score_time = PlayerPrefs.GetFloat("TimeScore");

        Debug.Log("UserInput: "+ nickname);
        Debug.Log("TimeScore: " + score_time);

        if (score_time != 0)
        {
            //leaderboardNames.Add(nickname);
            leaderboardScores.Add(score_time);
        }
        else
        {
            float score_hp = PlayerPrefs.GetFloat("HpScore");
            if (score_hp != 0)
            {
                leaderboardNames.Add(nickname);
                leaderboardScores.Add(score_hp);
            }
        }

        leaderboardNames.Add("Player1");
        leaderboardScores.Add(100);
        leaderboardNames.Add("Player2");
        leaderboardScores.Add(90);
        leaderboardNames.Add("Player3");
        leaderboardScores.Add(80);
        leaderboardNames.Add("Player4");
        leaderboardScores.Add(0.5f);
        leaderboardNames.Add("Player5");
        leaderboardScores.Add(0.4f);

        for (int i = 0; i < leaderboardScores.Count - 1; i++)
        {
            for (int j = i + 1; j < leaderboardScores.Count; j++)
            {
                if (leaderboardScores[j] > leaderboardScores[i])
                {
                    // Swap scores
                    float tempScore = leaderboardScores[i];
                    leaderboardScores[i] = leaderboardScores[j];
                    leaderboardScores[j] = tempScore;

                    // Swap names
                    string tempName = leaderboardNames[i];
                    leaderboardNames[i] = leaderboardNames[j];
                    leaderboardNames[j] = tempName;
                }
            }
        }

        SaveLeaderboard(); // Save leaderboard data to PlayerPrefs
    }

    private void SaveLeaderboard()
    {
        Debug.Log("SaveLeaderboard");
        // Convert lists to JSON strings
        string namesJson = JsonUtility.ToJson(leaderboardNames);
        string scoresJson = JsonUtility.ToJson(leaderboardScores);

        // Save JSON strings to PlayerPrefs
        PlayerPrefs.SetString(LeaderboardNamesKey, namesJson);
        PlayerPrefs.SetString(LeaderboardScoresKey, scoresJson);
        PlayerPrefs.Save();
    }

    private void LoadLeaderboard()
    {
        Debug.Log("LoadLeaderboard");
        // Load JSON strings from PlayerPrefs
        string namesJson = PlayerPrefs.GetString(LeaderboardNamesKey);
        string scoresJson = PlayerPrefs.GetString(LeaderboardScoresKey);

        // Convert JSON strings back to lists
        leaderboardNames = JsonUtility.FromJson<List<string>>(namesJson);
        leaderboardScores = JsonUtility.FromJson<List<float>>(scoresJson);
    }
}
