using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gotosubmit : MonoBehaviour
{
    public void OnClick(){
        SceneManager.LoadScene("submit_score");
    }
}