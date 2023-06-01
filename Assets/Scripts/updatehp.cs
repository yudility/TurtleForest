using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class updatehp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpscore; // Reference to the UI text element to display the UserInput

    private void Start()
    {
        // Retrieve the User Input value from PlayerPrefs
        float hp = PlayerPrefs.GetFloat("hp");

        // Update the timer text
        hpscore.text = string.Format("Your hp is {0}",hp);

    }
}
