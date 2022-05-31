using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    #region Singleton
    public static InventoryUIManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryUIManager found!");
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);// not deleate
    }
    #endregion

    public GameObject inventoryMenu;

    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    public void InventoryUIControl()
    {
        if (InputManager.instance.isPaused)
        {
            Resume();//If game is paused, press Esc to Resume game
        }
        else
        {
            Pause();//If game is started, press Esc to Pause game
        }
    }

    private void Resume() 
    {
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f; // real time is 1.0f
        InputManager.instance.isPaused = false;
    }

    private void Pause()
    {
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f; // stop the time
        InputManager.instance.isPaused = true;
    }

}
