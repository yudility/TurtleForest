using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class startgame : MonoBehaviour
{
    public void OnClick(){
        SceneManager.LoadScene("playgame");
    }
}
