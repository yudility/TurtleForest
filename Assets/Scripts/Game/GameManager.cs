using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance; //싱글톤 유일성 보장.
    public static GameManager GetInstance() { init(); return Instance; }
    

    public GameState CurrentGameState { get; private set; } //게임 state. 

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged; //이벤트

    public void SetState(GameState newGameState) //게임 스테이트 설정
    {
        if (newGameState == CurrentGameState)
            return;

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }

    private static GameObject gameOverUI;
    private static GameObject rescuedUI;
    private static GameObject escapeUI;
    public static GameObject player;
    private static GameObject footStep;
    private static Transform rescuedTransform;
    //public GameObject PlayerPrefab;


    /*void Awake()
    {
        init();
    }*/

    void Start()
    {
        init();
       // FindUIObjects();
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    
    void Update()
    {
        float hp = HPgauge.HP; //전역 변수 hp 값을 가져오기
        //Debug.Log("hp:" + hp)

        if (hp <= 0.0) //반드시 게임오버
        {
            PlayerStop();
            gameOverUI.SetActive(true);
            player.transform.Find("OVRCameraRig/TrackingSpace/GameOverUI").gameObject.SetActive(true);
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

        player = GameObject.Find("Player"); // PLAYER 객체 가져오기

        if (player != null)
        {
           /*gameOverUI = GameObject.Find("player").transform.Find("GameOverUI");
            escapeUI = GameObject.Find("player").transform.Find("EscapeUI"); 
            rescuedUI = GameObject.Find("player").transform.Find("RescuedUI"); // escapeUI 가져오기
            //Debug.Log("rescuedUI: " + rescuedUI);
            footStep = GameObject.transform.Find("FootStep"); // footStep 가져오기 */
        }
        else
        {
            player = Resources.Load<GameObject>("Player");
            player.name = "Player";
            Debug.Log("player load");

            // If player is null, instantiate it using the PlayerPrefab
            if (player == null)
            {
                Debug.Log("Player prefab is not assigned!");
            }
        }
    }


    public void ShowGameOverUI(GameObject exitObject)
    {
        string exitName = exitObject.name;

        Debug.Log("ExitName : " + exitName);

        if (exitName == "Escape")
        {
            player.transform.Find("OVRCameraRig/TrackingSpace/EscapeUI").gameObject.SetActive(true);
            

            //GameObject.Find("Player").transform.Find("GameOverUI").gameObject.SetActive(true);
            PlayerStop();
            //GameState currentGameState = GameManager.Instance.CurrentGameState;
            GameManager.Instance.SetState(GameState.gameover); //게임 스테이트 변경
            Debug.Log("escape!");
        }
        else if (exitName == "Ladder")
        {
            player.transform.Find("OVRCameraRig/TrackingSpace/RescuedUI").gameObject.SetActive(true);
            //GameObject.Find("Player").transform.Find("RescuedUI").gameObject.SetActive(true);
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
            player.transform.Find("FootStep").gameObject.SetActive(true);
            //footStep.SetActive(false);
        
        
            Debug.Log("GameOver!");
        }
        else
        {
            Debug.Log("playerController is null");
        }
        //Debug.Log("playerStop!");
    }

    /*private void FindUIObjects()
    {
        gameOverUI = GameObject.Find("GameOverUI");
        escapeUI = GameObject.Find("EscapeUI");
        rescuedUI = GameObject.Find("RescuedUI");

        // Check if the UI objects were found
        if (gameOverUI == null)
            Debug.Log("GameOverUI not found!");
        if (escapeUI == null)
            Debug.Log("EscapeUI not found!");
        if (rescuedUI == null)
            Debug.Log("RescuedUI not found!");
    }*/


}
