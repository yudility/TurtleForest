using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class escape : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI elapsedTimeText; // Reference to the UI text element to display the elapsed time

    private void Start()
    {
        // Retrieve the elapsed time value from PlayerPrefs
        float elapsedTime = PlayerPrefs.GetFloat("Elapsed Time");

        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Update the elapsed time text
        elapsedTimeText.text = string.Format("Elapsed Time: {0:00}:{1:00}", minutes, seconds);

        // Optionally, you can clear the PlayerPrefs value after retrieving it
        // PlayerPrefs.DeleteKey("Elapsed Time");
    }
}