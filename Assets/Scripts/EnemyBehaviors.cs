using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerActions playerActions;
    [SerializeField] ResourceImageUpdate resourceImageUpdate;
    
    public float interval;

    public int enemyRatResources;
    public int enemyCatResources;
    public int enemyKidResources;

    private void Start()
    {
        enemyRatResources = 0;
        enemyCatResources = 0;
        enemyKidResources = 0;

        StartCoroutine(EnemyBehaviorManager());
    }

    IEnumerator EnemyBehaviorManager()
    {
        while (gameManager.isGameFinished == false)
        {
            interval = 4.0f;// Every interval (seconds), Enemy fetch the Player's stats for each resource.

            enemyRatResources = playerActions.ratCounter;
            enemyCatResources = playerActions.catCounter;
            enemyKidResources = playerActions.kidCounter;

            yield return new WaitForSeconds(interval);

            for (int i = 0; i < playerActions.playerChambers.Length; i++)
            {
                switch (playerActions.playerChambers[i].imageInHouse.sprite.name)
                {

                    case "rat_test":
                        break;

                    case "cat_test":
                        if (enemyKidResources > 0)
                        {
                            enemyKidResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.kidSprite;

                            SfxManager.instance.ManageSFX(2);

                            yield return new WaitForSeconds(0.5f);
                        }
                        break;

                    case "kid_test":
                        if (enemyRatResources > 0)
                        {
                            enemyRatResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.ratSprite;
                            gameManager.ratAtPlayerHouse++;

                            SfxManager.instance.ManageSFX(0);

                            yield return new WaitForSeconds(0.5f);
                        }
                        break;

                    case "empty_png":
                        if (enemyRatResources > 0)
                        {
                            enemyRatResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.ratSprite;
                            gameManager.ratAtPlayerHouse++;

                            SfxManager.instance.ManageSFX(0);

                            yield return new WaitForSeconds(0.5f);
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

                            SfxManager.instance.ManageSFX(1);

                            yield return new WaitForSeconds(0.5f);
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

                            SfxManager.instance.ManageSFX(1);

                            yield return new WaitForSeconds(0.5f);
                        }
                        break;


                    default:
                        break;
                }
            }
        }
    }
}
