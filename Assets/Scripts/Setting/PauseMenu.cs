using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class PauseMenu : MonoBehaviour
{
    public GameObject Panel;
    bool activeMenu = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(activeMenu);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))//Oculus startŰ
        {
            OnOffMenu();
        }
    }

    public void OnOffMenu()
    {
        activeMenu = !activeMenu;
        //bool isActive = Panel.activeSelf;

        //Debug.Log("isActive" + isActive);
        //Debug.Log("activeMenu" + activeMenu);

        /*if (activeMenu != isActive)
        {
            activeMenu = !activeMenu;
        }*/
        //GameManager.player.transform.Find("OVRCameraRig/TrackingSpace/Settings").gameObject.SetActive(activeSettings);
        Panel.SetActive(activeMenu);


        GameState currentGameState = GameManager.GetInstance().CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay ? GameState.Pause : GameState.Gameplay;

        Debug.Log("currentGameState : " + currentGameState);
        Debug.Log("newGameState : " + newGameState);

        GameManager.GetInstance().SetState(newGameState);
    }
}
