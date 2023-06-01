using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ranking : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rank_time; // Reference to the UI text element to display the UserInput
    [SerializeField] TextMeshProUGUI rank_hp;

    private void Start()
    {
        // Retrieve the User Input value from PlayerPrefs
        string nickname = PlayerPrefs.GetString("UserInput");
        float timescore = PlayerPrefs.GetFloat("Elapsed Time");

        int minutes = Mathf.FloorToInt(timescore / 60f);
        int seconds = Mathf.FloorToInt(timescore % 60f);

        string[] leaderboard = { "3", "4", "5", "4hp", "5hp" }; 

        // Concatenate leaderboard elements into a single string
        string leaderboardText = "";
        for (int i = 0; i < leaderboard.Length; i++)
        {
            leaderboardText += string.Format("{0}. {1}\n", i + 1, leaderboard[i]);
        }

        rank_time.text = leaderboardText;
    }
}



//rank_time.text = string.Format("4. {0} {1:0}:{2:00}", nickname, minutes, seconds); 

//float hp = PlayerPrefs.GetFloat("hp");
//rank_hp.text = string.Format("5. {0} {1:0}", nickname, hp);