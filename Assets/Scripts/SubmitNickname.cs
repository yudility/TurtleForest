using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SubmitNickname : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SaveUserName()
    {
        // Get the text entered by the user
        string userInput = nameInput.text;

        // Save the user input using PlayerPrefs or any other desired method
        PlayerPrefs.SetString("UserInput", userInput);

        //hp랑 timer는 이벤트 받아서 게임 종료랑 게임 상황 바뀔때마다 저장됨.
        //그러니까 nickname만 저장해도 ok
    }
}
