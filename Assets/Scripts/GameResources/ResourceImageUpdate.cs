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

    public bool isRat;
    public bool isCat;
    public bool isKid;
    public bool isEmpty;

    public ChamberNumber chamberNumber;

    public void PlaceRat()
    {
        if (imageInHouse.sprite.name == kidSprite.name)
        {
            imageInHouse.sprite = ratSprite;

            if (inputManager.clickedGameObject.tag == "PlayerChamber")
            {
                gameManager.ratAtPlayerHouse++;
            }
            else if (inputManager.clickedGameObject.tag == "EnemyChamber")
            {
                gameManager.ratAtEnemyHouse++;

                DialogueManager.instance.StartDialogue(1, 0);// Show NPC's dialogue "Don't throw rat"
            }
        }
        else if (imageInHouse.sprite.name == emptySprite.name)
        {
            imageInHouse.sprite = ratSprite;

            if (inputManager.clickedGameObject.tag == "PlayerChamber")
            {
                gameManager.ratAtPlayerHouse++;
            }
            else if (inputManager.clickedGameObject.tag == "EnemyChamber")
            {
                gameManager.ratAtEnemyHouse++;

                DialogueManager.instance.StartDialogue(1, 0);// Show NPC's dialogue "Don't throw rat"
            }
        }
        else if (imageInHouse.sprite.name == catSprite.name || imageInHouse.sprite.name == ratSprite.name)
        {
            return;
        }

        SfxManager.instance.ManageSFX(0);

        isRat = true;
        isCat = false;
        isKid = false;
    }

    public void PlaceCat()
    {
        if (imageInHouse.sprite.name == ratSprite.name)
        {
            imageInHouse.sprite = catSprite;

            if (inputManager.clickedGameObject.tag == "PlayerChamber" && gameManager.ratAtPlayerHouse > 0)
            {
                gameManager.ratAtPlayerHouse--;

                DialogueManager.instance.StartDialogue(1, 1);// Show NPC's dialogue "Don't throw cat"

            }
            else if (inputManager.clickedGameObject.tag == "EnemyChamber" && gameManager.ratAtEnemyHouse > 0)
            {
                gameManager.ratAtEnemyHouse--;
            }
        }
        else if (imageInHouse.sprite.name == emptySprite.name)
        {
            imageInHouse.sprite = catSprite;

            if (inputManager.clickedGameObject.tag == "PlayerChamber") 
            {
                DialogueManager.instance.StartDialogue(1, 1);// Show NPC's dialogue "Don't throw cat"
            }
        }

        SfxManager.instance.ManageSFX(1);
    }

    public void PlaceKid()
    {
        if (imageInHouse.sprite.name == catSprite.name || imageInHouse.sprite.name == emptySprite.name)
        {
            imageInHouse.sprite = kidSprite;

            if (inputManager.clickedGameObject.tag == "EnemyChamber") 
            {
                DialogueManager.instance.StartDialogue(1, 2);// Show NPC's dialogue "Don't throw kid"
            }
        }

        SfxManager.instance.ManageSFX(2);
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
