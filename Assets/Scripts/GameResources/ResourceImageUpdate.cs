using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceImageUpdate : MonoBehaviour
{
    public Image imageInHouse = null;

    public Sprite ratSprite;
    public Sprite catSprite;
    public Sprite kidSprite;
    public Sprite emptySprite;

    public bool isRat, isCat, isKid;

    public ChamberNumber chamberNumber;

    public InputManager inputManager;


    public void PlaceRat()
    {
        if (isKid)
        {
            imageInHouse.sprite = ratSprite;
            isKid = false;
            isRat = true;
        }
        else if (!isKid)
        {
            imageInHouse.sprite = ratSprite;
            isRat = true;

            if (inputManager.whichChamber == "PlayerChamber")
            {
                inputManager.ratAtPlayerHouse++;
            }
            else if (inputManager.whichChamber == "EnemyChamber") 
            {
                inputManager.ratAtEnemyHouse++;
            }

        }

    }

    public void PlaceCat()
    {
        if (isRat)
        {
            imageInHouse.sprite = catSprite;
            isRat = false;
            isCat = true;

            if (inputManager.whichChamber == "PlayerChamber" && inputManager.ratAtPlayerHouse > 0)
            {
                inputManager.ratAtPlayerHouse--;
            }
            else if (inputManager.whichChamber == "EnemyChamber" && inputManager.ratAtEnemyHouse > 0)
            {
                inputManager.ratAtEnemyHouse--;
            }
        }
        else if (!isRat)
        {
            imageInHouse.sprite = catSprite;
            isCat = true;
        }

    }

    public void PlaceKid()
    {
        if (isCat)
        {
            imageInHouse.sprite = kidSprite;
            isCat = false;
            isKid = true;
        }
        else if (!isCat)
        {
            imageInHouse.sprite = kidSprite;
            isKid = true;
        }


    }

    public enum ChamberNumber
    {
        p1,
        p2,
        e1
    }
}
