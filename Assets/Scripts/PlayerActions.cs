using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    GameManager gameManager;
    InputManager inputManager;

    public ResourceImageUpdate imageUpdater;//Moved to Player Actions

    public ResourceImageUpdate[] playerChambers;//Moved to Player Actions
    public ResourceImageUpdate[] enemyChambers;//Moved to Player Actions


    public void Collect() //Suppposed to add, Destroy function from Resource class
    {

        GameResources gameResources = inputManager.clickedGameObject.GetComponent<GameResources>();

        switch (gameResources.gameResourcesTypes)//Using Enum value from GameResources script
        {
            case GameResources.GameResourcesTypes.Rat:
                gameManager.ratCounter++;
                gameManager.ratCounterText.text = "Rat Counter: " + gameManager.ratCounter;
                break;

            case GameResources.GameResourcesTypes.Cat:
                gameManager.catCounter++;
                gameManager.catCounterText.text = "Cat Counter: " + gameManager.catCounter;
                break;

            case GameResources.GameResourcesTypes.Kid:
                gameManager.kidCounter++;
                gameManager.kidCounterText.text = "Kid Counter: " + gameManager.kidCounter;
                break;

            default:
                //Debug.Log(clickedGameObject.ToString());
                Debug.Log("Nothing clicked");
                break;
        }
    }

    public void Throw() //Suppposed to be added, Spawn function from Resource class
    {

        ResourceImageUpdate clickedImage = inputManager.clickedGameObject.GetComponent<ResourceImageUpdate>();
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
            if (imageUpdater.isCat || imageUpdater.isRat || gameManager.ratCounter == 0)
            {
                return;
            }
            else
            {
                gameManager.ratCounter--;
                gameManager.ratCounterText.text = "Rat Counter: " + gameManager.ratCounter;
                imageUpdater.PlaceRat();
            }

        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (imageUpdater.isKid || imageUpdater.isCat || gameManager.catCounter == 0)
            {
                return;
            }
            else
            {
                gameManager.catCounter--;
                gameManager.catCounterText.text = "Cat Counter: " + gameManager.catCounter;
                imageUpdater.PlaceCat();
            }

        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            if (imageUpdater.isKid || imageUpdater.isRat || gameManager.kidCounter == 0)
            {
                return;
            }
            else
            {
                gameManager.kidCounter--;
                gameManager.kidCounterText.text = "Kid Counter: " + gameManager.kidCounter;
                imageUpdater.PlaceKid();
            }

        }
    }
}
