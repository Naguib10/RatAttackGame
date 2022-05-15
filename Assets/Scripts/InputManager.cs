using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    GameManager gameManager;
    PlayerActions playerActions;

    public GameObject clickedGameObject;
    public string whichChamber;

    //[SerializeField] Text ratCounterText;//Moved to Gamemanager
    //[SerializeField] Text catCounterText;//Moved to Gamemanager
    //[SerializeField] Text kidCounterText;//Moved to Gamemanager

    //public int ratCounter = 0;//Moved to GameManager
    //public int catCounter = 0;//Moved to GameManager
    //public int kidCounter = 0;//Moved to GameManager

    //public int enemyRatCounter = 0;//Moved to EnemyBehaviors
    //public int enemyCatCounter = 0;//Moved to EnemyBehaviors
    //public int enemyKidCounter = 0;//Moved to EnemyBehaviors

    //public ResourceImageUpdate imageUpdater;//Moved to Player Actions

    //public ResourceImageUpdate player1Image;
    //public ResourceImageUpdate player2Image;
    //public ResourceImageUpdate enemy1Image;

    //public ResourceImageUpdate [] playerChambers;//Moved to Player Actions
    //public ResourceImageUpdate[] enemyChambers;//Moved to Player Actions
    //public float interval;//

    //public int ratAtPlayerHouse = 0;//Moved to GameManager
    //public int ratAtEnemyHouse = 0; //Moved to GameManager
    //[SerializeField] Text numberOfRatAtPlayerHouse;//Moved to GameManager
    //[SerializeField] Text numberOfRatAtEnemyHouse;//Moved to GameManager
    //[SerializeField] Text winOrLose;//Moved to GameManager

    //public float timeRemaining = 10.00f;//Moved to GameManager
    //[SerializeField] Text timer;//Moved to GameManager
    //bool isGameFinished = false;//Moved to GameManager

    //[SerializeField] GameObject spawner;//Moved to GameManager

    void Start()
    {
        //StartCoroutine(EnemyBehaviors());//Moved to GameManager
    }

    void Update()
    {
        //ControlScheme();//Moved to GameManager 

        //CountDown();//Moved to GameManager
    }


    public void ControlScheme() 
    {
        if (Input.GetMouseButtonDown(0))// When clicked Mouse-Left-Button
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);// No need "(Vector2)" in front of ray

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

                if (clickedGameObject.tag == "GameResources")//Use "GameResources" tag name. No transform between clickedGameObject nad tag since here.
                {
                    playerActions.Collect();
                    Destroy(clickedGameObject);
                }
                else if (clickedGameObject.tag == "PlayerChamber" || clickedGameObject.tag == "EnemyChamber")//Use "Houses" tag name. No transform between clickedGameObject nad tag since here.
                {
                    //Debug.Log(clickedGameObject.ToString());
                    if (clickedGameObject.tag == "PlayerChamber")
                    {
                        whichChamber = "PlayerChamber";
                    }
                    else if (clickedGameObject.tag == "EnemyChamber")
                    {
                        whichChamber = "EnemyChamber";
                    }
                    playerActions.Throw();
                }
            }
        }
    }

}
