using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    InputManager inputManager;
    EnemyBehaviors enemyBehaviors;
    
    public int ratCounter = 0;
    public int catCounter = 0;
    public int kidCounter = 0;

    public Text ratCounterText;//Moved to Gamemanager
    public Text catCounterText;//Moved to Gamemanager
    public Text kidCounterText;//Moved to Gamemanager

    public int ratAtPlayerHouse = 0;//Moved to GameManager
    public int ratAtEnemyHouse = 0; //Moved to GameManager
    [SerializeField] Text numberOfRatAtPlayerHouse;//Moved to GameManager
    [SerializeField] Text numberOfRatAtEnemyHouse;//Moved to GameManager
    [SerializeField] Text winOrLose;//Moved to GameManager

    [SerializeField] Text timer;
    [SerializeField] GameObject spawner;//Moved to GameManager

    public float timeRemaining = 10.00f;//Moved to GameManager
    bool isGameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.ControlScheme();//Moved to GameManager 

        CountDown();//Moved to GameManager
    }

    void CountDown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            timer.text = "Time left(sec): " + timeRemaining.ToString("f2");

            RatCounterUpdate();
        }

        if (timeRemaining <= 0 && timeRemaining > -0.1)
        {
            timeRemaining = -1;
            isGameFinished = true;
            CheckWinner();
        }
    }

    void CheckWinner()
    {

        if (isGameFinished)
        {

            //Debug.Log("check winner");

            //spawner.SetActive(false);
            //spawner.CancelSpawn();

            Destroy(spawner);
            //spawner.SetActive(false);
            //spawner.GetComponent<SpawningManager>().enabled = false;

            if (ratAtPlayerHouse < ratAtEnemyHouse)
            {
                winOrLose.text = "You win!!" + " Rat@PlayerHouse" + ratAtPlayerHouse + " Rat@EnemyHouse" + ratAtEnemyHouse;
            }
            else if (ratAtPlayerHouse == ratAtEnemyHouse)
            {
                winOrLose.text = "Draw" + " Rat@PlayerHouse" + ratAtPlayerHouse + " Rat@EnemyHouse" + ratAtEnemyHouse; ;
            }
            else if (ratAtPlayerHouse > ratAtEnemyHouse)
            {
                winOrLose.text = "You lose..." + " Rat@PlayerHouse" + ratAtPlayerHouse + " Rat@EnemyHouse" + ratAtEnemyHouse; ;
            }
        }
    }

    void RatCounterUpdate()
    {
        numberOfRatAtPlayerHouse.text = "Rat@Player's House: " + ratAtPlayerHouse;
        numberOfRatAtEnemyHouse.text = "Rat@Enemy's House: " + ratAtEnemyHouse;
    }
}
