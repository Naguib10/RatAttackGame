using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ratCounterText;
    public Text catCounterText;
    public Text kidCounterText;

    public int ratAtPlayerHouse;
    public int ratAtEnemyHouse;

    [SerializeField] Text numberOfRatAtPlayerHouse;
    [SerializeField] Text numberOfRatAtEnemyHouse;

    [SerializeField] GameObject resultBox;
    [SerializeField] Text resultText;

    [SerializeField] Text timer;

    [SerializeField] GameObject spawner;

    public float timeRemaining;
    public bool isGameFinished;
    
    void Start()
    {
        ratAtPlayerHouse = 0;
        ratAtEnemyHouse = 0;
        //timeRemaining = 60.00f;
        
        BgmManager.instance.ManageBGM("Play", 0);

        SfxManager.instance.ManageSFX(6);
    }

    void Update()
    {
        if (!isGameFinished)
        {
            InputManager.instance.ControlScheme();

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
                ShowResult("Win");

                SfxManager.instance.ManageSFX(3);
            }
            else if (ratAtPlayerHouse == ratAtEnemyHouse)
            {
                ShowResult("Draw");

                SfxManager.instance.ManageSFX(4);
            }
            else if (ratAtPlayerHouse > ratAtEnemyHouse)
            {
                ShowResult("Lose");

                SfxManager.instance.ManageSFX(5);
            }
        }
    }

    void RatCounterUpdate()
    {
        numberOfRatAtPlayerHouse.text = "" + ratAtPlayerHouse;
        numberOfRatAtEnemyHouse.text = "" + ratAtEnemyHouse;
    }

    void ShowResult(string result) 
    {
        resultBox.SetActive(true);

        switch (result)
        {
            case "Win":
                resultText.text = "You win!! You threw rats more than your neighbor did!!";
                break;

            case "Draw":
                resultText.text = "Draw";
                break;

            case "Lose":
                resultText.text = "You lose.. Your neighbor threw rats more than you did...";
                break;

            default:
                break;
        }
    }
}
