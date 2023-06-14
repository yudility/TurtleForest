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

            //GameManage gameManager = GameManager.GetInstance();
            /* if (GameManager.CurrentGameState == GameState.Pause)
             {
                 Debug.Log("gameManager.CurrentGameState before ChangeScene - StartScene :"+ gameManager.CurrentGameState)
                 GameManager.SetState(GameState.gameover);
             }
             else if (GameManager.CurrentGameState == GameState.Gameplay)
             {
                 GameManager.SetState(GameState.gameover);
             }*/

            if (GameManager.GetInstance().CurrentGameState != GameState.gameover)
            {
                GameManager.GetInstance().SetState(GameState.gameover);
            }
        }
        else if (sceneName == "PlayScene-test")
        {
            //GameManager gameManager = GameManager.GetInstance();
            if (GameManager.GetInstance().CurrentGameState != GameState.Gameplay)
            {
                GameManager.GetInstance().SetState(GameState.Gameplay);
            }
        }

        SceneManager.LoadScene(sceneName);
    }
}
