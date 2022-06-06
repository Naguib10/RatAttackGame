using UnityEngine;
using UnityEngine.UI;

public class ResourceImageUpdate : MonoBehaviour
{
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

            RemoveResourceFromInventoryWhenTrowingResource("Rat_I");// Added

            if (InputManager.instance.clickedGameObject.tag == "PlayerChamber")
            {
                gameManager.ratAtPlayerHouse++;
            }
            else if (InputManager.instance.clickedGameObject.tag == "EnemyChamber")
            {
                gameManager.ratAtEnemyHouse++;

                DialogueManager.instance.StartDialogue(1, 0);// Show NPC's dialogue "Don't throw rat"
            }
        }
        else if (imageInHouse.sprite.name == emptySprite.name)
        {
            imageInHouse.sprite = ratSprite;

            RemoveResourceFromInventoryWhenTrowingResource("Rat_I");// Added

            if (InputManager.instance.clickedGameObject.tag == "PlayerChamber")
            {
                gameManager.ratAtPlayerHouse++;
            }
            else if (InputManager.instance.clickedGameObject.tag == "EnemyChamber")
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

            RemoveResourceFromInventoryWhenTrowingResource("Cat_I");// Added

            if (InputManager.instance.clickedGameObject.tag == "PlayerChamber" && gameManager.ratAtPlayerHouse > 0)
            {
                gameManager.ratAtPlayerHouse--;

                DialogueManager.instance.StartDialogue(1, 1);// Show NPC's dialogue "Don't throw cat"

            }
            else if (InputManager.instance.clickedGameObject.tag == "EnemyChamber" && gameManager.ratAtEnemyHouse > 0)
            {
                gameManager.ratAtEnemyHouse--;
            }
        }
        else if (imageInHouse.sprite.name == emptySprite.name)
        {
            imageInHouse.sprite = catSprite;

            RemoveResourceFromInventoryWhenTrowingResource("Cat_I");// Added


            if (InputManager.instance.clickedGameObject.tag == "PlayerChamber") 
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

            RemoveResourceFromInventoryWhenTrowingResource("Kid_I");// Added

            if (InputManager.instance.clickedGameObject.tag == "EnemyChamber") 
            {
                DialogueManager.instance.StartDialogue(1, 2);// Show NPC's dialogue "Don't throw kid"
            }
        }

        SfxManager.instance.ManageSFX(2);
    }

    public void RemoveResourceFromInventoryWhenTrowingResource(string resourceName) //resourceName is either one of "Rat_I", "Cat_I" and "Kid_I" 
    {
        for (int i = 0; i < InventoryManager.instance.resources.Count; i++)
        {
            if (InventoryManager.instance.resources[i].resourceName == resourceName && InventoryManager.instance.resourceNumbers[i] >= 0)
            {
                InventoryManager.instance.resourceNumbers[i]--;
            }
            else if (InventoryManager.instance.resourceNumbers[i] < 0)
            {
                InventoryManager.instance.resources.Remove(InventoryManager.instance.resources[i]);
                InventoryManager.instance.resourceNumbers.Remove(InventoryManager.instance.resourceNumbers[i]);
            }

            //If there is no resource in nventory
            InventoryManager.instance.DisplayResourcesInInventory();
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
