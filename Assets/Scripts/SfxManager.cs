using UnityEngine;

public class SfxManager : MonoBehaviour
{
    #region Singleton
    public static SfxManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of SfxManager found!");
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);// not delete data
    }
    #endregion

    public AudioSource audioSource;
    public AudioClip[] sfxMusics;
    public bool isPlayingSfx;

    public void ManageSFX(int num) // num is index of sfxMusics: 0=Rat, 1=Cat, 2=Kid, 3=Win, 4= Draw, 5=Lose, 6=StartFight, 7=TimeOver
    {
        audioSource.PlayOneShot(this.sfxMusics[num]);
    }
}
