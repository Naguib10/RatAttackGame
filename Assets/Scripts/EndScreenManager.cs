using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{   
    [SerializeField] Text playerResult1;
    [SerializeField] Text playerResult2;
    [SerializeField] Text playerResult3;
    [SerializeField] Text playerResultTotal;

    [SerializeField] Text enemyResult1;
    [SerializeField] Text enemyResult2;
    [SerializeField] Text enemyResult3;
    [SerializeField] Text enemyResultTotal;

    [SerializeField] Text winner;

    public List<int> pResult = new List<int>();
    public List<int> eResult = new List<int>();

    public int playerRoundsWon = 0;
    public int enemyRoundsWon = 0;


    // Start is called before the first frame update
    void Start()
    {
        BgmManager.instance.ManageBGM("Play", 2);

        pResult[0] = DataManager.instance.playerRatPointResults[0];
        pResult[1] = DataManager.instance.playerRatPointResults[1];
        pResult[2] = DataManager.instance.playerRatPointResults[2];

        eResult[0] = DataManager.instance.enemyRatPointResults[0];
        eResult[1] = DataManager.instance.enemyRatPointResults[1];
        eResult[2] = DataManager.instance.enemyRatPointResults[2];

        CheckFinalWinner();

        ShowStats();

    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void CheckFinalWinner()
    {

        for (int i = 0; i < 3; i++)
        {
            if (pResult[i] > eResult[i])
            {
                playerRoundsWon++;
            }
            else if (eResult[i] > pResult[i])
            {
                enemyRoundsWon++;
            }
        }

    }

    public void ShowStats() 
    {
        playerResult1.text = pResult[0].ToString();
        playerResult2.text = pResult[1].ToString();
        playerResult3.text = pResult[2].ToString();
        playerResultTotal.text = playerRoundsWon.ToString();

        enemyResult1.text = eResult[0].ToString();
        enemyResult2.text = eResult[1].ToString();
        enemyResult3.text = eResult[2].ToString();
        enemyResultTotal.text = enemyRoundsWon.ToString();

        if (playerRoundsWon > enemyRoundsWon)
        {
            winner.text = "You win!";
        } 
        else if (enemyRoundsWon > playerRoundsWon)
        {
            winner.text = "You lose";
        }
        else
        {
            winner.text = "Draw";
        }
    }
}
