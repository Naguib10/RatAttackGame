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

    InputManager inputManager;
    GameManager gameManager;


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
                gameManager.ratAtPlayerHouse++;
            }
            else if (inputManager.whichChamber == "EnemyChamber") 
            {
                gameManager.ratAtEnemyHouse++;
            }

        }

        //Debug.Log(imageInHouse.sprite.name);
    }

    public void PlaceCat()
    {
        if (isRat)
        {
            imageInHouse.sprite = catSprite;
            isRat = false;
            isCat = true;

            if (inputManager.whichChamber == "PlayerChamber" && gameManager.ratAtPlayerHouse > 0)
            {
                gameManager.ratAtPlayerHouse--;
            }
            else if (inputManager.whichChamber == "EnemyChamber" && gameManager.ratAtEnemyHouse > 0)
            {
                gameManager.ratAtEnemyHouse--;
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
        p3,
        p4,
        p5,
        p6,
        p7,
        e1,
        e2,
        e3,
        e4,
        e5,
        e6,
        e7
    }
}
