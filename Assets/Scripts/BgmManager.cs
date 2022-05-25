using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    
    #region Singleton
    public static BgmManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of MgmManager found!");
            return;
        }
        
        instance = this;
    }
    #endregion
   
    public AudioSource audioSource;
    public AudioClip[] backGroundMusics;
    public bool isPlayingBgm;

    public void ManageBGM(string action, int num) // 0=BgmStart, 1=BgmPlay, 2=BgmEnd
    {
        audioSource.clip = this.backGroundMusics[num];

        if (!isPlayingBgm && action == "Play")
        {
            audioSource.Play();
            isPlayingBgm = true;
        }
        else if (isPlayingBgm && action == "Stop")
        {
            audioSource.Stop();
            isPlayingBgm = false;
        }
    }
}
