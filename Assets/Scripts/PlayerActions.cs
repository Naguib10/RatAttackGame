using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] InputManager inputManager;

    public int ratCounter = 0;// Moved
    public int catCounter = 0;// Moved 
    public int kidCounter = 0;// Moved 

    public ResourceImageUpdate imageUpdater;//Moved from InputManager

    public ResourceImageUpdate[] playerChambers;//Moved from InputManager
    public ResourceImageUpdate[] enemyChambers;//Moved from InputManager


    public void Collect() 
    {

        GameResources gameResources = inputManager.clickedGameObject.GetComponent<GameResources>();

        switch (gameResources.gameResourcesTypes)
        {
            case GameResources.GameResourcesTypes.Rat:
                ratCounter++;
                gameManager.ratCounterText.text = "Rat Counter: " + ratCounter;
                break;

            case GameResources.GameResourcesTypes.Cat:
                catCounter++;
                gameManager.catCounterText.text = "Cat Counter: " + catCounter;
                break;

            case GameResources.GameResourcesTypes.Kid:
                kidCounter++;
                gameManager.kidCounterText.text = "Kid Counter: " + kidCounter;
                break;

            default:
                //Debug.Log(clickedGameObject.ToString());
                Debug.Log("Nothing clicked");
                break;
        }
    }

    public void Throw() 
    {

        ResourceImageUpdate clickedImage = inputManager.clickedGameObject.GetComponent<ResourceImageUpdate>();
        imageUpdater = clickedImage;
        switch (clickedImage.chamberNumber)

        {
            case ResourceImageUpdate.ChamberNumber.P1:
                playerChambers[0] = imageUpdater;

                break;

            case ResourceImageUpdate.ChamberNumber.P2:
                playerChambers[1] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.E1:
                playerChambers[0] = imageUpdater;
                break;

            default:
                //other more
                break;
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (imageUpdater.isCat || imageUpdater.isRat || ratCounter == 0)
            {
                return;
            }
            else
            {
                ratCounter--;
                gameManager.ratCounterText.text = "Rat Counter: " + ratCounter;
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
                gameManager.catCounterText.text = "Cat Counter: " + catCounter;
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
                gameManager.kidCounterText.text = "Kid Counter: " + kidCounter;
                imageUpdater.PlaceKid();
            }

        }
    }
}
