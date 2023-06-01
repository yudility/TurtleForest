using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class hpcontrol : MonoBehaviour
{
    private float hp = 100;

    private void Update()
    {
        PlayerPrefs.SetFloat("hp", hp);
    }
}
