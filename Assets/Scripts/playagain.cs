using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playagain : MonoBehaviour
{
    public void OnClick(){
        SceneManager.LoadScene("playgame");
    }
}

