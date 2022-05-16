using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceImageUpdate : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] GameManager gameManager;

    public Image imageInHouse = null;

    public Sprite ratSprite;
    public Sprite catSprite;
    public Sprite kidSprite;
    public Sprite emptySprite;

    public bool isRat, isCat, isKid, isEmpty;

    public ChamberNumber chamberNumber;

    /* This is Origiinal
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
                Debug.Log("PlayerChamber Rat++");
            }
            else if (inputManager.whichChamber == "EnemyChamber")
            {
                gameManager.ratAtEnemyHouse++;
                Debug.Log("PlayerChamber Rat++");
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
                Debug.Log("PlayerChamber Rat--");
            }
            else if (inputManager.whichChamber == "EnemyChamber" && gameManager.ratAtEnemyHouse > 0)
            {
                gameManager.ratAtEnemyHouse--;
                Debug.Log("EnemyChamber Rat--");
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
    */

    public void PlaceRat()
    {
        if (imageInHouse.sprite.name == kidSprite.name)
        {
            imageInHouse.sprite = ratSprite;
            //isKid = false;
            //isRat = true;

            if (inputManager.clickedGameObject.tag == "PlayerChamber")
            {
                gameManager.ratAtPlayerHouse++;
                Debug.Log("PlayerChamber Rat++");
            }
            else if (inputManager.clickedGameObject.tag == "EnemyChamber")
            {
                gameManager.ratAtEnemyHouse++;
                Debug.Log("EnemyChamber Rat++");
            }

        }
        else if (imageInHouse.sprite = emptySprite)
        {
            imageInHouse.sprite = ratSprite;
            //isRat = true;

            if (inputManager.clickedGameObject.tag == "PlayerChamber")
            {
                gameManager.ratAtPlayerHouse++;
                Debug.Log("PlayerChamber Rat++");
            }
            else if (inputManager.clickedGameObject.tag == "EnemyChamber")
            {
                gameManager.ratAtEnemyHouse++;
                Debug.Log("EnemyChamber Rat++");
            }
        }
        //Debug.Log(imageInHouse.sprite.name);
    }

    public void PlaceCat()
    {
        if (imageInHouse.sprite.name == ratSprite.name)
        {
            imageInHouse.sprite = catSprite;
            //isRat = false;
            //isCat = true;

            if (inputManager.clickedGameObject.tag == "PlayerChamber" && gameManager.ratAtPlayerHouse > 0)
            {
                gameManager.ratAtPlayerHouse--;
                Debug.Log("PlayerChamber Rat--");
            }
            else if (inputManager.clickedGameObject.tag == "EnemyChamber" && gameManager.ratAtEnemyHouse > 0)
            {
                gameManager.ratAtEnemyHouse--;
                Debug.Log("EnemyChamber Rat--");
            }
        }
        else if (imageInHouse.sprite.name == emptySprite.name)
        {
            imageInHouse.sprite = catSprite;
            //isCat = true;
        }

    }

    public void PlaceKid()
    {
        if (imageInHouse.sprite.name == catSprite.name)
        {
            imageInHouse.sprite = kidSprite;
            //isCat = false;
            //isKid = true;
        }
        else if (imageInHouse.sprite.name == emptySprite.name)
        {
            imageInHouse.sprite = kidSprite;
            //isKid = true;
        }


    }

    public enum ChamberNumber
    {
        P1,
        P2,
        P3,
        P4,
        P5,
        P6,
        P7,
        E1,
        E2,
        E3,
        E4,
        E5,
        E6,
        E7
    }
}
