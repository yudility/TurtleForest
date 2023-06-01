using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class timer_M : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public Button stopButton;

    public float LimitTime = 480f; //8minutes given to the player 
    private float elapsedTime = 0f; //player time

    private bool isTimerRunning = true; //flag to the track if the timer is running

    private void Start(){
        //Initialize the timer text with the total play time
        UpdateTimerText();

        //Add an event listener to the stop button
        //stopButton.OnClick.AddListener(StopTimer);
    }

    public void Update()
    {
        //Check if the timer is running
        if(!isTimerRunning)
            return;

        //LimitTime = Time.deltaTime;
        if (elapsedTime >= LimitTime)
        {
            isTimerRunning = false;
            //Debug.Log("Time Over");

            PlayerPrefs.SetFloat("Elapsed Time", elapsedTime);

            //check hp saved from hp scene
            float hp = PlayerPrefs.GetFloat("hp");

            if (hp <= 0){
                SceneManager.LoadScene("end_gameover");
                return;
            }
            else{
                SceneManager.LoadScene("end_rescued");
                return;
            }

        }

        //update the elapsed time
        elapsedTime += Time.deltaTime;

        //update the timer text
        UpdateTimerText();
    }

    public void UpdateTimerText()
    {
        //calculate minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Update the timer text
        timerText.text = string.Format("PlayerTime {0:0}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        // Stop the timer
        isTimerRunning = false;

        // Save the elapsed time to PlayerPrefs
        PlayerPrefs.SetFloat("Elapsed Time", elapsedTime);

        // Change the scene to "end_escaped"
        SceneManager.LoadScene("end_escape");
    }
}

