using System.Collections;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerActions playerActions;
    [SerializeField] ResourceImageUpdate resourceImageUpdate;
    
    private float intervalForEnemyActions;
    private float intervalOffset;

    private int enemyRatResources;
    private int enemyCatResources;
    private int enemyKidResources;

    public float intervalLong = 4.0f;  //How many seconds does it take for enemy to fetch Player's resource data.
    public float intervalShort = 0.5f; //How many seconds does it take for enemy's action between actions.

    Coroutine lastCoroutine;

    private void Start()
    {
        enemyRatResources = 0;
        enemyCatResources = 0;
        enemyKidResources = 0;
        
        lastCoroutine = StartCoroutine(EnemyBehaviorManager(intervalLong, intervalShort));
    }

    IEnumerator EnemyBehaviorManager(float intervalToFetchPlayerStats, float MinimumintervalForEnemyActions)
    {
        while (gameManager.isGameFinished == false)
        {
            intervalForEnemyActions = (intervalToFetchPlayerStats / 5); // 5 is the number of interbals after Enemy threw resources
            intervalOffset = Mathf.Abs(intervalForEnemyActions - MinimumintervalForEnemyActions);

            enemyRatResources = playerActions.ratCounter;
            enemyCatResources = playerActions.catCounter;
            enemyKidResources = playerActions.kidCounter;

            yield return new WaitForSeconds(intervalToFetchPlayerStats);

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

                            DialogueManager.instance.StartDialogue(0, 2);// Show Player's dialogue "Don't throw kid"

                            yield return new WaitForSeconds(Random.Range(MinimumintervalForEnemyActions - intervalOffset, MinimumintervalForEnemyActions + intervalOffset));
                        }
                        break;

                    case "kid_test":
                        if (enemyRatResources > 0)
                        {
                            enemyRatResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.ratSprite;
                            gameManager.ratAtPlayerHouse++;

                            SfxManager.instance.ManageSFX(0);

                            DialogueManager.instance.StartDialogue(0, 0);// Show Player's dialogue "Don't throw rat"

                            yield return new WaitForSeconds(Random.Range(MinimumintervalForEnemyActions - intervalOffset, MinimumintervalForEnemyActions + intervalOffset));
                        }
                        break;

                    case "empty_png":
                        if (enemyRatResources > 0)
                        {
                            enemyRatResources--;
                            playerActions.playerChambers[i].imageInHouse.sprite = resourceImageUpdate.ratSprite;
                            gameManager.ratAtPlayerHouse++;

                            SfxManager.instance.ManageSFX(0);

                            DialogueManager.instance.StartDialogue(0, 0);// Show Player's dialogue "Don't throw rat"

                            yield return new WaitForSeconds(Random.Range(MinimumintervalForEnemyActions - intervalOffset, MinimumintervalForEnemyActions + intervalOffset));
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

                            DialogueManager.instance.StartDialogue(0, 1);// Show Player's dialogue "Don't throw cat"

                            yield return new WaitForSeconds(Random.Range(MinimumintervalForEnemyActions - intervalOffset, MinimumintervalForEnemyActions + intervalOffset));
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

                            DialogueManager.instance.StartDialogue(0, 1);// Show Player's dialogue "Don't throw cat"

                            yield return new WaitForSeconds(Random.Range(MinimumintervalForEnemyActions - intervalOffset, MinimumintervalForEnemyActions + intervalOffset));
                        }
                        break;


                    default:
                        break;
                }
            }
        }

    }

    public void StopEnemy()
    {
        if (gameManager.isGameFinished)
        {
            StopCoroutine(lastCoroutine);
        }
    }
}
