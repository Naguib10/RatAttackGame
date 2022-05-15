using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public GameResources rat, cat, kid;
    public float spawnTime = 1.0f;
    private Vector2 screenBounds;

    private float[] rightOrLeft = { 1f, -1f };





    //Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //StartCoroutine(ResourcesWave());
        //Spawn();

        InvokeRepeating("Spawn", 0f, spawnTime);
    }


    public void Spawn()
    {
        int randomResource = Random.Range(1, 4);
        float startingSide = rightOrLeft[Random.Range(0, 2)];

        switch (randomResource) {
            case 1:
                Instantiate(rat, new Vector2(screenBounds.x * startingSide, Random.Range(-screenBounds.y, 0)), Quaternion.identity);
                break;
            case 2:
                Instantiate(cat, new Vector2(screenBounds.x * startingSide, Random.Range(-screenBounds.y, 0)), Quaternion.identity);
                break;
            case 3:
                Instantiate(kid, new Vector2(screenBounds.x * startingSide, Random.Range(-screenBounds.y, 0)), Quaternion.identity);
                break;
        }

        //print(startingSide + " " + randomResource);
    
    }

    public void CancelSpawn()
    {
        CancelInvoke("Spawn");
    }


    //IEnumerator ResourcesWave()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnTime);
    //        gameResource.Spawn();
    //        //gameResource.MoveAround();

    //    }
    //}
}
