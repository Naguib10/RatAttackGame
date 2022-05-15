using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject clickedGameObject;

    [SerializeField] Text ratCounterText;
    [SerializeField] Text catCounterText;
    [SerializeField] Text kidCounterText;

    [SerializeField] int ratCounter = 0;
    [SerializeField] int catCounter = 0;
    [SerializeField] int kidCounter = 0;

    public ResourceImageUpdate imageUpdater;

    public ResourceImageUpdate player1Image;
    public ResourceImageUpdate player2Image;
    public ResourceImageUpdate enemy1Image;

    public int ratAtPlayerHouse = 0;
    public int ratAtEnemyHouse = 0;
    [SerializeField] Text numberOfRatAtPlayerHouse;
    [SerializeField] Text numberOfRatAtEnemyHouse;
    [SerializeField] Text winOrLose;

    public string whichChamber;

    public float timeRemaining = 10.00f;
    [SerializeField] Text timer;
    bool isGameFinished = false;

    [SerializeField] GameObject spawner;
    //SpawningManager spawner;

  

    void Update()
    {
        ControlScheme();

        RatCounter();

        CountDown();

        CheckWinner();
    }

    void CountDown() 
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            timer.text = "Time left(sec): " + timeRemaining.ToString("f2");

        }

        if (timeRemaining <= 0 && timeRemaining > -0.1)
        {
            timeRemaining = -1;
            isGameFinished = true;
        }
    }

    void CheckWinner() 
    {
        if (isGameFinished) 
        {
    
            //Debug.Log("check winner");

            spawner.SetActive(false);
            //spawner.CancelSpawn();

            if (ratAtPlayerHouse < ratAtEnemyHouse)
            {
                winOrLose.text = "You win!!";
            }
            else if (ratAtPlayerHouse == ratAtEnemyHouse)
            {
                winOrLose.text = "Draw";
            }
            else
            {
                winOrLose.text = "You lose...";
            }

            isGameFinished = false;
        }
        
    }

    void RatCounter() 
    {
        numberOfRatAtPlayerHouse.text = "Rat@Player's House: " + ratAtPlayerHouse;
        numberOfRatAtEnemyHouse.text = "Rat@Enemy's House: " + ratAtEnemyHouse;
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
        /*
         * 
         * If writing as follow by using cast, it works, but it ie better to use Enum instead.
        GameResources gameResource = clickedGameObject.GetComponent<GameResources>();
        Rat rat = (Rat) gameResource;

        if (rat !=null){}

        //cat,kid as well
        */

        /*
        switch (clickedGameObject.tag)// <-- Need to change!! Use Enum value in "Resource" class.
        {
           
            case "Rat":
                //clickedGameObject..DestroyResource();
                ratCounter++;
                ratCounterText.text = "Rat Counter: " + ratCounter;
                break;

            case "Cat":
                catCounter++;
                catCounterText.text = "Cat Counter: " + catCounter;
                break;

            case "Kid":
                kidCounter++;
                kidCounterText.text = "Kid Counter: " + kidCounter;
                break;

            default:
                //Debug.Log(clickedGameObject.ToString());
                Debug.Log("Nothing clicked");
                break;
        }
        */

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
                player1Image = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.p2:
                player2Image = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.e1:
                enemy1Image = imageUpdater;
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
