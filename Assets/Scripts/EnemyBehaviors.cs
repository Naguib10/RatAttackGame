using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour
{
    GameManager gameManager;
    PlayerActions playerActions;
    InputManager inputManager;

    public float interval;

    public int enemyRatCounter = 0;
    public int enemyCatCounter = 0;
    public int enemyKidCounter = 0;

    private void Start()
    {
        StartCoroutine(EnemyBehaviorManager());
    }

    IEnumerator EnemyBehaviorManager()
    {
        while (true)
        {
            // Every interval (seconds), Enemy fetch the Player's stats for each resource.
            interval = 3f;

            enemyRatCounter = gameManager.ratCounter;
            enemyCatCounter = gameManager.catCounter;
            enemyKidCounter = gameManager.kidCounter;

            yield return new WaitForSeconds(interval);

            for (int i = 0; i < playerActions.playerChambers.Length; i++)
            {
                Debug.Log("PlayerChamberNum: " + i);

                switch (playerActions.playerChambers[i].imageInHouse.sprite.name)
                {

                    case "rat_test":
                        break;

                    case "cat_test":
                        if (enemyKidCounter > 0)
                        {
                            enemyKidCounter--;
                            playerActions.playerChambers[i].PlaceKid();
                        }
                        break;

                    case "kid_test":
                        if (enemyRatCounter > 0)
                        {
                            enemyRatCounter--;
                            playerActions.playerChambers[i].PlaceRat();
                            //ratAtPlayerHouse++;
                        }
                        break;

                    case "empty_png":
                        if (enemyRatCounter > 0)
                        {
                            enemyRatCounter--;
                            playerActions.playerChambers[i].PlaceRat();
                            //ratAtPlayerHouse++;
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
                        if (enemyCatCounter > 0)
                        {
                            enemyCatCounter--;
                            //ratAtEnemyHouse--;
                            playerActions.enemyChambers[j].PlaceCat();
                        }
                        break;

                    case "cat_test":
                        break;

                    case "kid_test":
                        break;

                    case "empty_png":
                        if (enemyCatCounter > 0)
                        {
                            enemyCatCounter--;
                            playerActions.enemyChambers[j].PlaceCat();
                        }
                        break;


                    default:
                        break;
                }
            }

            Debug.Log("ratEnemyResources " + enemyRatCounter);
            Debug.Log("catEnemyResources " + enemyCatCounter);
            Debug.Log("kidEnemyResources " + enemyKidCounter);
        }
    }
}
