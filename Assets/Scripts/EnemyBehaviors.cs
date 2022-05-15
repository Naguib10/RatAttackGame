using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour
{
    GameManager gameManager;
    
    public float interval;

    public int enemyRatCounter = 0;
    public int enemyCatCounter = 0;
    public int enemyKidCounter = 0;



    IEnumerator EnemyBehaviors()
    {
        while (true)
        {
            // Every interval (seconds), Enemy fetch the Player's stats for each resource.
            interval = 3f;

            enemyRatCounter = gameManager.ratCounter;
            enemyCatCounter = gameManager.catCounter;
            enemyKidCounter = gameManager.kidCounter;

            yield return new WaitForSeconds(interval);

            for (int i = 0; i < playerChambers.Length; i++)
            {
                Debug.Log("PlayerChamberNum: " + i);

                switch (playerChambers[i].imageInHouse.sprite.name)
                {

                    case "rat_test":
                        break;

                    case "cat_test":
                        if (enemyKidCounter > 0)
                        {
                            enemyKidCounter--;
                            playerChambers[i].PlaceKid();
                        }
                        break;

                    case "kid_test":
                        if (enemyRatCounter > 0)
                        {
                            enemyRatCounter--;
                            playerChambers[i].PlaceRat();
                            //ratAtPlayerHouse++;
                        }
                        break;

                    case "empty_png":
                        if (enemyRatCounter > 0)
                        {
                            enemyRatCounter--;
                            playerChambers[i].PlaceRat();
                            //ratAtPlayerHouse++;
                        }
                        break;


                    default:
                        break;
                }


            }

            for (int j = 0; j < enemyChambers.Length; j++)
            {
                switch (enemyChambers[j].imageInHouse.sprite.name)
                {

                    case "rat_test":
                        if (enemyCatCounter > 0)
                        {
                            enemyCatCounter--;
                            ratAtEnemyHouse--;
                            enemyChambers[j].PlaceCat();
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
                            enemyChambers[j].PlaceCat();
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
