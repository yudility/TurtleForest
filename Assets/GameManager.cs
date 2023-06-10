using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;

public class GameManager : MonoBehaviour
{
    static GameManager Instance; //싱글톤 유일성 보장.
    public static GameManager GetInstance() { init(); return Instance; }

    public GameObject gameOverUI;
    public GameObject rescuedUI;
    public GameObject escapeUI;
    public GameObject player;
    public GameObject footStep;


    void Start()
    {
        init();
    }


    void Update()
    {
        
        float hp = HPgauge.HP; //전역 변수 hp 값을 가져오기
        //Debug.Log("hp:" + hp)

        if (hp <= 0.0) //반드시 게임오버
        {
            PlayerStop();
            gameOverUI.SetActive(true);
        }

    }


    static void init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("@GameManager"); //싱글톤 유일성 보장
            if (go == null)
            {
                go = new GameObject { name = "@GameManager" }; //없으면 새로 만듦.
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);

            Instance = go.GetComponent<GameManager>();
        }

    }

    public void ShowGameOverUI(GameObject exitObject)
    {
        string exitName = exitObject.name;

        Debug.Log("ExitName : " + exitName);

        if (exitName == "escape")
        {
            escapeUI.SetActive(true);
            PlayerStop();
            Debug.Log("escape!");
        }
        else if (exitName == "Ladder")
        {
            rescuedUI.SetActive(true);
            PlayerStop();
            Debug.Log("rescued!");
        }
    }

    private void PlayerStop()
    {
        OVRPlayerController playerController = player.GetComponent<OVRPlayerController>();

        if (playerController != null)
        {
            //Debug.Log(playerController);
            playerController.EnableRotation = false;
            playerController.EnableLinearMovement = false;
            Destroy(footStep);
           
            Debug.Log("GameOver!");
        }
        else
        {
            Debug.Log("playerController is null");
        }
        //Debug.Log("playerStop!");
    }
}
