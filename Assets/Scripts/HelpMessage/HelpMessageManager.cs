using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMessageManager : MonoBehaviour
{
    #region Singleton
    public static HelpMessageManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of HelpMessageManager found!");
            return;
        }

        instance = this;
    }
    #endregion
    
    [SerializeField] GameObject howToPlayBox;
    [SerializeField] Text howToPlayMessageText;

    [SerializeField] GameObject helpBox;
    [SerializeField] Text helpMessageText;

    public HelpMessages helpMessages;
    public float startTime;

    public void Update()
    {
        HideShortHelp(1.0f);
    }

    public void ToggleHelpMessageHowToPlay(string action) // textIndex: Please check the inspecter on Unity
    {
        howToPlayMessageText.text = helpMessages.sentences[0];// helpMessages[textIndex] : 0= How To Play

        if (action == "Show")
        {
            howToPlayBox.SetActive(true);
        }
        else if (action == "Hide") 
        {
            howToPlayBox.SetActive(false);
        }
    }

    public void ShowShortHelp(int helpMessagesIndex) 
    {
        startTime = Time.realtimeSinceStartup;

        helpBox.transform.position = Input.mousePosition;
        helpMessageText.text = helpMessages.sentences[helpMessagesIndex];// helpMessages[textIndex] : 0= How To Play

        helpBox.SetActive(true);
    }

    public void HideShortHelp(float seconds)
    {
        if (Time.realtimeSinceStartup - startTime >= seconds)
        {
            helpBox.SetActive(false);
        }
    }

}
