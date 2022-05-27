using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    public Text ratCounterText;
    public Text catCounterText;
    public Text kidCounterText;

    public int ratAtPlayerHouse;
    public int ratAtEnemyHouse;

    [SerializeField] Text numberOfRatAtPlayerHouse;
    [SerializeField] Text numberOfRatAtEnemyHouse;
    [SerializeField] Text winOrLose;

    [SerializeField] Text timer;
    [SerializeField] GameObject spawner;

    public float timeRemaining;
    public bool isGameFinished;
    
    void Start()
    {
        ratAtPlayerHouse = 0;
        ratAtEnemyHouse = 0;
        timeRemaining = 60.00f;

        BgmManager.instance.ManageBGM("Play", 0);

        SfxManager.instance.ManageSFX(6);
    }

    void Update()
    {
        if (!isGameFinished)
        {   
            inputManager.ControlScheme();

            RatCounterUpdate();

            CountDown();
        }
        else
        {
            BgmManager.instance.ManageBGM("Stop", 1);
        }
    }

    void CountDown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timer.text = timeRemaining.ToString("f2");
        }
        else if (timeRemaining <= 0 && timeRemaining > -0.1) 
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
            Destroy(spawner);

            SfxManager.instance.ManageSFX(7);

            if (ratAtPlayerHouse < ratAtEnemyHouse)
            {
                winOrLose.text = "You win!! You threw rats more than your neighbor did!!";

                SfxManager.instance.ManageSFX(3);
            }
            else if (ratAtPlayerHouse == ratAtEnemyHouse)
            {
                winOrLose.text = "Draw";

                SfxManager.instance.ManageSFX(4);
            }
            else if (ratAtPlayerHouse > ratAtEnemyHouse)
            {
                winOrLose.text = "You lose.. Your neighbor threw rats more than you did...";

                SfxManager.instance.ManageSFX(5);
            }
        }
    }

    void RatCounterUpdate()
    {
        numberOfRatAtPlayerHouse.text = "" + ratAtPlayerHouse;
        numberOfRatAtEnemyHouse.text = "" + ratAtEnemyHouse;
    }
}
