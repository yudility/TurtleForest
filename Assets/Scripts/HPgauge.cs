using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPgauge : MonoBehaviour
{
    Image HPBar;
    float maxHP = 300f;
    private static HPgauge instance;
    private float HP;

    public static HPgauge GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        GameManager.GetInstance().OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.GetInstance().OnGameStateChanged -= OnGameStateChanged;
    }

    private void Start()
    {
        HPBar = GetComponent<Image>();
        HP = maxHP;
    }

    private void Update()
    {
        if (GameManager.GetInstance().CurrentGameState == GameState.Gameplay)
        {
            HP -= Time.deltaTime;
            HPBar.fillAmount = HP / maxHP;
        }
        HPBar.fillAmount = HP / maxHP;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        if (newGameState != GameState.Gameplay)
        {
            PlayerPrefs.SetFloat("HpScore", HP / maxHP);
            Debug.Log("newGameState : " + newGameState + " // HpScore saved :" + HP / maxHP);
        }
    }

    public float GetHP()
    {
        return HP;
    }

    public void SetHP(float value)
    {
        HP = value;
    }
}
