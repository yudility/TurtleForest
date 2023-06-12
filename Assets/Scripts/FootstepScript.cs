using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR; 

public class FootstepScript : MonoBehaviour
{

    public GameObject footstep;
    bool isWalking = true;

    void Awake()
    {
        //GameManager.Instance.OnGameStateChanged += OnGameStateChanged; //이벤트 구독
        GameManager.GetInstance().OnGameStateChanged += OnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.GetInstance().OnGameStateChanged -= OnGameStateChanged; //이벤트 구독 취소
    }

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)!= Vector2.zero) //스틱 움직일때
            {
                footsteps();
            }

            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) == Vector2.zero)//스틱 안움직일 때
            {
                Stopfootsteps();
            }
        }

    }

    void footsteps()
    {
        footstep.SetActive(true);
    }
    void Stopfootsteps()
    {
        footstep.SetActive(false);
    }

    private void OnGameStateChanged(GameState newgameState)
    {
        isWalking = !isWalking;
    }

}
