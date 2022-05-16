using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerActions playerActions;
    [SerializeField] InputManager inputManager;
    [SerializeField] ResourceImageUpdate resourceImageUpdate;
    

    public float interval; // Moved from InputManager

    public int enemyRatResources = 0;// Moved from InputManager
    public int enemyCatResources = 0;// Moved from InputManager
    public int enemyKidResources = 0;// Moved from InputManager

    private void Start()
    {
            StartCoroutine(EnemyBehaviorManager());
    }

    IEnumerator EnemyBehaviorManager()
    {
        while (gameManager.isGameFinished == false)
        {
            // Every interval (seconds), Enemy fetch the Player's stats for each resource.
            interval = 5.5f;

            enemyRatResources = playerActions.ratCounter;
            enemyCatResources = playerActions.catCounter;
            enemyKidResources = playerActions.kidCounter;

            yield return new WaitForSeconds(interval);

            for (int i = 0; i < playerActions.playerChambers.Length; i++)
            {
                //Debug.Log("PlayerChamberNum: " + i);

                switch (playerActions.playerChambers[i].imageInHouse.sprite.name)
                {

                    case "rat_test":
                        break;

                    case "cat_test":
                        if (enemyKidResources > 0)
                        {
                            enemyKidResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.kidSprite;
                        }
                        break;

                    case "kid_test":
                        if (enemyRatResources > 0)
                        {
                            enemyRatResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.ratSprite;
                            gameManager.ratAtPlayerHouse++;
                        }
                        break;

                    case "empty_png":
                        if (enemyRatResources > 0)
                        {
                            enemyRatResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.ratSprite;
                            gameManager.ratAtPlayerHouse++;
                        }
                        break;


                    default:
                        break;
                }


            }

            for (int j = 0; j < playerActions.enemyChambers.Length; j++)
            {
                switch (playerActions.enemyChambers[j].imageInHouse.sprite.name)
                {

                    case "rat_test":
                        if (enemyCatResources > 0)
                        {
                            enemyCatResources--;
                            gameManager.ratAtEnemyHouse--;
                            playerActions.enemyChambers[j].imageInHouse.sprite = resourceImageUpdate.catSprite;
                        }
                        break;

                    case "cat_test":
                        break;

                    case "kid_test":
                        break;

                    case "empty_png":
                        if (enemyCatResources > 0)
                        {
                            enemyCatResources--;
                            playerActions.enemyChambers[j].imageInHouse.sprite = resourceImageUpdate.catSprite;
                        }
                        break;


                    default:
                        break;
                }
            }

            //Debug.Log("ratEnemyResources " + enemyRatResources);
            //Debug.Log("catEnemyResources " + enemyCatResources);
            //Debug.Log("kidEnemyResources " + enemyKidResources);
        }
    }
}
