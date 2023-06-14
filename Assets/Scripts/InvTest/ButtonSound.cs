using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button button;
    public AudioClip soundClip;
    public AudioSource audioSource;

    private void Start()
    {
        // 버튼 클릭 이벤트에 핸들러 등록
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        // 오디오 소스에 클립 할당 및 재생
        audioSource.clip = soundClip;
        audioSource.Play();
    }
}
