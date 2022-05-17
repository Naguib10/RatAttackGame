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

    public ResourceImageUpdate imageUpdater;//MovSed from InputManager

    public ResourceImageUpdate[] playerChambers;//Moved from InputManager
    public ResourceImageUpdate[] enemyChambers;//Moved from InputManager


    public void Collect() 
    {

        GameResources gameResources = inputManager.clickedGameObject.GetComponent<GameResources>();

        switch (gameResources.gameResourcesTypes)
        {
            case GameResources.GameResourcesTypes.Rat:
                ratCounter++;
                gameManager.ratCounterText.text = "" + ratCounter;
                break;

            case GameResources.GameResourcesTypes.Cat:
                catCounter++;
                gameManager.catCounterText.text = "" + catCounter;
                break;

            case GameResources.GameResourcesTypes.Kid:
                kidCounter++;
                gameManager.kidCounterText.text = "" + kidCounter;
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
            //playerChambers [0-6] <-P1-P7
            case ResourceImageUpdate.ChamberNumber.P1:
                playerChambers[0] = imageUpdater;

                break;

            case ResourceImageUpdate.ChamberNumber.P2:
                playerChambers[1] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.P3:
                playerChambers[2] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.P4:
                playerChambers[3] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.P5:
                playerChambers[4] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.P6:
                playerChambers[5] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.P7:
                playerChambers[6] = imageUpdater;
                break;

            //enemyChambers [0-6] <- E1-E7
            case ResourceImageUpdate.ChamberNumber.E1:
                enemyChambers[0] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.E2:
                enemyChambers[1] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.E3:
                enemyChambers[2] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.E4:
                enemyChambers[3] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.E5:
                enemyChambers[4] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.E6:
                enemyChambers[5] = imageUpdater;
                break;

            case ResourceImageUpdate.ChamberNumber.E7:
                enemyChambers[6] = imageUpdater;
                break;

            default:
                //other more
                break;
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
            //if (imageUpdater.isCat || imageUpdater.isRat || ratCounter == 0)
            if (imageUpdater.imageInHouse.sprite.name == imageUpdater.catSprite.name || imageUpdater.imageInHouse.sprite.name == imageUpdater.ratSprite.name || ratCounter ==0)
            {
                return;
            }
            else
            {
                ratCounter--;
                gameManager.ratCounterText.text = "" + ratCounter;
                imageUpdater.PlaceRat();
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            //if (imageUpdater.isKid || imageUpdater.isCat || catCounter == 0)
            if (imageUpdater.imageInHouse.sprite.name == imageUpdater.kidSprite.name || imageUpdater.imageInHouse.sprite.name == imageUpdater.catSprite.name || catCounter == 0)
            {
                return;
            }
            else
            {
                catCounter--;
                gameManager.catCounterText.text = "" + catCounter;
                imageUpdater.PlaceCat();
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            //if (imageUpdater.isKid || imageUpdater.isRat || kidCounter == 0)
            if (imageUpdater.imageInHouse.sprite.name == imageUpdater.kidSprite.name || imageUpdater.imageInHouse.sprite.name == imageUpdater.ratSprite.name || kidCounter == 0)
            {
                return;
            }
            else
            {
                kidCounter--;
                gameManager.kidCounterText.text = "" + kidCounter;
                imageUpdater.PlaceKid();
            }
        }
    }

}
