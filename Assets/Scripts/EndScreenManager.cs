using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{   
    [SerializeField] Text playerResult1;
    [SerializeField] Text playerResult2;
    [SerializeField] Text playerResult3;

    [SerializeField] Text enemyResult1;
    [SerializeField] Text enemyResult2;
    [SerializeField] Text enemyResult3;


    // Start is called before the first frame update
    void Start()
    {
        BgmManager.instance.ManageBGM("Play", 2);

        ShowStats();
    
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void ShowStats() 
    {
        playerResult1.text = DataManager.instance.playerRatPointResults[0].ToString();
        playerResult2.text = DataManager.instance.playerRatPointResults[1].ToString();
        playerResult3.text = DataManager.instance.playerRatPointResults[2].ToString();

        enemyResult1.text = DataManager.instance.enemyRatPointResults[0].ToString();
        enemyResult2.text = DataManager.instance.enemyRatPointResults[1].ToString();
        enemyResult3.text = DataManager.instance.enemyRatPointResults[2].ToString();
    }
}
