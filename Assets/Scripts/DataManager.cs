using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region Singleton
    public static DataManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DataManager found!");
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);// not delete data
    }
    #endregion

    [SerializeField] GameManager gameManager;

    public int whichLevel;
    public int playerRatPoint;
    public int enemyRatPoint;

    List<int> levels = new List<int>();
    List<int> playerRatPointResults = new List<int>();
    List<int> enemyRatPointResults = new List<int>();

    public void FetchResultData(int levelNumber)
    {
        whichLevel = levelNumber;
        playerRatPoint = gameManager.ratAtPlayerHouse; // How many rat player could throw to enemy at the end of the stage 
        enemyRatPoint = gameManager.ratAtEnemyHouse; // How many rat enemy could throw to enemy at the end of the stage

        levels.Add(whichLevel);
        playerRatPointResults.Add(playerRatPoint);
        enemyRatPointResults.Add(enemyRatPoint);

        Debug.Log("level: 1" + levels[0]);
        Debug.Log("playerRatPoint: " + playerRatPointResults[0]);
        Debug.Log("levels: " + enemyRatPointResults[0]);

        Debug.Log("level: 2" + levels[1]);
        Debug.Log("playerRatPoint: " + playerRatPointResults[1]);
        Debug.Log("levels: " + enemyRatPointResults[1]);

        Debug.Log("level: 3" + levels[2]);
        Debug.Log("playerRatPoint: " + playerRatPointResults[2]);
        Debug.Log("levels: " + enemyRatPointResults[2]);
    }
}
