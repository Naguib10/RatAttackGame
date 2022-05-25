using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    #region Singleton
    public static SfxManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of SfxManager found!");
            return;
        }

        instance = this;
    }
    #endregion

    public AudioSource audioSource;
    public AudioClip[] sfxMusics;
    public bool isPlayingSfx;

    public void ManageSFX(int num) // 0=Rat, 1=Cat, 2=Kid, 3=Win, 4= Draw, 5=Lose, 6=StartFight, 7=TimeOver
    {
        audioSource.PlayOneShot(this.sfxMusics[num]);
    }
}