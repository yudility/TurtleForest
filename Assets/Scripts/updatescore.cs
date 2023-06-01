using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class updatescore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score; // Reference to the UI text element to display the UserInput

    private void Start()
    {
        // Retrieve the User Input value from PlayerPrefs
        float score_time = PlayerPrefs.GetFloat("Elapsed Time");

        int minutes = Mathf.FloorToInt(score_time / 60f);
        int seconds = Mathf.FloorToInt(score_time % 60f);

        // Update the timer text
        score.text = string.Format("Your score is {0:0}:{1:00}", minutes, seconds);

    }
}
