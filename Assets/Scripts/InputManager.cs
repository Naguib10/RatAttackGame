using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameObject clickedGameObject;

    [SerializeField] Text ratCounterText;
    [SerializeField] Text catCounterText;
    [SerializeField] Text kidCounterText;

    public int ratCounter = 0;//Moved to GameManager
    public int catCounter = 0;//Moved to GameManager
    public int kidCounter = 0;//Moved to GameManager

    //public int enemyRatCounter = 0;//
    //public int enemyCatCounter = 0;//
    //public int enemyKidCounter = 0;//

    public ResourceImageUpdate imageUpdater;

    //public ResourceImageUpdate player1Image;
    //public ResourceImageUpdate player2Image;
    //public ResourceImageUpdate enemy1Image;

    public ResourceImageUpdate [] playerChambers;
    public ResourceImageUpdate[] enemyChambers;
    //public float interval;//

    public int ratAtPlayerHouse = 0;
    public int ratAtEnemyHouse = 0;
    [SerializeField] Text numberOfRatAtPlayerHouse;
    [SerializeField] Text numberOfRatAtEnemyHouse;
    [SerializeField] Text winOrLose;

    public string whichChamber;

    public float timeRemaining = 10.00f;//Moved to GameManager
    [SerializeField] Text timer;
    bool isGameFinished = false;

    [SerializeField] GameObject spawner;

    void Start()
    {
        StartCoroutine(EnemyBehaviors());//Moved to GameManager
    }

    void Update()
    {
        ControlScheme();//Moved to GameManager 

        CountDown();//Moved to GameManager
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
                    Collect();
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
                    Throw();
                }
            }
        }
    }

    void Collect() //Suppposed to add, Destroy function from Resource class
    {

        GameResources gameResources = clickedGameObject.GetComponent<GameResources>();

        switch (gameResources.gameResourcesTypes)//Using Enum value from GameResources script
        {
            case GameResources.GameResourcesTypes.Rat:
                ratCounter++;
                ratCounterText.text = "Rat Counter: " + ratCounter;              
                break;

            case GameResources.GameResourcesTypes.Cat:
                catCounter++;
                catCounterText.text = "Cat Counter: " + catCounter;
                break;

            case GameResources.GameResourcesTypes.Kid:
                kidCounter++;
                kidCounterText.text = "Kid Counter: " + kidCounter;
                break;

            default:
                //Debug.Log(clickedGameObject.ToString());
                Debug.Log("Nothing clicked");
                break;
        }
    }

    void Throw() //Suppposed to be added, Spawn function from Resource class
        {

        ResourceImageUpdate clickedImage = clickedGameObject.GetComponent<ResourceImageUpdate>();
        imageUpdater = clickedImage;
        switch (clickedImage.chamberNumber)

        {
            case ResourceImageUpdate.ChamberNumber.p1:
                playerChambers[0] = imageUpdater;
                
                break;

            case ResourceImageUpdate.ChamberNumber.p2:
                playerChambers[1] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.e1:
                playerChambers[0] = imageUpdater;
                break;

            default:
                //other more
                break;
        }
        

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (imageUpdater.isCat || imageUpdater.isRat || ratCounter==0)
            {
                return;
            }
            else
            {
                ratCounter--;
                ratCounterText.text = "Rat Counter: " + ratCounter;
                imageUpdater.PlaceRat();
            }

        } 
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (imageUpdater.isKid || imageUpdater.isCat || catCounter == 0)
            {
                return;
            }
            else
            {
                catCounter--;
                catCounterText.text = "Cat Counter: " + catCounter;
                imageUpdater.PlaceCat();
            }

        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            if (imageUpdater.isKid || imageUpdater.isRat || kidCounter == 0)
            {
                return;
            }
            else
            {
                kidCounter--;
                kidCounterText.text = "Kid Counter: " + kidCounter;
                imageUpdater.PlaceKid();
            }

        }
    }
}
