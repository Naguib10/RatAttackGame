using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    #region Singleton
    public static DataManager instance;

    void Awake()
    {
        if (instance != null)
        {
            if (SceneManager.GetActiveScene().name == "Scene1")
            {
                Destroy(gameObject);
            }
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);// not delete data
    }
    #endregion

    public GameManager gameManager;

    public int whichLevel;
    public int playerRatPoint;
    public int enemyRatPoint;

    public List<int> levels = new List<int>();
    public List<int> playerRatPointResults = new List<int>();
    public List<int> enemyRatPointResults = new List<int>();


    public void FetchResultData(int levelNumber)
    {
        whichLevel = levelNumber;
        playerRatPoint = gameManager.ratAtEnemyHouse; // How many rat player could throw to enemy at the end of the stage 
        enemyRatPoint = gameManager.ratAtPlayerHouse; // How many rat enemy could throw to enemy at the end of the stage

        levels.Add(whichLevel);
        playerRatPointResults.Add(playerRatPoint);
        enemyRatPointResults.Add(enemyRatPoint);

    }
}
