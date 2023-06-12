using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class nickname : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateSubmit()
    {
        // Get the text entered by the user
        string userInput = nameInput.text;

        // Save the user input using PlayerPrefs or any other desired method
        PlayerPrefs.SetString("UserInput", userInput);

    }
}
