using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        if (sceneName == "StartScene")
        {
            GameManager gameManager = GameManager.GetInstance();
            if (gameManager.CurrentGameState == GameState.Pause)
            {
                gameManager.SetState(GameState.gameover);
            }
        }
        else if (sceneName == "PlayScene-test")
        {
            GameManager gameManager = GameManager.GetInstance();
            if (gameManager.CurrentGameState != GameState.Gameplay)
            {
                gameManager.SetState(GameState.Gameplay);
            }
        }

        SceneManager.LoadScene(sceneName);
    }
}
