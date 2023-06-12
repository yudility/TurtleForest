using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance; //�̱��� ���ϼ� ����.
    public static GameManager GetInstance() { init(); return Instance; }
    

    public GameState CurrentGameState { get; private set; } //���� state. 

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged; //�̺�Ʈ

    public void SetState(GameState newGameState) //���� ������Ʈ ����
    {
        if (newGameState == CurrentGameState)
            return;

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }

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
        
        float hp = HPgauge.HP; //���� ���� hp ���� ��������
        //Debug.Log("hp:" + hp)

        if (hp <= 0.0) //�ݵ�� ���ӿ���
        {
            PlayerStop();
            gameOverUI.SetActive(true);
        }

    }


    static void init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("@GameManager"); //�̱��� ���ϼ� ����
            if (go == null)
            {
                go = new GameObject { name = "@GameManager" }; //������ ���� ����.
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
            //GameState currentGameState = GameManager.Instance.CurrentGameState;
            GameManager.Instance.SetState(GameState.gameover); //���� ������Ʈ ����
            Debug.Log("escape!");
        }
        else if (exitName == "Ladder")
        {
            rescuedUI.SetActive(true);
            PlayerStop();
           //GameState currentGameState = GameManager.Instance.CurrentGameState;
            GameManager.Instance.SetState(GameState.gameover);
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
            footStep.SetActive(false);


            Debug.Log("GameOver!");
        }
        else
        {
            Debug.Log("playerController is null");
        }
        //Debug.Log("playerStop!");
    }
}