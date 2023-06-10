using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            //ChangeVolumeZero(); -> 이러면 다시 가져오기가 힘들듯. 그냥 아래 방법이 나을 것 같은데?
            AudioListener.pause = true;
            //이렇게 되면 전체 볼륨이 0될것 같음. 근데 밑에도 똑같긴 한데...
            //배경음악이랑 효과음이랑 믹서를 따로 두나? 일단 알려준대로 해볼까
            Save();
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
}
